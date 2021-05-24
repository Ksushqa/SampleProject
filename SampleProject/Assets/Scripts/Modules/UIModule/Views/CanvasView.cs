using UnityEngine;

namespace Modules.UIModule.Views
{
    public class CanvasView : MonoBehaviour
    {
        [SerializeField] private Transform _content;

        public Transform Content => _content;
    }
}