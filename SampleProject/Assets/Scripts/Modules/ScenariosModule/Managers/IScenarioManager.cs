using System;
using Modules.ScenariosModule.Enums;
using Modules.ScenariosModule.Models;

namespace Modules.ScenariosModule.Managers
{
    public interface IScenarioManager
    {
        void RegisterAction(GameActionType gameActionType, Action<GameActionArgs> onActionDone);
        void ExecuteAction(GameActionType gameActionType, GameActionArgs actionArgs = null);
    }
}