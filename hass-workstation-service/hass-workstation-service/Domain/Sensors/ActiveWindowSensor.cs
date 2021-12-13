﻿using hass_workstation_service.Communication;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace hass_workstation_service.Domain.Sensors
{
    public class ActiveWindowSensor : AbstractSensor
    {
        public ActiveWindowSensor(MqttPublisher publisher, int? updateInterval = null, string name = "ActiveWindow", Guid id = default(Guid)) : base(publisher, name ?? "ActiveWindow", updateInterval ?? 10, id) { }
        public override SensorDiscoveryConfigModel GetAutoDiscoveryConfig()
        {
            return this._autoDiscoveryConfigModel ?? SetAutoDiscoveryConfigModel(new SensorDiscoveryConfigModel()
            {
                Name = this.Name,
                Unique_id = this.Id.ToString(),
                Device = this.Publisher.DeviceConfigModel,
                State_topic = $"homeassistant/{this.Domain}/{Publisher.DeviceConfigModel.Name}/{this.ObjectId}/state",
                Icon = "mdi:window-maximize",
                Availability_topic = $"homeassistant/{this.Domain}/{Publisher.DeviceConfigModel.Name}/availability"
            });
        }

        public override string GetState()
        {
            return GetActiveWindowTitle();
        }

        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        private string GetActiveWindowTitle()
        {
            const int nChars = 256;
            StringBuilder Buff = new StringBuilder(nChars);
            IntPtr handle = GetForegroundWindow();

            if (GetWindowText(handle, Buff, nChars) > 0)
            {
                return Buff.ToString();
            }
            return null;
        }
    }
}
