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
        public Dictionary<EHeaders, string> Headers { get; set; }
        public string MessageBody { get; set; }

        public HttpResponseMessage(string hTTPVersion, EStatusCode statusCode, string reasonPhrase, Dictionary<EHeaders, string> headers, string messageBody)
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
                HTTPVersion, StatusCode.GetStringValue(), ReasonPhrase, Environment.NewLine, " ");

            foreach (var item in Headers)
            {
                response += string.Format("{0}{4}{3}{1}{2}",
                item.Key.GetStringValue(), item.Value, Environment.NewLine, " ", ":");
            }

            response += Environment.NewLine; 

            response += MessageBody;
            
            return response;
        }
    }
}
