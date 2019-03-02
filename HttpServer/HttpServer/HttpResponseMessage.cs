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
        public Dictionary<string,string> Headers { get; set; }
        public string MessageBody { get; set; }

        public HttpResponseMessage(string hTTPVersion, EStatusCode statusCode, string reasonPhrase, Dictionary<string, string> headers, string messageBody)
        {
            HTTPVersion = hTTPVersion;
            StatusCode = statusCode;
            ReasonPhrase = reasonPhrase;
            Headers = headers;
            MessageBody = messageBody;
        }
    }
}
