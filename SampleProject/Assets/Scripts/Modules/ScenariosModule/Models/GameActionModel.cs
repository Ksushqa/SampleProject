using System;

namespace Modules.ScenariosModule.Models
{
    public class GameActionModel
    {
        public Action<GameActionArgs> OnActionDone { get; }
        public GameActionArgs ActionArgs { get; }

        public GameActionModel(Action<GameActionArgs> onActionDone, GameActionArgs actionArgs)
        {
            OnActionDone = onActionDone;
            ActionArgs = actionArgs;
        }
    }
}