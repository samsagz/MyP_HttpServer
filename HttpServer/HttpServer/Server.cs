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

            //pasan cosas para convertirlo en el HTML
            //request.RequestURI
            

            //metodo(request.RequestURI)









            /*
             *            
            HTTP / 1.1 200 OK
            Accept-Ranges: bytes
            Cache-Control: max-age = 604800
            Content-Type: text/html; charset = UTF-8
            Date: Sun, 03 Mar 2019 14:08:46 GMT
            Etag: "1541025663"
            Expires: Sun, 10 Mar 2019 14:08:46 GMT
            Last-Modified: Fri, 09 Aug 2013 23:54:35 GMT
            Server: ECS(mic/9AF5)
            Vary: Accept-Encoding
            X-Cache: HIT
            Content-Length: 1270

            */



           
            //TODO: Interpretar URI, si existe cargar el HTML como string

            string response = new HttpResponseMessage(request.HTTPVersion, EStatusCode.Accepted, string.Empty, request.Headers, "HTML PURO Y DURO").GenerateHttpResponse();

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
