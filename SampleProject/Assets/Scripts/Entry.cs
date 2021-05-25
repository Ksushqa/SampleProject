using Modules.ResourcesModule.Managers;
using Modules.UIModule.Enums;
using Modules.UIModule.Managers;
using Modules.UIModule.Views.MainWindow;
using UnityEngine;

public class Entry : MonoBehaviour
{
    private void Start()
    {
        IResourcesManager resourcesManager = new ResourcesManager();
        
        IUIManager uiManager = new UIManager(resourcesManager);

        uiManager.ShowWindow<MainWindowView, MainWindowViewModel>(WindowType.Main, new MainWindowViewModel());
    }
}
