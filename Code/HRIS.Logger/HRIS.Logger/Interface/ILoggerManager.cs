namespace HRIS.Logger
{
    public interface ILoggerManager
    {
        void LogDebug(string Message);
        void LogError(string Message);
        void LogInfo(string Message);
        void LogWarning(string Message);
    }
}