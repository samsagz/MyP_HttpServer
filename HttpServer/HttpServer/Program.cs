﻿using System;
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
            string name = DateTime.Now.Millisecond.ToString();

            //if (!File.Exists(".\\log"))
            //    File.Create(".\\log");

            Console.WriteLine(v);
            try
            {
                File.WriteAllText(".\\log\\log" + name + ".txt", v);

            }
            catch (Exception e)
            {
                name += 1;
                File.WriteAllText(".\\log\\log" + name + ".txt", v);

            }
        }
    }
}
