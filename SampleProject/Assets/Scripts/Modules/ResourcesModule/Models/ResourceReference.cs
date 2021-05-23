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
        [SerializeField] private ResourcesCategoryType _resourcesCategory;
        [SerializeField] private string _fileExtension;

        public string Id => _id;

        public string GetPath()
        {
            var collectionPath = _resourcesCategory != ResourcesCategoryType.None
                ? $"{_resourcesCategory.ToString()}/"
                : string.Empty;

            var mediaFolder = "Media/";
            return $"{mediaFolder}{collectionPath}{_resourcePath}";
        }
    }
}