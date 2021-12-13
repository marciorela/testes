﻿using hass_workstation_service.Communication;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Management;
using System.Runtime.Versioning;
using System.Text;

namespace hass_workstation_service.Domain.Sensors
{

    [SupportedOSPlatform("windows")]
    public class MemoryUsageSensor : WMIQuerySensor
    {
        public MemoryUsageSensor(MqttPublisher publisher, int? updateInterval = null, string name = "MemoryUsage", Guid id = default) : base(publisher, "SELECT FreePhysicalMemory,TotalVisibleMemorySize FROM Win32_OperatingSystem", updateInterval ?? 10, name ?? "MemoryUsage", id)
        {
        }
        public override string GetState()
        {
            using (ManagementObjectCollection collection = _searcher.Get())
            {
                UInt64? totalMemory = null;
                UInt64? freeMemory = null;
                foreach (ManagementObject mo in collection)
                {
                    totalMemory = (UInt64)mo.Properties["TotalVisibleMemorySize"]?.Value;
                    freeMemory = (UInt64)mo.Properties["FreePhysicalMemory"]?.Value;
                }
                if (totalMemory != null && freeMemory != null)
                {
                    decimal totalMemoryDec = totalMemory.Value;
                    decimal freeMemoryDec = freeMemory.Value;
                    decimal precentageUsed = 100 - (freeMemoryDec / totalMemoryDec) * 100;
                    return precentageUsed.ToString("#.##", CultureInfo.InvariantCulture);
                }
                return "";
            }
            
        }
        public override SensorDiscoveryConfigModel GetAutoDiscoveryConfig()
        {
            return this._autoDiscoveryConfigModel ?? SetAutoDiscoveryConfigModel(new SensorDiscoveryConfigModel()
            {
                Name = this.Name,
                Unique_id = this.Id.ToString(),
                Device = this.Publisher.DeviceConfigModel,
                State_topic = $"homeassistant/{this.Domain}/{Publisher.DeviceConfigModel.Name}/{this.ObjectId}/state",
                Icon = "mdi:memory",
                Unit_of_measurement = "%",
                Availability_topic = $"homeassistant/{this.Domain}/{Publisher.DeviceConfigModel.Name}/availability"
            });
        }
    }
}
