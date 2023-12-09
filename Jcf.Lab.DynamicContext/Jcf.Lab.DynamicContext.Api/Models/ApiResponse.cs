using System.Net;

namespace Jcf.Lab.DynamicContext.Api.Models
{
    public class ApiResponse
    {
        public ApiResponse()
        {
            ErrorMessages = new List<string>();
            Links = new List<string>();
        }

        public bool Success { get; set; } = true;
        public Object? Result { get; set; }
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;
        public List<string> ErrorMessages { get; set; }
        public List<string> Links { get; set; }

        public void Error(List<string> errorMessages, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        {
            Success = false;
            StatusCode = statusCode;
            ErrorMessages = errorMessages;
        }
    }
}
