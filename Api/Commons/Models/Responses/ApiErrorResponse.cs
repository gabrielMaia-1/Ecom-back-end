namespace Api.Models.Responses
{
    public class ApiErrorResponse
    {
        public string Message { get; set; }
        public ApiErrorResponse(string message)
        {   
            Message = message;
        }
    }
}