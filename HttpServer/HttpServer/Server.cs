using HttpServer.Enums;
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

            HttpRequestMessage request = new HttpRequestMessage(data);

            //TODO: Interpretar URI, si existe cargar el HTML como string
            HttpResponseMessage httpResponse = ConstructMessage.ConstructResponseMessage(request.HTTPVersion, request.RequestURI);
            string response = httpResponse.GenerateHttpResponse();

            Program.AddLog(response);

            byte[] responseBytes = Encoding.ASCII.GetBytes(response);
            client.BeginSend(responseBytes, 0, responseBytes.Length, SocketFlags.None, new AsyncCallback(SendCallback), client);


        }

        private void SendCallback(IAsyncResult ar)
        {
            Socket client = (Socket)ar.AsyncState;
            client.Shutdown(SocketShutdown.Send);
        }
    }
}
