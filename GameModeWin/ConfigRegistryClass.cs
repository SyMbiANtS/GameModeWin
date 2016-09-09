using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.Windows;

namespace GameModeWin
{
    public class ConfigRegistryClass 

    {


        /// <summary>
        /// Set Superfetch and Prefetch + Service
        /// </summary>

        public void setFetch()
        {
            RegistryKey keyPath = Registry.LocalMachine.OpenSubKey("System\\CurrentControlSet\\Control\\Session Manager\\Memory Management\\PrefetchParameters", true);

            keyPath.SetValue("EnablePrefetcher", 0);
            keyPath.SetValue("EnableSuperfetch", 0);

            RegistryKey servicePath = Registry.LocalMachine.OpenSubKey("System\\CurrentControlSet\\Services\\SysMain", true);

            servicePath.SetValue("Start", 4);
            servicePath.Close();
            keyPath.Close();
        }

        public void unsetFetch()
        {
            RegistryKey keyPath = Registry.LocalMachine.OpenSubKey("System\\CurrentControlSet\\Control\\Session Manager\\Memory Management\\PrefetchParameters", true);

            keyPath.SetValue("EnablePrefetcher", 3);
            keyPath.SetValue("EnableSuperfetch", 1);

            RegistryKey servicePath = Registry.LocalMachine.OpenSubKey("System\\CurrentControlSet\\Services\\SysMain", true);

            servicePath.SetValue("Start", 3);
            servicePath.Close();
            keyPath.Close();

        }




        /// <summary>
        /// Set Cache and UDP ??? defaults?
        /// </summary>

        public void setCacheUDP()
        {
            RegistryKey servicePath = Registry.LocalMachine.OpenSubKey("System\\CurrentControlSet\\Services\\Dnscache\\Parameters", true);

            servicePath.SetValue("NegativeCacheTime", 0);
            servicePath.SetValue("NegativeSOACacheTime", 0);
            servicePath.SetValue("NetFailureCacheTime", 0);
            servicePath.SetValue("MaximumUdpPacketSize", 512);

            servicePath.Close();
        }

        public void unsetCacheUDP()
        {
            RegistryKey servicePath = Registry.LocalMachine.OpenSubKey("System\\CurrentControlSet\\Services\\Dnscache\\Parameters", true);

            servicePath.SetValue("NegativeCacheTime", 600);
            servicePath.SetValue("NegativeSOACacheTime", 300);
            servicePath.SetValue("NetFailureCacheTime", 120);
            servicePath.SetValue("MaximumUdpPacketSize", 1472);

            servicePath.Close();
        }

        /// <summary>
        /// TcpNodelay enable
        /// </summary>

        public void setTCPNodelay()
        {
            RegistryKey keyPath = Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Windows NT\\CurrentVersion\\Multimedia\\SystemProfile", true);

            keyPath.SetValue("NetworkThrottlingIndex", "ffffffff", RegistryValueKind.DWord);
            keyPath.SetValue("SystemResponsiveness", 0);
            keyPath.Close();

            RegistryKey keyPath1 = Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\MSMQ\\Parameters", true);
            
            keyPath1.SetValue("TcpNoDelay", 1);
            keyPath1.Close();

        }

        public void unsetTCPNodelay()
        {
            RegistryKey keyPath = Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Windows NT\\CurrentVersion\\Multimedia\\SystemProfile", true);

            keyPath.SetValue("NetworkThrottlingIndex", 10);
            keyPath.SetValue("SystemResponsiveness", 14);
            keyPath.Close();

            RegistryKey keyPath1 = Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\MSMQ\\Parameters", true);

            keyPath1.SetValue("TcpNoDelay", 0);
            keyPath1.Close();
        }

        /// <summary>
        /// TcpIP tweaks
        /// https://technet.microsoft.com/en-us/library/cc957549.aspx?f=255&MSPPError=-2147217396
        /// </summary>

        public void setTCPIP()
        {
            RegistryKey keyPath = Registry.LocalMachine.OpenSubKey("System\\CurrentControlSet\\Services\\Tcpip\\Parameters", true);

            keyPath.SetValue("DefaultTTL", 40);
            keyPath.SetValue("KeepAliveTime", "493E0", RegistryValueKind.DWord); //300 000 ms = 5min
            keyPath.SetValue("MaxUserPort", 65534, RegistryValueKind.DWord);
            keyPath.SetValue("QualifyingDestinationThreshold", 3);
            keyPath.SetValue("SynAttackProtect", 1);
            keyPath.SetValue("Tcp1323Opts", 1);
            keyPath.SetValue("TcpCreateAndConnectTcbRateLimitDepth", 0);
            keyPath.SetValue("TcpMaxDataRetransmissions", 5);
            
            keyPath.Close();



        }

        public void unsetTCPIP()
        {
            RegistryKey keyPath = Registry.LocalMachine.OpenSubKey("System\\CurrentControlSet\\Services\\Tcpip\\Parameters", true);

            keyPath.SetValue("DefaultTTL", 128, RegistryValueKind.DWord);
            keyPath.SetValue("KeepAliveTime", "6DDD00", RegistryValueKind.DWord);
            keyPath.SetValue("MaxUserPort", 5000, RegistryValueKind.DWord);
            keyPath.SetValue("QualifyingDestinationThreshold", 3, RegistryValueKind.DWord);
            keyPath.SetValue("SynAttackProtect", 0, RegistryValueKind.DWord);
            keyPath.SetValue("Tcp1323Opts", 3, RegistryValueKind.DWord);
            keyPath.SetValue("TcpCreateAndConnectTcbRateLimitDepth", 1, RegistryValueKind.DWord);
            keyPath.SetValue("TcpMaxDataRetransmissions", 5, RegistryValueKind.DWord);

            keyPath.Close();
        }


    }
}
