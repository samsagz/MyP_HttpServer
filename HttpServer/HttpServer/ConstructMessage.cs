using HttpServer.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpServer
{
    class ConstructMessage
    {
        public static HttpResponseMessage ConstructResponseMessage(string httpVersion, string uri)
        {
            string error404 = "/ProyectoHttp/error404.html";

            HttpResponseMessage response;
            EStatusCode status;
            Dictionary<EHeaders, string> headers; 
            string messageBody = string.Empty;
            try
            {
                status = EStatusCode.OK;

                headers = new Dictionary<EHeaders, string>
                {
                    { EHeaders.acceptranges, "bytes" },
                    { EHeaders.cachecontrol, "max-age = 604800" },
                    { EHeaders.contenttype, "text/html; charset=UTF-8" },
                    { EHeaders.date, DateTime.Now.ToString("ddd, dd MMM yyy HH:mm:ss GMT").Replace(".", "") },
                    { EHeaders.expires, DateTime.Now.AddDays(7).ToString("ddd, dd MMM yyy HH:mm:ss GMT").Replace(".", "") },
                    { EHeaders.lastmodified, "Fri, 09 Aug 2013 23:54:35 GMT" },
                    { EHeaders.vary, "Accept-Encoding" },
                    { EHeaders.xcache, "HIT" }
                };

                //string uriPath = string.Format("{1}/html{0}", uri,Directory.GetCurrentDirectory()).Replace("/","\\");
                string uriPath = string.Format("./html{0}", uri).Replace("/","\\");
                messageBody = File.ReadAllText(uriPath,Encoding.UTF8);
            }
            catch (Exception)
            {
                status = EStatusCode.NotFound;
                headers = new Dictionary<EHeaders, string>
                {
                    { EHeaders.date, DateTime.Now.ToString("ddd, dd MMM yyy HH:mm:ss GMT").Replace(".", "") },
                    { EHeaders.server, "ServerMelo" },
                    { EHeaders.location, uri },
                    { EHeaders.keepalive, "timeout=3, max=100" },
                    { EHeaders.connection, "Keep-Alive" },
                    { EHeaders.contenttype, "text/html; charset=UTF-8" }
                };

                string uriPath = string.Format("./html{0}", error404).Replace("/", "\\");
                messageBody = File.ReadAllText(uriPath, Encoding.UTF8);
            }

            response = new HttpResponseMessage(httpVersion, status, string.Empty, headers, messageBody);

            return response;
        }
    }
}
