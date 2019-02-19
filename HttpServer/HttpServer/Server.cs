using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace HttpServer
{


    class Server
    {
        private Socket serverSocket = null;
        private int port = 8080;
        private int backlog = 5;
        List<Socket> clients = new List<Socket>();
        Byte[] buffer = new Byte[1024];

        //8private Program context = null;

        public Server(Program cntxt)
        {
            //context = cntxt;
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Start();
        }

        public void Start()
        {
            serverSocket.Bind(new IPEndPoint(IPAddress.Any, port));
            serverSocket.Listen(backlog);
            Accept();
        }

        public void Accept()
        {
            serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), null);
        }

        private void AcceptCallback(IAsyncResult ar)
        {
            Socket client = serverSocket.EndAccept(ar);
            clients.Add(client);
            client.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(ReciveCallback), client);
            Accept();
            Program.AddLog(ar.ToString());
        }

        private void ReciveCallback(IAsyncResult ar)
        {
            Socket client = (Socket)ar.AsyncState;
            int size = client.EndReceive(ar);
            Byte[] RecivedBytes = new Byte[size];
            Array.Copy(buffer, RecivedBytes, size);
            String data = Encoding.ASCII.GetString(RecivedBytes);
            Program.AddLog(data);

            String response = String.Format("{0}{11}{1}{11}{2}{11}{3}{11}{4}{11}{5}{11}{6}{11}{7}{11}{8}{11}{9}{11}{11}{10}{11}",
                "HTTP/1.1 308 Permanent Redirect",
                "Date: Sun, 17 Feb 2019 02:25:19 GMT",
                "Transfer - Encoding: chunked",
                "  Connection: keep - alive",
                "Cache - Control: max - age = 3600",
                "Expires: Sun, 17 Feb 2019 03:25:19 GMT",
                "Location: http://www.holamundo.com",
                "        Vary: Accept - Encoding",
                "Server: cloudflare",
                "CF - RAY: 4aa4cd7e8e49b937 - MIA",
                "<h1>estado OK</h1>", Environment.NewLine);

            Byte[] responseBytes = Encoding.ASCII.GetBytes(response);
            client.BeginSend(responseBytes, 0, responseBytes.Length, SocketFlags.None, new AsyncCallback(SendCallback), client);


        }

        private void SendCallback(IAsyncResult ar)
        {
            Socket client = (Socket)ar.AsyncState;
            client.Shutdown(SocketShutdown.Send);
        }
    }
}
