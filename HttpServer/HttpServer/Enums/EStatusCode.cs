using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpServer.Enums
{
    /// <summary>
    /// Enums de estatus Code 
    /// </summary>
    enum EStatusCode
    {
        [StringValue("100 Continue")]
        Continue,
        [StringValue("101 Switching Protocols")]
        SwitchingProtocols,
        [StringValue("200 OK")]
        OK,
        [StringValue("201 Created")]
        Created,
        [StringValue("202 Accepted")]
        Accepted,
        [StringValue("203 Non-Authoritative Information")]
        NonAuthoritativeInformation,
        [StringValue("204 No Content")]
        NoContent,
        [StringValue("205 Reset Content")]
        ResetContent,
        [StringValue("206 Partial Content")]
        PartialContent,
        [StringValue("300 Multiple Choices")]
        MultipleChoices,
        [StringValue("301 Moved Permanently")]
        MovedPermanently,
        [StringValue("302 Found")]
        Found,
        [StringValue("303 See Other")]
        SeeOther,
        [StringValue("304 Not Modified")]
        NotModified,
        [StringValue("305 Use Proxy")]
        UseProxy,
        [StringValue("307 Temporary Redirect")]
        TemporaryRedirect,
        [StringValue("400 Bad Request")]
        BadRequest,
        [StringValue("401 Unauthorized")]
        Unauthorized,
        [StringValue("402 Payment Required")]
        PaymentRequired,
        [StringValue("403 Forbidden")]
        Forbidden,
        [StringValue("404 Not Found")]
        NotFound,
        [StringValue("405 Method Not Allowed")]
        MethodNotAllowed,
        [StringValue("406 Not Acceptable")]
        NotAcceptable,
        [StringValue("407 Proxy Authentication Required")]
        ProxyAuthenticationRequired,
        [StringValue("408 Request Time-out")]
        RequestTimeOut,
        [StringValue("409 Conflict")]
        Conflict,
        [StringValue("410 Gone")]
        Gone,
        [StringValue("411 Length Required")]
        LengthRequired,
        [StringValue("412 Precondition Failed")]
        PreconditionFailed,
        [StringValue("413 Request Entity Too Large")]
        RequestEntityTooLarge,
        [StringValue("414 Request-URI Too Large")]
        RequestURITooLarge,
        [StringValue("415 Unsupported Media Type")]
        UnsupportedMediaType,
        [StringValue("416 Requested range not satisfiable")]
        Requestedrangenotsatisfiable,
        [StringValue("417 Expectation Failed")]
        ExpectationFailed,
        [StringValue("500 Internal Server Error")]
        InternalServerError,
        [StringValue("501 Not Implemented")]
        NotImplemented,
        [StringValue("502 Bad Gateway")]
        BadGateway,
        [StringValue("503 Service Unavailable")]
        ServiceUnavailable,
        [StringValue("504 Gateway Time-out")]
        GatewayTimeOut,
        [StringValue("505 HTTP Version not supported")]
        HTTPVersionnotsupported
    }
}
