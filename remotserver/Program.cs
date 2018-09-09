using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using RemotSeates;
namespace remotserver
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpChannel channel = new HttpChannel(9000);
            ChannelServices.RegisterChannel(channel, false);
            RemotingConfiguration.RegisterWellKnownServiceType(
                typeof(Remotticket),
                "Room_Service_Url",
                WellKnownObjectMode.Singleton);
            L:
            Console.WriteLine("Server is running, Press Enter exit then enter to exist server");
            string input = Console.ReadLine();
            if (input == "exit")
                return;
            else
                goto L;
           
        }
    }
}
