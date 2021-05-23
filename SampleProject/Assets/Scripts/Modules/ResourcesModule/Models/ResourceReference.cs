using System;
using Modules.ResourcesModule.Enums;
using Modules.ResourcesModule.Helpers;
using UnityEngine;

namespace Modules.ResourcesModule.Models
{
    [Serializable]
    public class ResourceReference
    {
        [SerializeField] private string _id;
        [SerializeField] private string _resourcePath;
        // TODO: использовать гуид, а не путь, чтобы перемещения не мешали объекту
        [SerializeField] private ResourcesCategoryType _resourcesCategory;
        [SerializeField] private string _fileExtension;

        public string Id => _id;

        public string GetPath()
        {
            return ResourcesPathHelper.GetResourcesPath(_resourcePath, _resourcesCategory.ToString());
        }
    }
}