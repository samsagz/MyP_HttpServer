using HttpServer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpServer
{
    class HttpRequestMessage
    {
        #region RequestLine
        public EMethod Method { get; set; }
        public string RequestURI { get; set; }
        public string HTTPVersion { get; set; }
        #endregion
        public Dictionary<string,string> Headers { get; set; }
        public string MessageBody { get; set; }

        
        public HttpRequestMessage(string request)
        {
        }


    }
}
