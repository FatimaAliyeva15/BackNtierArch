namespace Core.Business.Utilities.Results.Concretes
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult() : base(false)
        {
        }

        public ErrorDataResult(T data) : base(false, data)
        {
        }
        public ErrorDataResult(string message) : base(false, default, message)
        {
        }

        public ErrorDataResult(T data, string message) : base(false, data, message)
        {
        }

    }
}
