namespace SampleTechnologyForTest.Common
{
    public class ResultDto
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = string.Empty;
        public List<string> Errors { get; set; } = new();

        public static ResultDto Success(string message = "")
            => new ResultDto { IsSuccess = true, Message = message };

        public static ResultDto Failure(string message = "", List<string>? errors = null)
            => new ResultDto { IsSuccess = false, Message = message, Errors = errors ?? new List<string>() };
    }

    public class ResultDto<T> : ResultDto
    {
        public T Data { get; set; }
   
        // وقتی لیست هست
        public List<T>? List { get; set; }

        public static ResultDto<T> Success(T data, string message = "")
            => new ResultDto<T> { IsSuccess = true, Data = data, Message = message };

        public static ResultDto<T> Success(List<T> data, string message = "")
            => new ResultDto<T> { IsSuccess = true, List = data, Message = message };

        public static ResultDto<T> Failure(string message = "", List<string>? errors = null)
            => new ResultDto<T> { IsSuccess = false, Message = message, Errors = errors ?? new List<string>() };
    }

}
