using SF2Logger;
using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace BrunoGarcia.Net
{
    public class TcpForwarderSlim
    {
        public Relay Relayer { get; set; }
        public TcpForwarderSlim(Relay relay)
        {
            this.Relayer = relay;
        }

        private readonly Socket MainSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        public void Start(IPEndPoint local, IPEndPoint remote)
        {
            MainSocket.Bind(local);
            MainSocket.Listen(10);

            while (true)
            {
                var source = MainSocket.Accept();
                var destination = new TcpForwarderSlim(this.Relayer);
                var state = new State(source, destination.MainSocket, this.Relayer);

                destination.Connect(remote, source, this.Relayer);
                source.BeginReceive(state.Buffer, 0, state.Buffer.Length, 0, OnSourceDataReceive, state);
            }
        }

        private void Connect(EndPoint remoteEndpoint, Socket destination, Relay relay)
        {
            var state = new State(MainSocket, destination, relay);
            MainSocket.Connect(remoteEndpoint);
            MainSocket.BeginReceive(state.Buffer, 0, state.Buffer.Length, SocketFlags.None, OnDestDataReceive, state);
        }

        private void OnSourceDataReceive(IAsyncResult result)
        {
            Console.WriteLine("On Source Data received...");
            var state = (State)result.AsyncState;
            try
            {
                var bytesRead = state.SourceSocket.EndReceive(result);
                if (bytesRead > 0)
                {
                    state.Relayer.receiveClientData(state.Buffer);

                    OnSourceDataSend(result, bytesRead);
                }
            }
            catch
            {
                state.DestinationSocket.Close();
                state.SourceSocket.Close();
            }
        }

        private void OnSourceDataSend(IAsyncResult result, int bytesRead)
        {
            Console.WriteLine("On Source Data send...");
            var state = (State)result.AsyncState;
            try
            {
                state.DestinationSocket.Send(state.Buffer, bytesRead, SocketFlags.None);
                state.SourceSocket.BeginReceive(state.Buffer, 0, state.Buffer.Length, 0, OnSourceDataReceive, state);
            }
            catch
            {
                state.DestinationSocket.Close();
                state.SourceSocket.Close();
            }
        }

        private void OnDestDataReceive(IAsyncResult result)
        {
            Console.WriteLine("On Dest Data received...");
            var state = (State)result.AsyncState;
            try
            {
                var bytesRead = state.SourceSocket.EndReceive(result);
                if (bytesRead > 0)
                {
                    state.Relayer.receiveServerData(state.Buffer);

                    OnDestDataSend(result, bytesRead);
                }
            }
            catch
            {
                state.DestinationSocket.Close();
                state.SourceSocket.Close();
            }
        }

        private void OnDestDataSend(IAsyncResult result, int bytesRead)
        {
            Console.WriteLine("On Dest Data send...");
            var state = (State)result.AsyncState;

            try
            {
                state.DestinationSocket.Send(state.Buffer, bytesRead, SocketFlags.None);
                state.SourceSocket.BeginReceive(state.Buffer, 0, state.Buffer.Length, 0, OnDestDataReceive, state);
            }
            catch
            {
                state.DestinationSocket.Close();
                state.SourceSocket.Close();
            }
        }


        private class State
        {
            public Socket SourceSocket { get; private set; }
            public Socket DestinationSocket { get; private set; }
            public byte[] Buffer { get; private set; }
            public Relay Relayer { get; set; }


            public State(Socket source, Socket destination, Relay relay)
            {
                SourceSocket = source;
                DestinationSocket = destination;
                Buffer = new byte[8192];
                Relayer = relay;
            }
        }
    }
}