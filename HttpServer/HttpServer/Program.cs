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
        static void Main(string[] args)
        {
            Console.WriteLine("Iniciando servidor");
            Server server = null;
            server = new Server(null);
            
            Console.ReadLine();
        }

        public static void AddLog(string v)
        {
            Console.WriteLine(v);
        }
    }
}
