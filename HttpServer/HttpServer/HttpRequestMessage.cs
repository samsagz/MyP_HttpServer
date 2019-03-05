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

        public Dictionary<EHeaders,string> Headers { get; set; }
        public string MessageBody { get; set; }

        
        public HttpRequestMessage(string request)
        {
            var lineas = request.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

            var RequestLine = lineas[0].Split(' ');

            try
            {
                Method = (EMethod)Enum.Parse(typeof(EMethod), RequestLine[0]);
            }
            catch (Exception)
            {
                throw new Exception("RequestLine, Metodo no detectado");
            }
              
            RequestURI = RequestLine[1];
            HTTPVersion = RequestLine[2];

            if (HTTPVersion != "HTTP/1.1")
                throw new NotSupportedException("");

            Headers = new Dictionary<EHeaders, string>();
            EHeaders tempEnum;
            for (int i = 1; i < lineas.Length; i++)
            {
                if (string.IsNullOrEmpty(lineas[i]))
                    break;

                var header = lineas[i].Split(':');
                if (Enum.TryParse(header[0].Replace("-", string.Empty).ToLower(), out tempEnum))
                    Headers.Add(tempEnum, header[1]);
                //else
                //    throw new NotSupportedException();
            }

            MessageBody = lineas[lineas.Length - 1];

        }

         

    }
}
