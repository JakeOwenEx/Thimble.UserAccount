using System;

namespace Thimble.UserAccount.logging
{
    public interface IThimbleLogger
    {
        void Log(string action);
        void Log(string productId, string action);
        void Log(Exception exception, string action);
        void SetTraceId(string traceId);
    }
}