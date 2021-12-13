﻿using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using hass_workstation_service.Communication.InterProcesCommunication.Models;
using hass_workstation_service.Communication.NamedPipe;
using JKang.IpcServiceFramework.Client;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Dynamic;
using System.Linq;
using System.Text.Json;
using UserInterface.Util;
using UserInterface.ViewModels;

namespace UserInterface.Views
{
    public class AddSensorDialog : Window
    {
        private readonly IIpcClient<ServiceContractInterfaces> client;
        public ComboBox comboBox { get; set; }
        public ComboBox detectionModecomboBox { get; set; }
        public AddSensorDialog()
        {
            this.InitializeComponent();
            DataContext = new AddSensorViewModel();
            this.comboBox = this.FindControl<ComboBox>("ComboBox");
            this.comboBox.Items = Enum.GetValues(typeof(AvailableSensors)).Cast<AvailableSensors>().OrderBy(v => v.ToString());
            this.comboBox.SelectedIndex = 0;

            // register IPC clients
            ServiceProvider serviceProvider = new ServiceCollection()
                .AddNamedPipeIpcClient<ServiceContractInterfaces>("addsensor", pipeName: "pipeinternal")
                .BuildServiceProvider();

            // resolve IPC client factory
            IIpcClientFactory<ServiceContractInterfaces> clientFactory = serviceProvider
                .GetRequiredService<IIpcClientFactory<ServiceContractInterfaces>>();

            // create client
            this.client = clientFactory.CreateClient("addsensor");
        }

        public async void Save(object sender, RoutedEventArgs args)
        {
            var item = ((AddSensorViewModel)this.DataContext);
            dynamic model = new { item.Name, item.Query, item.UpdateInterval, item.WindowName};
            string json = JsonSerializer.Serialize(model);
            await this.client.InvokeAsync(x => x.AddSensor(item.SelectedType, json));
            Close();
        }

        public void ComboBoxClosed(object sender, SelectionChangedEventArgs args)
        {
            var item = ((AddSensorViewModel)this.DataContext);
            switch (this.comboBox.SelectedItem)
            {
                case AvailableSensors.UserNotificationStateSensor:
                    item.Description = "This sensor watches the UserNotificationState. This is normally used in applications to determine if it is appropriate to send a notification but we can use it to expose this state. \n ";
                    item.MoreInfoLink = "https://github.com/sleevezipper/hass-workstation-service#usernotificationstate";
                    item.ShowDetectionModeOptions = false;
                    item.ShowQueryInput = false;
                    item.ShowWindowNameInput = false;
                    item.UpdateInterval = 5;
                    break;
                case AvailableSensors.DummySensor:
                    item.Description = "This sensor spits out a random number every second. Useful for testing, maybe you'll find some other use for it.";
                    item.MoreInfoLink = "https://github.com/sleevezipper/hass-workstation-service#dummy";
                    item.ShowDetectionModeOptions = false;
                    item.ShowQueryInput = false;
                    item.ShowWindowNameInput = false;
                    item.UpdateInterval = 1;
                    break;
                case AvailableSensors.CPULoadSensor:
                    item.Description = "This sensor checks the current CPU load. It averages the load on all logical cores every second and rounds the output to two decimals.";
                    item.MoreInfoLink = "https://github.com/sleevezipper/hass-workstation-service#cpuload";
                    item.ShowDetectionModeOptions = false;
                    item.ShowQueryInput = false;
                    item.ShowWindowNameInput = false;
                    item.UpdateInterval = 5;
                    break;
                case AvailableSensors.CurrentClockSpeedSensor:
                    item.Description = "This sensor returns the BIOS configured baseclock for the processor.";
                    item.MoreInfoLink = "https://github.com/sleevezipper/hass-workstation-service#currentclockspeed";
                    item.ShowDetectionModeOptions = false;
                    item.ShowQueryInput = false;
                    item.ShowWindowNameInput = false;
                    item.UpdateInterval = 3600;
                    break;
                case AvailableSensors.WMIQuerySensor:
                    item.Description = "This advanced sensor executes a user defined WMI query and exposes the result. The query should return a single value.";
                    item.MoreInfoLink = "https://github.com/sleevezipper/hass-workstation-service#wmiquerysensor";
                    item.ShowDetectionModeOptions = false;
                    item.ShowQueryInput = true;
                    item.ShowWindowNameInput = false;
                    item.UpdateInterval = 10;
                    break;
                case AvailableSensors.MemoryUsageSensor:
                    item.Description = "This sensor calculates the percentage of used memory.";
                    item.MoreInfoLink = "https://github.com/sleevezipper/hass-workstation-service#usedmemory";
                    item.ShowDetectionModeOptions = false;
                    item.ShowQueryInput = false;
                    item.ShowWindowNameInput = false;
                    item.UpdateInterval = 10;
                    break;
                case AvailableSensors.ActiveWindowSensor:
                    item.Description = "This sensor exposes the name of the currently active window.";
                    item.MoreInfoLink = "https://github.com/sleevezipper/hass-workstation-service#activewindow";
                    item.ShowDetectionModeOptions = false;
                    item.ShowQueryInput = false;
                    item.ShowWindowNameInput = false;
                    item.UpdateInterval = 5;
                    break;
                case AvailableSensors.WebcamActiveSensor:
                    item.Description = "This sensor shows if the webcam is currently being used.";
                    item.MoreInfoLink = "https://github.com/sleevezipper/hass-workstation-service#webcamactive";
                    item.ShowDetectionModeOptions = true;
                    item.ShowQueryInput = false;
                    item.UpdateInterval = 10;
                    break;
                case AvailableSensors.MicrophoneActiveSensor:
                    item.Description = "This sensor shows if the microphone is currently in use.";
                    item.MoreInfoLink = "https://github.com/sleevezipper/hass-workstation-service#microphoneactive";
                    item.ShowDetectionModeOptions = false;
                    item.ShowQueryInput = false;
                    item.UpdateInterval = 10;
                    break;
                case AvailableSensors.NamedWindowSensor:
                    item.Description = "This sensor returns true if a window was found with the name you search for. ";
                    item.MoreInfoLink = "https://github.com/sleevezipper/hass-workstation-service#namedwindow";
                    item.ShowQueryInput = false;
                    item.ShowWindowNameInput = true;
                    item.UpdateInterval = 5;
                    break;
                case AvailableSensors.LastActiveSensor:
                    item.Description = "This sensor returns the date/time that the workstation was last active.";
                    item.MoreInfoLink = "https://github.com/sleevezipper/hass-workstation-service#lastactive";
                    item.ShowQueryInput = false;
                    item.ShowWindowNameInput = false;
                    item.UpdateInterval = 5;
                    break;
                case AvailableSensors.LastBootSensor:
                    item.Description = "This sensor returns the date/time that Windows was last booted";
                    item.MoreInfoLink = "https://github.com/sleevezipper/hass-workstation-service#lastboot";
                    item.ShowQueryInput = false;
                    item.ShowWindowNameInput = false;
                    item.UpdateInterval = 5;
                    break;
                case AvailableSensors.SessionStateSensor:
                    item.Description = "This sensor returns the state of the Windows session.";
                    item.MoreInfoLink = "https://github.com/sleevezipper/hass-workstation-service#sessionstate";
                    item.ShowQueryInput = false;
                    item.ShowWindowNameInput = false;
                    item.UpdateInterval = 5;
                    break;
                case AvailableSensors.CurrentVolumeSensor:
                    item.Description = "This sensor returns the volume of currently playing audio.";
                    item.MoreInfoLink = "https://github.com/sleevezipper/hass-workstation-service#currentvolume";
                    item.ShowQueryInput = false;
                    item.ShowWindowNameInput = false;
                    item.UpdateInterval = 5;
                    break;
                case AvailableSensors.GPUTemperatureSensor:
                    item.Description = "This sensor returns the current temperature of the GPU in °C.";
                    item.MoreInfoLink = "https://github.com/sleevezipper/hass-workstation-service#gputemperature";
                    item.ShowQueryInput = false;
                    item.ShowWindowNameInput = false;
                    item.UpdateInterval = 5;
                    break;
                case AvailableSensors.GPULoadSensor:
                    item.Description = "This sensor returns the current GPU load.";
                    item.MoreInfoLink = "https://github.com/sleevezipper/hass-workstation-service#gpuload";
                    item.ShowQueryInput = false;
                    item.ShowWindowNameInput = false;
                    item.UpdateInterval = 5;
                    break;
                default:
                    item.Description = null;
                    item.MoreInfoLink = null;
                    item.ShowQueryInput = false;
                    break;
            }
        }
        public void OpenInfo(object sender, RoutedEventArgs args)
        {
            var item = ((AddSensorViewModel)this.DataContext);
            BrowserUtil.OpenBrowser(item.MoreInfoLink);
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
