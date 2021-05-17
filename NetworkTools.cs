using System;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace CMLTools
{
    class NetworkTools
    {
      public NetworkTools()
      {

      }
      public  void getIPInfo()
      {
          Console.WriteLine();
          Console.WriteLine("--------------- Information ----------------");
          String strHostName = string.Empty;
        
          strHostName = Dns.GetHostName();
          Console.ForegroundColor = ConsoleColor.DarkGreen;
          Console.WriteLine("Computer Name : {0}",strHostName);
          Console.ResetColor();

          NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
          foreach (NetworkInterface adapter in adapters)
          { 

            if(adapter.OperationalStatus.ToString().Equals("Up"))
            {
              Console.ForegroundColor = ConsoleColor.DarkGreen;
              Console.WriteLine("[Connected.]");
            }
            else
            {
              Console.ForegroundColor = ConsoleColor.Red;
              Console.WriteLine("[Disconnect.]");
            }
            NetworkInterfaceType netType = adapter.NetworkInterfaceType;
              
            Console.WriteLine("Interface[Type] : {0} [{1}]",adapter.Description,netType.ToString());
            
              foreach (UnicastIPAddressInformation unicastIPAddressInformation in adapter.GetIPProperties().UnicastAddresses)
              {
                  if (unicastIPAddressInformation.Address.AddressFamily == AddressFamily.InterNetwork)
                  {
                      Console.WriteLine("IP : {0}",unicastIPAddressInformation.Address);
                      Console.WriteLine("Netmask : {0}",unicastIPAddressInformation.IPv4Mask);
                  }
              }
              // Gateway
              IPInterfaceProperties ipInt = adapter.GetIPProperties();
              GatewayIPAddressInformationCollection gw = ipInt.GatewayAddresses;
              foreach(GatewayIPAddressInformation gateway in gw)
              {
                Console.WriteLine("gateway : {0}",gateway.Address);
              }
                Console.ResetColor();
                Console.WriteLine();
          }

      } 
        

    }//class
}


