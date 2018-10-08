using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;


namespace GameModeWin
{
    public class ConfigServices
    {
        /// <summary>
        /// Set TimeBroker
        /// </summary>

        public void setTime()
        {
            RegistryKey servicePath01 = Registry.LocalMachine.OpenSubKey("System\\CurrentControlSet\\Services\\TimeBrokerSvc", true);

            servicePath01.SetValue("Start", 4);
            servicePath01.Close();
        }

        public void unsetTime()
        {
            RegistryKey servicePath01 = Registry.LocalMachine.OpenSubKey("System\\CurrentControlSet\\Services\\TimeBrokerSvc", true);

            servicePath01.SetValue("Start", 3);
            servicePath01.Close();
        }

        /// <summary>
        /// Disable Windows Defender
        /// </summary>

        public void defenderOff()
        {
            RegistryKey servicePath02 = Registry.LocalMachine.OpenSubKey("Software\\Policies\\Microsoft\\Windows Defender", true);

            if (servicePath02.GetValue("DisableAntiSpyware") != null)
            {
                servicePath02.SetValue("DisableAntiSpyware", 1);
            }
            servicePath02.Close();
        }

        public void defenderOn()
        {
            RegistryKey servicePath02 = Registry.LocalMachine.OpenSubKey("Software\\Policies\\Microsoft\\Windows Defender", true);
            if (servicePath02.GetValue("DisableAntiSpyware") != null)
            { 
                 servicePath02.DeleteValue("DisableAntiSpyware");
            }
            servicePath02.Close();
        }


        /// <summary>
        /// Local Override for Windows Defender
        /// </summary>

        public void defLocalOverON()
        {
            RegistryKey servicePath = Registry.LocalMachine.OpenSubKey("Software\\Policies\\Microsoft\\Windows Defender", true);

            if (servicePath.OpenSubKey("Real-Time Protection") == null)
            {
                servicePath.Close();
                RegistryKey sp = Registry.LocalMachine.OpenSubKey("Software\\Policies\\Microsoft\\Windows Defender", true);
                sp = sp.CreateSubKey("Real-Time Protection");

                sp.Close();
                servicePath = Registry.LocalMachine.OpenSubKey("Software\\Policies\\Microsoft\\Windows Defender\\Real-Time Protection", true);
            }

            servicePath.SetValue("DisableBehaviorMonitoring", 1);
            servicePath.SetValue("DisableOnAccessProtection", 1);
            servicePath.SetValue("DisableRealtimeMonitoring", 1);
       ///  servicePath.SetValue("LocalSettingOverrideRealtimeScanDirection", 1);
            servicePath.Close();
        }

        public void defLocalOverOFF()
        {
            RegistryKey servicePath = Registry.LocalMachine.OpenSubKey("Software\\Policies\\Microsoft\\Windows Defender", true);

            if (servicePath.OpenSubKey("Real-Time Protection") != null)
            {
                servicePath.DeleteSubKey("Real-Time Protection");
            }

        ///    servicePath.DeleteValue("DisableBehaviorMonitoring");
        ///    servicePath.DeleteValue("DisableOnAccessProtection");
        ///    servicePath.DeleteValue("DisableRealtimeMonitoring");
        /// servicePath.DeleteValue("LocalSettingOverrideRealtimeScanDirection");
            servicePath.Close();
        }

        /// <summary>
        /// Disable AutoUpdate
        /// </summary>

        public void updateOff()
        {
            RegistryKey servicePath = Registry.LocalMachine.OpenSubKey("Software\\Policies\\Microsoft\\Windows", true);

            if (servicePath.OpenSubKey("WindowsUpdate") == null)
            {
                servicePath.Close();
                RegistryKey sp = Registry.LocalMachine.OpenSubKey("Software\\Policies\\Microsoft\\Windows", true);
                sp = sp.CreateSubKey("WindowsUpdate");
                
                sp.Close();

                RegistryKey sp2 = Registry.LocalMachine.OpenSubKey("Software\\Policies\\Microsoft\\Windows\\WindowsUpdate", true);
                    if (sp2.OpenSubKey("AU") == null)
                    {
                        sp2.CreateSubKey("AU");
                    sp2.Close();
                }
                servicePath = Registry.LocalMachine.OpenSubKey("Software\\Policies\\Microsoft\\Windows", true);
            }

            RegistryKey sp3 = Registry.LocalMachine.OpenSubKey("Software\\Policies\\Microsoft\\Windows\\WindowsUpdate", true);
            if (sp3.OpenSubKey("AU") == null)
            {
                sp3.CreateSubKey("AU");
                sp3.Close();
            }

            servicePath = servicePath.OpenSubKey("WindowsUpdate\\AU", true);

            servicePath.SetValue("NoAutoUpdate", 1);
            servicePath.Close();
        }

        public void updateOn()
        {
            RegistryKey servicePath = Registry.LocalMachine.OpenSubKey("Software\\Policies\\Microsoft\\Windows\\WindowsUpdate\\AU", true);

            servicePath.DeleteValue("NoAutoUpdate");
            servicePath.Close();
        }

        /// <summary>
        /// Disable Windows Store AutoUpdate
        /// </summary>

        public void updateStoreOff()
        {
            RegistryKey servicePath = Registry.LocalMachine.OpenSubKey("Software\\Policies\\Microsoft", true);
            
            if (servicePath.OpenSubKey("WindowsStore") == null)
            {
                servicePath.Close();
                RegistryKey sp = Registry.LocalMachine.OpenSubKey("Software\\Policies\\Microsoft", true);
                sp = sp.CreateSubKey("WindowsStore");
                sp.Close();
                servicePath = Registry.LocalMachine.OpenSubKey("Software\\Policies\\Microsoft", true);
            }

            servicePath = servicePath.OpenSubKey("WindowsStore", true);
            servicePath.SetValue("AutoDownload", 2);
            servicePath.Close();
        }

        public void updateStoreOn()
        {
            RegistryKey servicePath = Registry.LocalMachine.OpenSubKey("Software\\Policies\\Microsoft\\WindowsStore", true);

            servicePath.DeleteValue("AutoDownload");
            servicePath.Close();
        }



    }
}
