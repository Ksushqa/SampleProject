using System;
using Modules.ScenariosModule.Enums;
using Modules.ScenariosModule.Models;

namespace Modules.ScenariosModule.Controllers
{
    public interface IGameActionsStorage
    {
        void Register(GameActionType gameActionType, Action<GameActionArgs> onGameActionDone);
        void Execute(GameActionType gameActionType, GameActionArgs actionArgs);
    }
}