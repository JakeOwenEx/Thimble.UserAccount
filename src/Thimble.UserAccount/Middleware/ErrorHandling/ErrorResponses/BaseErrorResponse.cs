namespace Thimble.UserAccount.Middleware.ErrorHandling.ErrorResponses
{
    public class BaseErrorResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
    }
}