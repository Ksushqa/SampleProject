using System;
using Modules.ResourcesModule.Enums;
using UnityEngine;

namespace Modules.ResourcesModule.Models
{
    [Serializable]
    public class ResourceReference
    {
        [SerializeField] private string _id;
        [SerializeField] private string _resourcePath;
        [SerializeField] private ResourcesCategory _resourcesCategory;

        public string Id => _id;

        public string GetPath()
        {
            var collectionPath = _resourcesCategory != ResourcesCategory.None
                ? $"{_resourcesCategory.ToString()}/"
                : string.Empty;

            var mediaFolder = "Media/";
            return $"{mediaFolder}{collectionPath}{_resourcePath}";
        }
    }
}