using System.Net;
using CustomerApi.Http.Model;

namespace CustomerApi.Http
{
    public class HttpBadRequest : HttpException
    {
        public HttpBadRequest() : base("Syntax error!", HttpStatusCode.BadRequest)
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