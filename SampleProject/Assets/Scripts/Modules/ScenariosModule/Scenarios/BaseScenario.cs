using Modules.UIModule.Enums;
using Modules.UIModule.Managers;
using Modules.UIModule.Views;

namespace Modules.ScenariosModule.Scenarios
{
    public abstract class BaseScenario
    {
        public abstract WindowType WindowType { get; }
        public abstract void InitializeActionsToStorage();

        private readonly IUIManager _uiManager;

        protected BaseScenario(IUIManager uiManager)
        {
            _uiManager = uiManager;
        }
        
        public void Add(WindowType windowType, IViewModel viewModel)
        {
            // cast to window type and view model ?
        }

        public void AddOver()
        {
            
        }

        public void Close()
        {
            // close this
        }
        
        public void CloseAll()
        {
            
        }
    }
}