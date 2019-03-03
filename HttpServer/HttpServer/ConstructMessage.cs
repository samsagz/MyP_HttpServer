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
                headers.Add(EHeaders.contenttype, "text/html; charset = UTF-8");
                headers.Add(EHeaders.date, "Sun, 03 Mar 2019 14:08:46 GMT");
                headers.Add(EHeaders.etag, "1541025663");
                headers.Add(EHeaders.expires, "Sun, 10 Mar 2019 14:08:46 GMT");
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

            }

            response = new HttpResponseMessage(httpVersion, status, string.Empty, headers, messageBody);

            return response;
        }
    }
}
