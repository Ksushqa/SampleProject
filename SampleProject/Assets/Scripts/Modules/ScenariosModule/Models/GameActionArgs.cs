namespace Modules.ScenariosModule.Models
{
    public class GameActionArgs
    {
        public object Value { get; private set; }

        public GameActionArgs(object value)
        {
            Value = value;
        }
    }
}