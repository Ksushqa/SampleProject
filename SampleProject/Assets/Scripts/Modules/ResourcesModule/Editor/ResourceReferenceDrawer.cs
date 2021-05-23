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
        private SerializedProperty IdProperty { get; }
        private SerializedProperty PathProperty { get; }
        private SerializedProperty CategoryProperty { get; }
        private SerializedProperty ExtensionProperty { get; }
        
        private bool IsPathEmpty => PathProperty.stringValue == string.Empty && CategoryProperty.enumValueIndex == 0;
        private bool IsAssetEmpty => _asset == null;
        
        private Object _asset;
        private bool _isFoldoutOpened;
     
        private readonly SerializedProperty _property;
        private readonly int _index;
   
        public ResourceReferenceDrawer(SerializedProperty property, int index)
        {
            _property = property;
            _index = index;
            
            IdProperty = _property.FindPropertyRelative("_id");
            PathProperty = _property.FindPropertyRelative("_resourcePath");
            CategoryProperty = _property.FindPropertyRelative("_resourcesCategory");
            ExtensionProperty = _property.FindPropertyRelative("_fileExtension");
        }

        public void Draw()
        {
            var infoText = $"ResourceReference [{_index}]";
            if (!IsAssetEmpty)
            {
                var fullPath = AssetDatabase.GetAssetPath(_asset);
                var withCategoryPath = fullPath.Replace("Assets/Resources/", string.Empty).Replace("Media/", string.Empty);
                var removeCategoryResult = RemoveCategory(withCategoryPath);

                var fileExtension = Path.GetExtension(fullPath);
                var path = removeCategoryResult.ResultPath.Replace(fileExtension, string.Empty);
                
                PathProperty.stringValue = path;
                CategoryProperty.enumValueIndex = removeCategoryResult.InspectorIndex;
                ExtensionProperty.stringValue = fileExtension;
                IdProperty.stringValue = IdProperty.stringValue == string.Empty ? _asset.name : IdProperty.stringValue;
                
                infoText += $" : {withCategoryPath}";
            }
            
            if (IsAssetEmpty && !IsPathEmpty)
            {
                var enumName = CategoryProperty.enumNames[CategoryProperty.enumValueIndex];
                _asset = AssetDatabase.LoadAssetAtPath<Object>($"Assets/Resources/Media/{enumName}/{PathProperty.stringValue}{ExtensionProperty.stringValue}");
            }

            _isFoldoutOpened = EditorGUILayout.Foldout(_isFoldoutOpened, infoText);
            if (_isFoldoutOpened)
            {
                EditorGUILayout.PropertyField(IdProperty);
                _asset = EditorGUILayout.ObjectField(_asset, typeof(Object), false);

                if (IsAssetEmpty && !IsPathEmpty)
                {
                    PathProperty.stringValue = string.Empty;
                    CategoryProperty.enumValueIndex = 0;
                    ExtensionProperty.stringValue = string.Empty;
                }
                
                EditorGUILayout.Space();
            }
        }
        
        private RemoveCategoryResultModel RemoveCategory(string path)
        {
            var categories = Enum.GetNames(typeof(ResourcesCategoryType));

            for (var i = 0; i < categories.Length; i++)
            {
                var category = categories[i];
                if (path.StartsWith($"{category}/"))
                {
                    var resultPath = path.Remove(0, category.Length + 1);
                    Enum.TryParse(category, out ResourcesCategoryType resourcesCategory);
                    return new RemoveCategoryResultModel(resultPath, i, resourcesCategory);
                }
            }

            return new RemoveCategoryResultModel(path);
        }
    }
}