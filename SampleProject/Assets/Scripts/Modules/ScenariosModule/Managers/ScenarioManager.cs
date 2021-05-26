using System;
using Modules.ScenariosModule.Controllers;
using Modules.ScenariosModule.Enums;
using Modules.ScenariosModule.Models;

namespace Modules.ScenariosModule.Managers
{
    public class ScenarioManager : IScenarioManager
    {
        private IGameActionsStorage _gameActionsStorage;

        public ScenarioManager()
        {
            _gameActionsStorage = new GameActionsStorage();
        }

        public void RegisterAction(GameActionType gameActionType, Action<GameActionArgs> onActionDone)
        {
            _gameActionsStorage.Register(gameActionType, onActionDone);
        }

        public void ExecuteAction(GameActionType gameActionType, GameActionArgs actionArgs)
        {
            _gameActionsStorage.Execute(gameActionType, actionArgs);
        }
    }
}