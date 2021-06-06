using UnityEngine;

namespace Modules.CommonModule.Logger
{
    public class ProjectLogger : IProjectLogger
    {
        public void Log<T>(T sourceClass, string message)
        {
            Debug.Log(GetStringByClass(sourceClass, message));
        }

        public void Log(string tag, string message)
        {
            Debug.Log(GetStringByTag(tag, message));
        }

        public void LogError<T>(T sourceClass, string message)
        {
            Debug.LogError(GetStringByClass(sourceClass, message));
        }

        public void LogError(string tag, string message)
        {
            Debug.LogError(GetStringByTag(tag, message));
        }

        private string GetStringByClass<T>(T sourceClass, string message)
        {
            return $"[{sourceClass.GetType().Name}]: {message}";
        }

        private string GetStringByTag(string tag, string message)
        {
            return $"[{tag}]: {message}";
        }
    }
}