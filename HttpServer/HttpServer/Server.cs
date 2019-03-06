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


        /// <summary>
        /// Metodo Server: inicializador del Socket
        /// </summary>
        public Server()
        {
            //context = cntxt;
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Start();
        }


     

        /// <summary>
        /// Metodo Start: Metodo en el cual el servidor estará a la espera de una comunicación con un cliente. Se define el puerto
        ///              y la ip donde se puede establcer una conexión
        /// </summary>
        public void Start()
        {
            serverSocket.Bind(new IPEndPoint(IPAddress.Any, port));
            serverSocket.Listen(backlog);
            Accept();
        }



        /// <summary>
        /// Metodo Accept: Metodo en el cual el servidor aceptará una conexión entrante, se suscribe el servidor a un evento 
        ///               para recibir una conexion entrante.
        /// </summary>
        public void Accept()
        {
            serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), null);
        }

        /// <summary>
        /// Metodo AcceptCallBack: Metodo en el cual se recibe la solicitud desde cliente y se atiende
        /// </summary>
        /// <param name="ar"></param>
        private void AcceptCallback(IAsyncResult ar)
        {
            Socket client = serverSocket.EndAccept(ar);
            clients.Add(client);
            client.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(ReciveCallback), client);
            Accept();
            Program.AddLog(ar.ToString());
        }


        /// <summary>
        /// Metodo ReciveCallBack: Metodo en el cual el servidor recibe la señal del cliente, se genera el contenido para la respuesta
        ///                       y se envia
        /// </summary>
        /// <param name="ar"></param>
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

        /// <summary>
        /// Metodo SendCallBack: Metodo en el cual el servidor vuelve a estar en escucha para recibir llamadas nuevas
        /// </summary>
        /// <param name="ar"></param>
        private void SendCallback(IAsyncResult ar)
        {
            Socket client = (Socket)ar.AsyncState;
            client.Shutdown(SocketShutdown.Send);
        }
    }
}
