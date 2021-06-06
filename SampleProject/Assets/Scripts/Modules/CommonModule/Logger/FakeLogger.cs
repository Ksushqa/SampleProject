namespace Modules.CommonModule.Logger
{
    public class FakeLogger : IProjectLogger
    {
        public void Log<T>(T sourceClass, string message)
        {
            
        }

        public void Log(string tag, string message)
        {
            
        }

        public void LogError<T>(T sourceClass, string message)
        {
            
        }

        public void LogError(string tag, string message)
        {
            
        }
    }
}