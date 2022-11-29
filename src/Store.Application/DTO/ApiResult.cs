namespace Store.Application.DTO
{
    public class ApiResult<T>
    {
        public bool Succeeded { get; set; }
        public T Data { get; set; }
        public IEnumerable<string> Errors { get; set; }

        private ApiResult(bool succeeded, T data, IEnumerable<string> errors)
        {
            Succeeded = succeeded;
            Data = data;
            Errors = errors;
        }

        public static ApiResult<T> Success(T result)
        {
            return new ApiResult<T>(true, result, new List<string>());
        }

        public static ApiResult<T> Failure(IEnumerable<string> errors)
        {
            return new ApiResult<T>(false, default!, errors);
        }
    }
}
