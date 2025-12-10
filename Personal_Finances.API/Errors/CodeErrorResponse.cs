namespace Personal_Finances.API.Errors
{
    public class CodeErrorResponse
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }

        public CodeErrorResponse(int statusCode, string? message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageStatusCode(statusCode);
        }

        private string GetDefaultMessageStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "The request sent contains errors",
                401 => "You are not authorized to access this resource",
                404 => "The requested resource was not found",
                500 => "Server errors occurred",
                _ => ""
            };
        }
    }
}
