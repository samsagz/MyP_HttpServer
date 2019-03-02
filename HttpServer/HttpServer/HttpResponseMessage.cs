using HttpServer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpServer
{
    class HttpResponseMessage
    {
        #region Status-Line
        public string HTTPVersion { get; set; }
        public EStatusCode StatusCode { get; set; }
        public string ReasonPhrase { get; set; }
        #endregion
        public Dictionary<string, string> Headers { get; set; }
        public string MessageBody { get; set; }

        public HttpResponseMessage(string hTTPVersion, EStatusCode statusCode, string reasonPhrase, Dictionary<string, string> headers, string messageBody)
        {
            HTTPVersion = hTTPVersion;
            StatusCode = statusCode;
            ReasonPhrase = reasonPhrase;
            Headers = headers;
            MessageBody = messageBody;
        }

        public string GenerateHttpResponse()
        {
            string response = string.Format("{0}{4}{1}{4}{2}{3}",
                HTTPVersion, StatusCode, ReasonPhrase, Environment.NewLine, " ");

            foreach (var item in Headers)
            {
                response += string.Format("{0}{4}{1}{4}{2}{3}",
                item.Key, item.Value, Environment.NewLine, " ",":");
            }



            //"Date: Sun, 17 Feb 2019 02:25:19 GMT",
            //    "Transfer - Encoding: chunked",
            //    "  Connection: keep - alive",
            //    "Cache - Control: max - age = 3600",
            //    "Expires: Sun, 17 Feb 2019 03:25:19 GMT",
            //    "Location: http://www.holamundo.com",
            //    "        Vary: Accept - Encoding",
            //    "Server: cloudflare",
            //    "CF - RAY: 4aa4cd7e8e49b937 - MIA",
            //    "<h1>estado OK</h1>", Environment.NewLine, " ");

            //"Date: Sun, 17 Feb 2019 02:25:19 GMT",
            //"Transfer - Encoding: chunked",
            //"  Connection: keep - alive",
            //"Cache - Control: max - age = 3600",
            //"Expires: Sun, 17 Feb 2019 03:25:19 GMT",
            //"Location: http://www.holamundo.com",
            //"        Vary: Accept - Encoding",
            //"Server: cloudflare",
            //"CF - RAY: 4aa4cd7e8e49b937 - MIA",
            //"<h1>estado OK</h1>", Environment.NewLine, " ");

            return response;
        }
    }
}
