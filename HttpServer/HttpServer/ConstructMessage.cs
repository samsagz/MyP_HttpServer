using HttpServer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpServer
{
    class ConstructMessage
    {
        public static HttpResponseMessage ConstructResponseMessage(string httpVersion, string uri)
        {
            HttpResponseMessage response; //= new HttpResponseMessage();
            EStatusCode status;
            var headers = new Dictionary<EHeaders, string>();
            string messageBody = string.Empty;
            try
            {
                status = EStatusCode.OK;

                headers.Add(EHeaders.acceptranges, "bytes");
                headers.Add(EHeaders.cachecontrol, "max-age = 604800");
                headers.Add(EHeaders.contenttype, "text/html; charset=UTF-8");
                headers.Add(EHeaders.date, DateTime.Now.ToString("ddd, dd MMM yyy HH’:’mm’:’ss ‘GMT’")); 
                headers.Add(EHeaders.etag, "1541025663");
                headers.Add(EHeaders.expires, DateTime.Now.AddDays(7).ToString("ddd, dd MMM yyy HH’:’mm’:’ss ‘GMT’"));
                headers.Add(EHeaders.lastmodified, "Fri, 09 Aug 2013 23:54:35 GMT");
                headers.Add(EHeaders.server, "ECS(mic/9AF5)");
                headers.Add(EHeaders.vary, "Accept-Encoding");
                headers.Add(EHeaders.xcache, "HIT");
                headers.Add(EHeaders.contentlength, "1270");

                //TODO: leer html
            }
            catch (Exception)
            {
                status = EStatusCode.NotFound;

                headers.Add(EHeaders.date, DateTime.Now.ToString("ddd, dd MMM yyy HH’:’mm’:’ss ‘GMT’"));
                headers.Add(EHeaders.server, "ServerMelo");
                headers.Add(EHeaders.location, uri);
                headers.Add(EHeaders.contentlength, "1270");
                headers.Add(EHeaders.keepalive, "timeout=3, max=100");
                headers.Add(EHeaders.connection, "Keep-Alive");
                headers.Add(EHeaders.contenttype, "text/html; charset=UTF-8");


                /*
                HTTP/1.1 301 Moved Permanently
                Date: Sun, 03 Mar 2019 15:22:04 GMT
                Server: Apache
                Location: http://exampleq.com/sds
                Content-Length: 231
                Keep-Alive: timeout=3, max=100
                Connection: Keep-Alive
                Content-Type: text/html; charset=iso-8859-1
                
                 */

            }

            response = new HttpResponseMessage(httpVersion, status, string.Empty, headers, messageBody);

            return response;
        }
    }
}
