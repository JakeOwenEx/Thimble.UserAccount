namespace Thimble.UserAccount.Middleware.ErrorHandling.ErrorResponses
{
    public static class StaticErrorResponses
    {
        public static readonly BaseErrorResponse UserNotRegistered = new BaseErrorResponse
        {
            StatusCode = 404,
            Message = "There is no account with the provided UserId"
        };
        
        public static readonly BaseErrorResponse InvalidKey = new BaseErrorResponse
        {
            StatusCode = 400,
            Message = "Key does not exist in users contact information"
        };
        public static readonly BaseErrorResponse AuthHeaderRequired = new BaseErrorResponse
        {
            StatusCode = 401,
            Message = "The Authorization header is required"
        };
        
        public static readonly BaseErrorResponse InvalidAuthKey = new BaseErrorResponse
        {
            StatusCode = 401,
            Message = "The Authorization key provided is invalid"
        };
    }
}