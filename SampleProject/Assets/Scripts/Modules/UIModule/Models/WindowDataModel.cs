using System;
using Modules.UIModule.Enums;
using UnityEngine;

namespace Modules.UIModule.Models
{
    [Serializable]
    public class WindowDataModel
    {
        [SerializeField] private WindowType _type;
        [SerializeField] private string _id;
        [SerializeField] private CanvasType _canvas;

        public WindowType Type => _type;
        public string Id => _id;
        public CanvasType Canvas => _canvas;
    }
}