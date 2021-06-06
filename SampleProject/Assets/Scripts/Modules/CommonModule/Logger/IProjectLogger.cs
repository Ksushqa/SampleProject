namespace Modules.CommonModule.Logger
{
    public interface IProjectLogger
    {
        void Log<T>(T sourceClass, string message);
        void Log(string tag, string message);
        
        void LogError<T>(T sourceClass, string message);
        void LogError(string tag, string message);
    }
}