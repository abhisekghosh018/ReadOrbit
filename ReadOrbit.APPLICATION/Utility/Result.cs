namespace ReadOrbit.APPLICATION.Utility
{
    public class Result<T>
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public int? TotalCount { get; set; } = 0;
        public T? Data { get; set; }
        public List<string>? Errors { get; set; }

        public static Result<T> Ok(T data, string? message = null, int? totalCount = null)
        {
            return new Result<T>
            {
                Success = true,
                Data = data,
                Message = message,
                TotalCount = totalCount ?? 1
            };
        }

        public static Result<T> Fail(string message)
        {
            return new Result<T>
            {
                Success = false,
                Message = message
            };
        }
    }
}
