using Modules.ResourcesModule.Helpers;
using Modules.ResourcesModule.Providers;
using UnityEditor;

namespace Modules.ResourcesModule.AssetProcessors
{
    public class MainAssetPostprocessor : AssetPostprocessor
    {
        private static void OnPostprocessAllAssets(string[] importedPaths, string[] deletedPaths, string[] afterMovePaths, string[] beforeMovePaths)
        {
            if (afterMovePaths.Length > 0)
            {
                OnMoveAssets(beforeMovePaths, afterMovePaths);
            }
        }
        
        private static void OnMoveAssets(string[] beforeMovePaths, string[] afterMovePaths)
        {
            var allPaths = AssetDatabase.GetAllAssetPaths();
            foreach (var path in allPaths)
            {
                var collection = AssetDatabase.LoadAssetAtPath<ResourcesCollection>(path);
                if (collection != null)
                {
                    var serializedObject = new SerializedObject(collection);
                    var resourcesProperty = serializedObject.FindProperty("_resources");
                    for (int i = 0; i < resourcesProperty.arraySize; i++)
                    {
                        var resource = resourcesProperty.GetArrayElementAtIndex(i);
                        var pathProperty = resource.FindPropertyRelative("_resourcePath");
                        var categoryProperty = resource.FindPropertyRelative("_resourcesCategory");
                        var fileExtension = resource.FindPropertyRelative("_fileExtension");
                        
                        for (int j = 0; j < beforeMovePaths.Length; j++)
                        {
                            var categoryType = categoryProperty.enumNames[categoryProperty.enumValueIndex];
                            var fullPath = ResourcesPathHelper.GetFullPath(pathProperty.stringValue, categoryType, fileExtension.stringValue);
                            if (beforeMovePaths[j] == fullPath)
                            {
                                var parsedPath = ResourcesPathHelper.GetParsedPath(afterMovePaths[i]);
                                pathProperty.stringValue = parsedPath.AssetPathInsideCategory;

                                for (var index = 0; index < categoryProperty.enumNames.Length; index++)
                                {
                                    var enumName = categoryProperty.enumNames[index];
                                    if (enumName == parsedPath.CategoryType)
                                    {
                                        categoryProperty.enumValueIndex = index;
                                        break;
                                    }
                                }

                            }
                        }
                    }
                    serializedObject.ApplyModifiedPropertiesWithoutUndo();
                }
            }
        }
    }
}