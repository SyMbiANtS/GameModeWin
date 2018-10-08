using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace GameModeWin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ConfigRegistryClass crc = new ConfigRegistryClass();
        public ConfigServices csrv = new ConfigServices();
        public ConfigDiag cfd = new ConfigDiag();

        public MainWindow()
        {
            InitializeComponent();
            createRegSettings();
            readRegSettings();
        }

        private void bON_Click(object sender, RoutedEventArgs e)
        {
            try  {

                RegistryKey keySettings = Registry.CurrentUser.OpenSubKey("System\\GameConfigStore\\GameMode", true);
            if ( keySettings.GetValue("GM").Equals("0") )
            {
                


                    if (cb101.IsChecked == true)
                    {
                        crc.setFetch();
                    }

                    if (cb102.IsChecked == true)
                    {
                        crc.setTCPNodelay();
                    }

                    if (cb103.IsChecked == true)
                    {
                        crc.setCacheUDP();
                    }
                    if (cb104.IsChecked == true)
                    {
                        crc.setTCPIP();
                    }
                    if (cb105.IsChecked == true)
                    {
                        cfd.notifyOff();
                    }
                    if (cb106.IsChecked == true)
                    {
                        csrv.updateOff();
                        csrv.updateStoreOff();
                    }
                    if (cb107.IsChecked == true)
                    {
                        csrv.setTime();
                    }
                    if (cb108.IsChecked == true)
                    {
                        csrv.defenderOff();
                    }
                    if (cb109.IsChecked == true)
                    {
                        csrv.defLocalOverON();
                    }
                    if (cb110.IsChecked == true)
                    {
                        cfd.indxOff();
                        cfd.disableWsearch();
                    }
                    if (cb111.IsChecked == true)
                    {
                        cfd.disableTelemtry();
                        cfd.disDiag();
                        cfd.stopTelemetry();
                    }
                    if (cb112.IsChecked == true)
                    {
                        cfd.disableCortana();
                    }
                    if (cb113.IsChecked == true)
                    {
                        cfd.clrOff();
                    }
                    if (cb114.IsChecked == true)
                    {
                        cfd.appCompatOff();
                    }




                    writeRegSettings();
                    keySettings.SetValue("GM", "1");
                    readRegSettings();

                
            }
            }
            catch (Exception ex2)
            {
                MessageBox.Show(ex2.ToString(), "Error ON");
            }
        }

        private void bOFF_Click(object sender, RoutedEventArgs e)
        {
            try { 


            RegistryKey keySettings = Registry.CurrentUser.OpenSubKey("System\\GameConfigStore\\GameMode", true);
                if (keySettings.GetValue("GM").Equals("1"))
                {

                    if (cb201.IsChecked == true)
                    {
                        crc.unsetFetch();
                    }

                    if (cb202.IsChecked == true)
                    {
                        crc.unsetTCPNodelay();
                    }

                    if (cb203.IsChecked == true)
                    {
                        crc.unsetCacheUDP();
                    }
                    if (cb204.IsChecked == true)
                    {
                        crc.unsetTCPIP();
                    }
                    if (cb205.IsChecked == true)
                    {
                        cfd.notifyOn();
                    }
                    if (cb206.IsChecked == true)
                    {
                        csrv.updateOn();
                        csrv.updateStoreOn();
                    }
                    if (cb207.IsChecked == true)
                    {
                        csrv.unsetTime();
                    }
                    if (cb208.IsChecked == true)
                    {
                        csrv.defenderOn();
                    }
                    if (cb209.IsChecked == true)
                    {
                        csrv.defLocalOverOFF();
                    }
                    if (cb210.IsChecked == true)
                    {
                        cfd.indxOn();
                        cfd.enableWSearch();
                    }

                    if (cb211.IsChecked == true)
                    {
                        cfd.telemetryOn();
                        cfd.enDiag();
                        cfd.startTelemetry();
                    }
                    if (cb212.IsChecked == true)
                    {
                        cfd.enableCortana();
                    }
                    if (cb213.IsChecked == true)
                    {
                        cfd.clrOn();
                    }
                    if (cb214.IsChecked == true)
                    {
                        cfd.appCompatOn();
                    }



                    keySettings.SetValue("GM", "0");

                    writeRegSettings();
                    readRegSettings();

                
            }


            }
            catch (Exception ex1)
            {
                MessageBox.Show(ex1.ToString(), "Error Off");
            }
        }





        public void createRegSettings()
        {


            RegistryKey keySettings = Registry.CurrentUser.OpenSubKey("System\\GameConfigStore", true);
            if (keySettings.OpenSubKey("GameMode") == null)
            {
                keySettings.CreateSubKey("GameMode");

                keySettings = Registry.CurrentUser.OpenSubKey("System\\GameConfigStore\\GameMode", true);

                keySettings.SetValue("Superfetch", "1");
                keySettings.SetValue("udpCache", "1");
                keySettings.SetValue("tcpParam", "1");
                keySettings.SetValue("tcpNoDelay", "1");
                keySettings.SetValue("TimeBroker", "1");
                keySettings.SetValue("Notification", "1");
                keySettings.SetValue("WinUpdate", "1");
                keySettings.SetValue("Defender", "1");
                keySettings.SetValue("LocalOverride", "1");
                keySettings.SetValue("indexing", "1");
                keySettings.SetValue("Telemetry", "1");
                keySettings.SetValue("Cortana", "1");
                keySettings.SetValue("netOpt", "1");
                keySettings.SetValue("appCompat", "1");
                keySettings.SetValue("GM", "0");

            }

            ///TODO
            ///This origin subkey is for later update to read first values, that have been set in system
            ///now just setzero and make it TODO

            keySettings.OpenSubKey("System\\GameConfigStore", true);
            if (keySettings.OpenSubKey("Original") == null)
            {
                keySettings.CreateSubKey("Original");

                keySettings = Registry.CurrentUser.OpenSubKey("System\\GameConfigStore\\Original", true);

                keySettings.SetValue("Superfetch", "0");
                keySettings.SetValue("udpCache", "0");
                keySettings.SetValue("tcpParam", "0");
                keySettings.SetValue("tcpNoDelay", "0");
                keySettings.SetValue("TimeBroker", "0");
                keySettings.SetValue("Notification", "0");
                keySettings.SetValue("WinUpdate", "0");
                keySettings.SetValue("Defender", "0");
                keySettings.SetValue("LocalOverride", "0");
                keySettings.SetValue("indexing", "0");
                keySettings.SetValue("Telemetry", "0");
                keySettings.SetValue("Cortana", "0");
                keySettings.SetValue("netOpt", "0");
                keySettings.SetValue("appCompat", "0");
                keySettings.SetValue("GM", "0");

            }
            keySettings.Close();
        }


        public void readRegSettings()
        {
            RegistryKey keySettings = Registry.CurrentUser.OpenSubKey("System\\GameConfigStore\\GameMode", true);

            if (keySettings.GetValue("GM") == null)
            {
                keySettings.SetValue("GM", "0");
            }



            if (keySettings.GetValue("GM").Equals("0"))
            {
                bOFF.Content = "Stopped";
                bON.Content = "ON";
            }
            else if (keySettings.GetValue("GM").Equals("1"))
            {
                bON.Content = "Active";
                bOFF.Content = "OFF";
            }




            if (keySettings.GetValue("Superfetch").Equals("0"))
            {
                cb101.IsChecked = false ;
                cb201.IsChecked = false;
            }

            if (keySettings.GetValue("tcpNoDelay").Equals("0"))
            {
                cb102.IsChecked = false;
                cb202.IsChecked = false;
            }

            if (keySettings.GetValue("udpCache").Equals("0"))
            {
                cb103.IsChecked = false;
                cb203.IsChecked = false;
            }

            if (keySettings.GetValue("tcpParam").Equals("0"))
            {
                cb104.IsChecked = false;
                cb204.IsChecked = false;
            }

            if (keySettings.GetValue("Notification").Equals("0"))
            {
                cb105.IsChecked = false;
                cb205.IsChecked = false;
            }

            if (keySettings.GetValue("WinUpdate").Equals("0"))
            {
                cb106.IsChecked = false;
                cb206.IsChecked = false;
            }

            if (keySettings.GetValue("TimeBroker").Equals("0"))
            {
                cb107.IsChecked = false;
                cb207.IsChecked = false;
            }

            if (keySettings.GetValue("Defender").Equals("0"))
            {
                cb108.IsChecked = false;
                cb208.IsChecked = false;
            }

            if (keySettings.GetValue("LocalOverride").Equals("0"))
            {
                cb109.IsChecked = false;
                cb209.IsChecked = false;
            }
            if (keySettings.GetValue("indexing").Equals("0"))
            {
                cb110.IsChecked = false;
                cb210.IsChecked = false;
            }

            if (keySettings.GetValue("Cortana") == null)
            {
                keySettings.SetValue("Cortana", "0");
            }
            if (keySettings.GetValue("appCompat") == null)
            {
                keySettings.SetValue("appCompat", "0");
            }
            if (keySettings.GetValue("netOpt") == null)
            {
                keySettings.SetValue("netOpt", "0");
            }
            if (keySettings.GetValue("Telemetry") == null)
            {
                keySettings.SetValue("Telemetry", "0");
            }


            if (keySettings.GetValue("Telemetry").Equals("0"))
            {
                cb111.IsChecked = false;
                cb211.IsChecked = false;
            }

            if (keySettings.GetValue("Cortana").Equals("0"))
            {
                cb112.IsChecked = false;
                cb212.IsChecked = false;
            }

            if (keySettings.GetValue("netOpt").Equals("0"))
            {
                cb113.IsChecked = false;
                cb213.IsChecked = false;
            }

            if (keySettings.GetValue("appCompat").Equals("0"))
            {
                cb114.IsChecked = false;
                cb214.IsChecked = false;
            }




            keySettings.Close();

        }

        private void writeRegSettings()
        {


            RegistryKey keySettings = Registry.CurrentUser.OpenSubKey("System\\GameConfigStore\\GameMode", true);
            

            if (cb101.IsChecked == true)
            {
                keySettings.SetValue("Superfetch", "1");
            }  else   {
                keySettings.SetValue("Superfetch", "0");
            }

            if (cb102.IsChecked == true)
            {
                keySettings.SetValue("tcpNoDelay", "1");
            }
            else
            {
                keySettings.SetValue("tcpNoDelay", "0");
            }


            if (cb103.IsChecked == true)
            {
                keySettings.SetValue("udpCache", "1");
            }  else   {
                keySettings.SetValue("udpCache", "0");
            }


            if (cb104.IsChecked == true)
            {
                keySettings.SetValue("tcpParam", "1");
            }  else   {
                keySettings.SetValue("tcpParam", "0");
            }


            if (cb105.IsChecked == true)
            {
                keySettings.SetValue("Notification", "1");
            }
            else
            {
                keySettings.SetValue("Notification", "0");
            }


            if (cb106.IsChecked == true)
            {
                keySettings.SetValue("WinUpdate", "1");
            }
            else
            {
                keySettings.SetValue("WinUpdate", "0");
            }



            if (cb107.IsChecked == true)
            {
                keySettings.SetValue("TimeBroker", "1");
            }  else   {
                keySettings.SetValue("TimeBroker", "0");
            }

            
            if (cb108.IsChecked == true)
            {
                keySettings.SetValue("Defender", "1");
            }
            else
            {
                keySettings.SetValue("Defender", "0");
            }


            if (cb109.IsChecked == true)
            {
                keySettings.SetValue("LocalOverride", "1");
            }
            else
            {
                keySettings.SetValue("LocalOverride", "0");
            }


            if (cb110.IsChecked == true)
            {
                keySettings.SetValue("indexing", "1");
            }
            else
            {
                keySettings.SetValue("indexing", "0");
            }

            if (cb111.IsChecked == true)
            {
                keySettings.SetValue("Telemetry", "1");
            }
            else
            {
                keySettings.SetValue("Telemetry", "0");
            }

            if (cb112.IsChecked == true)
            {
                keySettings.SetValue("Cortana", "1");
            }
            else
            {
                keySettings.SetValue("Cortana", "0");
            }

            if (cb113.IsChecked == true)
            {
                keySettings.SetValue("netOpt", "1");
            }
            else
            {
                keySettings.SetValue("netOpt", "0");
            }

            if (cb114.IsChecked == true)
            {
                keySettings.SetValue("appCompat", "1");
            }
            else
            {
                keySettings.SetValue("appCompat", "0");
            }

            keySettings.Close();


        }







        ///disable firewall
        /// [HKLM\SYSTEM\CurrentControlSet\Services\SharedAccess\Parameters\FirewallPolicy\StandardProfile]
        /// "EnableFirewall" = dword:00000000


        /// <summary>
        /// Site links mouse dbl click
        /// </summary>


        private void SymbLabel_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start("http://dev.symbiants.com");
        }

        private void SpeedLabel_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.speedguide.net/downloads.php");
        }

        private void SteamLabel_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start("http://steamcommunity.com/groups/symbiants#announcements/detail/823418975648280408");
        }

        private void Steam2Label_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start("http://steamcommunity.com/sharedfiles/filedetails/?id=476760198"); 
        }




        //[System.Runtime.InteropServices.DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
        //internal static extern bool ExitWindowsEx(int flg, int rea);

        private void bReboot_Click(object sender, RoutedEventArgs e)
        {
           
            //ExitWindowsEx(0x00000002, 0);

        }

        private void bReboot_Click_1(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("shutdown", "/r /t 5 /d P:2:4 /c  \"System reboot to apply GameMode\"");
        }
    }
}
