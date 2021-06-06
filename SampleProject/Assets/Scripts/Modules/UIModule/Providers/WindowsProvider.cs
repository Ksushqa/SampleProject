using System.Collections.Generic;
using System.Linq;
using Modules.UIModule.Enums;
using Modules.UIModule.Exceptions;
using Modules.UIModule.Models;
using UnityEngine;

namespace Modules.UIModule.Providers
{
    [CreateAssetMenu(fileName = "WindowsConfig", menuName = "SampleProject/Create WindowsConfig")]
    public class WindowsProvider : ScriptableObject, IWindowsProvider
    {
        [SerializeField] private List<WindowDataModel> _windows;

        public WindowDataModel GetWindowModel(WindowType type)
        {
            var windowModel = _windows.FirstOrDefault(x => x.Type == type);

            if (windowModel == null)
            {
                throw new WindowNotFoundException(type.ToString());
            }
            
            return windowModel;
        }
    }
}