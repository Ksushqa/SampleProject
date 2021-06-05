using System;
using System.Collections.Generic;
using Modules.UIModule.Enums;
using Modules.UIModule.Views.GameWindow;
using Modules.UIModule.Views.MainWindow;

namespace Modules.UIModule.Helpers
{
    public static class WindowTypeHelper
    {
        private static Dictionary<WindowType, Type> _viewTypes = new Dictionary<WindowType, Type>
        {
            { WindowType.Main, typeof(MainWindowView) },
            { WindowType.Game, typeof(GameWindowView) },
        };

        public static Type GetViewType(WindowType windowType)
        {
            return _viewTypes[windowType];
        }
    }
}