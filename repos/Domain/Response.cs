namespace Domain
{
    public class BaseResult
    {
        public int StatusCode { get; set; } = 200;
        public bool IsSuccess { get { return StatusCode < 400 ? true : false; } set { } }
        public string Message { get; set; }

        public string Exception { get; set; }

        public BaseResult(int statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message;
        }

        public BaseResult() { }
    }

    public class Result<T> : BaseResult
    {
        public T Data { get; set; } = default;

        public Result(int statusCode, string message, T? data) : base(statusCode, message)
        {
            Data = data;
        }

        public Result(int statusCode, string message) : base(statusCode, message) { }

        public Result() { }
    }
}
