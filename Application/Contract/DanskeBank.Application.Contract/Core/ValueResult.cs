using System;
using System.Collections.Generic;
using System.Text;

namespace DanskeBank.Application.Contract.Core
{
    public class ValueResult<TValue> : BaseResult
    {
        public TValue Value { get; set; }

        public ValueResult()
        {
            IsSuccess = true;
        }
    }
}
