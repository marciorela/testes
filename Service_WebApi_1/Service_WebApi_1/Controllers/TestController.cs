using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Service_WebApi_1.Controllers
{
    public enum MonitorState
    {
        MonitorStateOn = -1,
        MonitorStateOff = 2,
        MonitorStateStandBy = 1
    }

    [ApiController]
    [Route("[controller]/[action]")]
    public class TestController : ControllerBase
    {
        private const int HWND_BROADCAST = 0xFFFF;//the message is sent to all    
        private const int SC_MONITORPOWER = 0xF170;
        private const int WM_SYSCOMMAND = 0x112;

        [HttpGet]
        public IActionResult Calc()
        {
            try
            {
                System.Diagnostics.Process p = System.Diagnostics.Process.Start("calc.exe");
                p.WaitForInputIdle();
                //NativeMethods.SetParent(p.MainWindowHandle, this.Handle);
                return Ok("Executado");
            }
            catch (Exception e)
            {
                return Forbid(e.Message);
            }
        }

        [HttpGet]
        public IActionResult MonitorOff()
        {
            try
            {
                //SendMessage(HWND_BROADCAST, WM_SYSCOMMAND, SC_MONITORPOWER, MONITOR_OFF);
                SetMonitorOff();
                return Ok("Executado");
            }
            catch (Exception e)
            {
                return Forbid(e.Message);
            }
        }

        [DllImport("user32.dll")]
        //static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
        private static extern int SendMessage(int hWnd, int hMsg, int wParam, int lParam);

        private void SetMonitorOn()
        {
            SetMonitorInState(MonitorState.MonitorStateOn);
        }

        private void SetMonitorOff()
        {
            SetMonitorInState(MonitorState.MonitorStateOff);
        }

        private void SetMonitorInState(MonitorState state)
        {
            SendMessage(HWND_BROADCAST, WM_SYSCOMMAND, SC_MONITORPOWER, (int)state);
        }
    }
}
