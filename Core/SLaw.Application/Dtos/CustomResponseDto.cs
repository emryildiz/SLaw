using System.Net;
using System.Text.Json.Serialization;

namespace SLaw.Application.Dtos
{
    public class CustomResponseDto
    {
        public virtual List<string> Errors { get; set; }

        public bool IsSuccess { get; set; }

        [JsonIgnore]
        public HttpStatusCode StatusCode { get; set; }
    }

    public class CustomResponseDto<T> : CustomResponseDto
    {
        public T Data { get; set; }
    }

    public class CustomResponseSuccessDto<T> : CustomResponseDto<T>
    {
        [JsonIgnore]
        public override List<string> Errors { get; set; }

        //Factory methods
        public static CustomResponseSuccessDto<T> Create(HttpStatusCode statusCode, T data)
        {
            return new CustomResponseSuccessDto<T> { StatusCode = statusCode, Data = data, IsSuccess = true };
        }
    }

    public class CustomResponseSuccessDto : CustomResponseDto
    {
        [JsonIgnore]
        public override List<string> Errors { get; set; }

        //Factory methods
        public static CustomResponseDto Create(HttpStatusCode statusCode)
        {
            return new CustomResponseSuccessDto { StatusCode = statusCode, IsSuccess = true };
        }
    }

    public class CustomResponseFailDto : CustomResponseDto
    {
        public static CustomResponseDto Create(HttpStatusCode statusCode, List<string> errors)
        {
            return new CustomResponseFailDto { StatusCode = statusCode, Errors = errors, IsSuccess = false };
        }

        public static CustomResponseDto Create(HttpStatusCode statusCode, string error)
        {
            return new CustomResponseFailDto { StatusCode = statusCode, Errors = new List<string> { error }, IsSuccess = false };
        }
    }
}
