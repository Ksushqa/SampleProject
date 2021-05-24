using System;
using Modules.UIModule.Enums;
using UnityEngine;

namespace Modules.UIModule.Models
{
    [Serializable]
    public class CanvasDataModel
    {
        [SerializeField] private CanvasType _type;
        [SerializeField] private string _id;
        
        public CanvasType Type => _type;
        public string Id => _id;
    }
}