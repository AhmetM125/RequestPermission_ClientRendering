namespace RequestPermission.Api.Dtos.Response
{
    public class ResponseDto<T> where T : class
    {
        public T Data { get; set; }
        public bool Success { get; set; }
        private ResponseDto(T data, bool success)
        {
            Data = data;
            Success = success;
        }
        private ResponseDto(bool success)
        {
            Success = success;
        }
        public static ResponseDto<T> CreateResponse(T data, bool success)
        {
            return new ResponseDto<T>(data, success);
        }
        public static ResponseDto<T> CreateResponse(bool success)
        {
            return new ResponseDto<T>(true);
        }
    }
}
