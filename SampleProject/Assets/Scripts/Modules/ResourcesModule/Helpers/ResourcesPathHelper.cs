using System;
using System.IO;
using Modules.ResourcesModule.Editor.Models;
using Modules.ResourcesModule.Enums;
using Modules.ResourcesModule.Models;

namespace Modules.ResourcesModule.Helpers
{
    public static class ResourcesPathHelper
    {
        public static string GetResourcesPath(string assetPath, string resourcesCategory)
        {
            var collectionPath = resourcesCategory != ResourcesCategoryType.None.ToString()
                ? $"{resourcesCategory}/"
                : string.Empty;

            return $"Media/{collectionPath}{assetPath}";
        }

        public static string GetFullPath(string assetPath, string resourcesCategory, string fileExtension)
        {
            return $"Assets/Resources/{GetResourcesPath(assetPath, resourcesCategory)}{fileExtension}";
        }

        public static ParsedPathModel GetParsedPath(string fullPath)
        {
            var withCategoryPath = fullPath.Replace("Assets/Resources/", string.Empty).Replace("Media/", string.Empty);
            var removeCategoryResult = RemoveCategory(withCategoryPath);

            var fileExtension = Path.GetExtension(fullPath);
            var path = removeCategoryResult.ResultPath.Replace(fileExtension, string.Empty);

            return new ParsedPathModel(path, removeCategoryResult.Category.ToString());
        }
        
        public static RemoveCategoryResultModel RemoveCategory(string path)
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