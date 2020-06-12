namespace FilmCup.Api.Results
{
    public struct Result
    {
        public Result(int statusCode, string message, object data)
        {
            StatusCode = statusCode;
            Message = message;
            Data = data;
        }

        public int StatusCode { get; }
        public string Message { get;  }
        public object Data { get;  }
    }
}
