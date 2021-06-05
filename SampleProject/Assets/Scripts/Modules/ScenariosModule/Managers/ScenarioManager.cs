using System;
using Modules.SaveModule.Managers;
using Modules.ScenariosModule.Controllers;
using Modules.ScenariosModule.Enums;
using Modules.ScenariosModule.Models;

namespace Modules.ScenariosModule.Managers
{
    public class ScenarioManager : IScenarioManager
    {
        private readonly ISaveManager _saveManager;
        private IGameActionsStorage _gameActionsStorage;

        public ScenarioManager(ISaveManager saveManager)
        {
            _saveManager = saveManager;
            _gameActionsStorage = new GameActionsStorage();
        }

        public void RegisterAction(GameActionType gameActionType, Action<GameActionArgs> onActionDone)
        {
            _gameActionsStorage.Register(gameActionType, onActionDone);
        }

        public void ExecuteAction(GameActionType gameActionType, GameActionArgs actionArgs)
        {
            _gameActionsStorage.Execute(gameActionType, actionArgs);
            _saveManager.SaveState();
        }
    }
}