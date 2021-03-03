using System;
using System.Net;

namespace CustomerApi.Http.Model
{
    public class HttpException : Exception
    {
        public override string Message { get; }
        public HttpStatusCode HttpStatusCode { get; }

        protected HttpException(string message, HttpStatusCode httpStatusCode)
        {
            Message = message;
            HttpStatusCode = httpStatusCode;
        }
    }
}