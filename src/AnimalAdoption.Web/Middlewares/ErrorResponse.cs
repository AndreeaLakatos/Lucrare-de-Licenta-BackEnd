using System.Text.Json;
using AnimalAdoption.BusinessLogic.Exceptions;

namespace AnimalAdoption.Web.Middlewares
{
    internal class ErrorResponse
    {
        public ErrorCode ErrorCode { get; set; }
        public string Message { get; set; }

        public ErrorResponse(ErrorCode errorCode, string message)
        {
            ErrorCode = errorCode;
            Message = message;
        }

        public override string ToString() => JsonSerializer.Serialize(this);
    }
}
