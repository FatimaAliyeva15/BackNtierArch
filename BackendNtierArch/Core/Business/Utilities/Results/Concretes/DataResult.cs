using Core.Business.Utilities.Results.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Business.Utilities.Results.Concretes
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        public DataResult(bool success): base(success)
        {
        }
        public DataResult(bool success, T data) : base(success)
        {
            Data = data;
        }
        public DataResult(bool success, T data, string message) : base(success, message)
        {
            Data = data;
        }

        public T Data {  get; }
    }
}
