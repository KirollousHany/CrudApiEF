namespace CrudApiDemo.Responses
{
    public class BaseResponse<T>
    {
        public int StatusCode { get; set; }
        public bool Success { get; set; }
        public string? ErrorMessage { get; set; }
        public T? Data { get; set; }
        public static BaseResponse<T> SuccessResponse(T data, int statusCode = 200)
        {
            return new BaseResponse<T>
            {
                StatusCode = statusCode,
                Success = true,
                ErrorMessage = null,
                Data = data
            };
        }

        public static BaseResponse<T> FailResponse(string errorMessage, int statusCode = 400)
        {
            return new BaseResponse<T>
            {
                StatusCode = statusCode,
                Success = false,
                ErrorMessage = errorMessage,
                Data = default
            };
        }
    }
}
