using System;
using System.Collections.Generic;
using System.Text;

namespace DanskeBank.Application.Contract.Core
{
    public class BaseResult
    {
        public bool IsSuccess { get; set; }
        public string MessageCode { get; set; }
        public string Message { get; set; }

        public BaseResult()
        {
            IsSuccess = true;
        }
    }
}
