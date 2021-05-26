using System.Collections;
using Modules.CommonModule.Controllers;
using Modules.ResourcesModule.Managers;
using Modules.UIModule.Enums;
using Modules.UIModule.Managers;
using Modules.UIModule.Views.MainWindow;
using UnityEngine;

public class Entry : MonoBehaviour
{
    [SerializeField] private CoroutineController _coroutineController;
    
    private IEnumerator Start()
    {
        IResourcesManager resourcesManager = new ResourcesManager();
        
        IUIManager uiManager = new UIManager(resourcesManager, _coroutineController);

        while (true)
        {
            uiManager.ShowWindow<MainWindowView, MainWindowViewModel>(WindowType.Main, new MainWindowViewModel());
            yield return new WaitForSeconds(1f);
            uiManager.HideWindow(WindowType.Main);
            yield return new WaitForSeconds(1f);
        }
    }
}
