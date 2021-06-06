using System;
using System.Collections.Generic;
using Modules.ScenariosModule.Enums;
using Modules.ScenariosModule.Exceptions;
using Modules.ScenariosModule.Models;

namespace Modules.ScenariosModule.Controllers
{
    public class GameActionsStorage : IGameActionsStorage
    {
        private readonly Dictionary<GameActionType, Action<GameActionArgs>> _actions;

        public GameActionsStorage()
        {
            _actions = new Dictionary<GameActionType, Action<GameActionArgs>>();
        }

        public void Register(GameActionType gameActionType, Action<GameActionArgs> onGameActionDone)
        {
            if (_actions.ContainsKey(gameActionType))
            {
                throw new DuplicatedActionException(gameActionType.ToString());
            }
            
            _actions.Add(gameActionType, onGameActionDone);
        }

        public void Execute(GameActionType gameActionType, GameActionArgs actionArgs)
        {
            if (!_actions.ContainsKey(gameActionType))
            {
                throw new NotFoundActionException(gameActionType.ToString());
            }

            _actions[gameActionType]?.Invoke(actionArgs);
        }
    }
}