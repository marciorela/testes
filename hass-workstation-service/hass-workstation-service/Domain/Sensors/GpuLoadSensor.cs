﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hass_workstation_service.Communication;
using LibreHardwareMonitor.Hardware;

namespace hass_workstation_service.Domain.Sensors
{
    public class GpuLoadSensor : AbstractSensor
    {
        private Computer _computer;
        private IHardware _gpu;
        public GpuLoadSensor(MqttPublisher publisher, int? updateInterval = null, string name = "GPULoad", Guid id = default(Guid)) : base(publisher, name ?? "GPULoad", updateInterval ?? 10, id)
        {
            _computer = new Computer
            {
                IsCpuEnabled = false,
                IsGpuEnabled = true,
                IsMemoryEnabled = false,
                IsMotherboardEnabled = false,
                IsControllerEnabled = false,
                IsNetworkEnabled = false,
                IsStorageEnabled = false,
            };

            _computer.Open();
            this._gpu = _computer.Hardware.FirstOrDefault(h => h.HardwareType == HardwareType.GpuAmd || h.HardwareType == HardwareType.GpuNvidia);
        }

        public override DiscoveryConfigModel GetAutoDiscoveryConfig()
        {
            return this._autoDiscoveryConfigModel ?? SetAutoDiscoveryConfigModel(new SensorDiscoveryConfigModel()
            {
                Name = this.Name,
                Unique_id = this.Id.ToString(),
                Device = this.Publisher.DeviceConfigModel,
                State_topic = $"homeassistant/{this.Domain}/{Publisher.DeviceConfigModel.Name}/{this.ObjectId}/state",
                Unit_of_measurement = "%",
                Availability_topic = $"homeassistant/{this.Domain}/{Publisher.DeviceConfigModel.Name}/availability"
            });
        }

        public override string GetState()
        {
            if (_gpu == null)
            {
                return "NotSupported";
            }
            _gpu.Update();
            var sensor = _gpu.Sensors.FirstOrDefault(s => s.SensorType == SensorType.Load);
            if (sensor == null)
            {
                return "NotSupported";
            }
            return sensor.Value.HasValue ? sensor.Value.Value.ToString("#.##", CultureInfo.InvariantCulture) : "Unknown";
        }
    }
}
