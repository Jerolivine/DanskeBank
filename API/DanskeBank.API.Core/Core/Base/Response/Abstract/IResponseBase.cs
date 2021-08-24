using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace DanskeBank.API.Core.Core.Base.Response.Abstract
{
    public interface IResponseBase<TValue> : IResponseBase
    {
        public TValue Value { get; set; }
    }

    public interface IResponseBase
    {
        //int ProcessId { get; set; }
        //string Token { get; set; }
        //HttpStatusCode ResultCode { get; set; }
        public string MessageCode { get; set; }
        public string Message { get; set; }
        public bool IsSuccess { get; set; }

        //void SetResponse(HttpStatusCode statusCode, string errorMessage);
    }
}
