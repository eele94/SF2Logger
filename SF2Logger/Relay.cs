using BrunoGarcia.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SF2Logger
{
    public class Relay
    {
        public event EventHandler<SF2EventArgs> clientReceivedData;
        public event EventHandler<SF2EventArgs> serverReceivedData;

        public string IP { get; set; }

        public Relay(string remoteIP, int remotePort, string localIP, int localPort)
        {
            this.IP = String.Format(remoteIP + ":" + remotePort);

            IPEndPoint local = new IPEndPoint(IPAddress.Parse(localIP), localPort);
            IPEndPoint remote = new IPEndPoint(IPAddress.Parse(remoteIP), remotePort);

            TcpForwarderSlim forwarder = new TcpForwarderSlim(this);

            Thread myNewThread = new Thread(() => forwarder.Start(local, remote));
            myNewThread.Start();
        }

        public void receiveClientData(byte[] data)
        {
            Console.WriteLine("@! receive client data!");
            var new_data = data.TakeWhile((v, index) => data.Skip(index).Any(w => w != 0x00)).ToArray();
            clientReceivedData(null, new SF2EventArgs(this.IP, new_data));
        }

        public void receiveServerData(byte[] data)
        {
            Console.WriteLine("@! receive server data!");
            var new_data = data.TakeWhile((v, index) => data.Skip(index).Any(w => w != 0x00)).ToArray();
            serverReceivedData(null, new SF2EventArgs(this.IP, new_data));
        }

    }
    public class SF2EventArgs : EventArgs
    {
        public byte[] Data { get; set; }
        public string Server { get; set; }
        public SF2EventArgs(string server, byte[] data)
        {
            this.Data = data;
            this.Server = server;
        }
    }
}
