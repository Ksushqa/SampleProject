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
        [SerializeField] private CollectionType _collectionType;

        public string Id => _id;
        public string ResourcePath => _resourcePath;
        public CollectionType CollectionType => _collectionType;
    }
}