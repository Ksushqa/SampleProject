using System;
using System.IO;
using Modules.ResourcesModule.Editor.Models;
using Modules.ResourcesModule.Enums;
using UnityEditor;
using Object = UnityEngine.Object;

namespace Modules.ResourcesModule.Editor
{
    public class ResourceReferenceDrawer
    {
        private readonly SerializedProperty _property;
        private readonly int _index;

        private Object _asset;
        private bool _isFoldoutOpened;
        
        public ResourceReferenceDrawer(SerializedProperty property, int index)
        {
            _property = property;
            _index = index;
        }

        public void Draw()
        {
            var idProperty = _property.FindPropertyRelative("_id");
            var pathProperty = _property.FindPropertyRelative("_resourcePath");
            var categoryProperty = _property.FindPropertyRelative("_resourcesCategory");

            var infoText = $"ResourceReference [{_index}]";
            if (_asset != null)
            {
                var fullPath = AssetDatabase.GetAssetPath(_asset);
                var withCategoryPath = fullPath.Replace("Assets/Resources/", string.Empty).Replace("Media/", string.Empty);
                var removeCategoryResult = RemoveCategory(withCategoryPath);

                var fileExtension = Path.GetExtension(fullPath);
                var path = removeCategoryResult.ResultPath.Replace(fileExtension, string.Empty);
                pathProperty.stringValue = path;
                categoryProperty.enumValueIndex = removeCategoryResult.InspectorIndex;

                infoText += $" : {withCategoryPath}";
            }

            _isFoldoutOpened = EditorGUILayout.Foldout(_isFoldoutOpened, infoText);
            if (_isFoldoutOpened)
            {
                EditorGUILayout.PropertyField(idProperty);
                _asset = EditorGUILayout.ObjectField(_asset, typeof(Object), false);
                EditorGUILayout.Space();
            }
        }
        
        private RemoveCategoryResultModel RemoveCategory(string path)
        {
            var categories = Enum.GetNames(typeof(ResourcesCategory));

            for (var i = 0; i < categories.Length; i++)
            {
                var category = categories[i];
                if (path.StartsWith($"{category}/"))
                {
                    var resultPath = path.Remove(0, category.Length + 1);
                    Enum.TryParse(category, out ResourcesCategory resourcesCategory);
                    return new RemoveCategoryResultModel(resultPath, i, resourcesCategory);
                }
            }

            return new RemoveCategoryResultModel(path);
        }
    }
}