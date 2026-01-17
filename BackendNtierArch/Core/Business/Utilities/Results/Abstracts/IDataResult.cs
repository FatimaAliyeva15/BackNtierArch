using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Business.Utilities.Results.Abstracts
{
    public interface IDataResult<T>: IResult
    {
        public T Data {  get; }
    }
}
