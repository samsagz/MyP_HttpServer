using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpServer.Enums
{
    enum EHeaders
    {
        [StringValue("Accept")]
        accept,
        [StringValue("Accept-Charset")]
        acceptcharset,
        [StringValue("Accept-Encoding")]
        acceptencoding,
        [StringValue("Accept-Language")]
        AcceptLanguage,
        [StringValue("Authorization")]
        Authorization,
        [StringValue("Expect")]
        Expect,
        [StringValue("From")]
        From,
        [StringValue("Host")]
        host,
        [StringValue("If-Match")]
        IfMatch,
        [StringValue("If-Modified-Since")]
        IfModifiedSince,
        [StringValue("If-None-Match")]
        IfNoneMatch,
        [StringValue("If-Range")]
        IfRange,
        [StringValue("If-Unmodified-Since")]
        IfUnmodifiedSince,
        [StringValue("Max-Forwards")]
        MaxForwards,
        [StringValue("Proxy-Authorization")]
        ProxyAuthorization,
        [StringValue("Range")]
        Range,
        [StringValue("Referer")]
        Referer,
        [StringValue("TE")]
        TE,
        [StringValue("User-Agent")]
        useragent,
        [StringValue("Connection")]
        connection,
        [StringValue("Cache-Control")]
        cachecontrol


    }
}
