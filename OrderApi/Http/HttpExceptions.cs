using System.Net;
using OrderApi.Http.Model;

namespace OrderApi.Http
{
    public class HttpBadRequest : HttpException
    {
        public HttpBadRequest(string e) : base("Syntax error!\nMessage : " + e, HttpStatusCode.BadRequest)
        {
        }
    }
    
    public class HttpUnauthorized : HttpException
    {
        public HttpUnauthorized() : base("Authorize first please!", HttpStatusCode.Unauthorized)
        {
        }
    }
    
    public class HttpForbidden : HttpException
    {
        public HttpForbidden() : base("You have not access here!", HttpStatusCode.Forbidden)
        {
        }
    }
    
    public class HttpNotFound : HttpException
    {
        public HttpNotFound(string e) : base(e + " not found.", HttpStatusCode.NotFound)
        {
        }
    }
    
    public class HttpMethodNotAllowed : HttpException
    {
        public HttpMethodNotAllowed() : base("Change method!", HttpStatusCode.MethodNotAllowed)
        {
        }
    }
}