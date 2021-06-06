using System.Collections.Generic;
using System.Linq;
using Modules.UIModule.Enums;
using Modules.UIModule.Exceptions;
using Modules.UIModule.Models;
using UnityEngine;

namespace Modules.UIModule.Providers
{
    [CreateAssetMenu(fileName = "CanvasesConfig", menuName = "SampleProject/Create CanvasesConfig")]
    public class CanvasesProvider : ScriptableObject, ICanvasesProvider
    {
        [SerializeField] private List<CanvasDataModel> _canvases;

        public string GetId(CanvasType type)
        {
            var canvasModel = _canvases.FirstOrDefault(x => x.Type == type);

            if (canvasModel == null)
            {
                throw new CanvasNotFoundException(type.ToString());
            }

            return canvasModel.Id;
        }
    }
}