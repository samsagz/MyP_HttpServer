using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace HttpServer
{
    class Program
    {


        /// <summary>
        /// Metodo Main: inicializador de la ejecucion, el cual crea una intancia de un Server
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Iniciando servidor");
            Server server = null;
            server = new Server();

            Console.ReadLine();
        }

        /// <summary>
        /// Metodo AddLog : Crea y escribe el log del estado del servidor en archivos TXT
        /// </summary>
        /// <param name="v"></param>
        public static void AddLog(string v)
        {

            
            string name = DateTime.Now.Millisecond.ToString();

            if (!Directory.Exists(".\\log"))
                Directory.CreateDirectory(".\\log");

            Console.WriteLine(v);
            try
            {
                File.WriteAllText(".\\log\\log" + name + ".txt", v);
            }
            catch (Exception e)
            {
                name += 1;
                File.WriteAllText(".\\log\\log" + name + new Random().Next(0, 1000) + ".txt", v);
            }
            
        }
    }
}
