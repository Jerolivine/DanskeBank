using DanskeBank.API.Core.Core.Base.Response.Abstract;
using System.Net;

namespace DanskeBank.API.Core.Core.Base.Response.Concrete
{
    public class ResponseBase : IResponseBase
    {
        //public HttpStatusCode ResultCode { get; set; }
        public string MessageCode { get; set; }
        public string Message { get; set; }
        public bool IsSuccess { get; set; }

        public ResponseBase()
        {
            //ResultCode = HttpStatusCode.OK;
        }

        //public virtual void SetResponse(HttpStatusCode statusCode, string message)
        //{
        //    ResultCode = HttpStatusCode.Forbidden;
        //    MessageCode = message;
        //}
    }

    public class ValueResponse<TValue> : IResponseBase<TValue>
    {
        public TValue Value { get; set; }
        //public int ProcessId { get; set; }
        //public string Token { get; set; }
        //public HttpStatusCode ResultCode { get; set; }
        public string MessageCode { get; set; }
        public string Message { get; set; }
        public bool IsSuccess { get; set; }

    }
}
