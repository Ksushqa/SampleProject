using Modules.ResourcesModule.Enums;

namespace Modules.ResourcesModule.Models
{
    public class RemoveCategoryResultModel
    {
        public string ResultPath { get; }
        public int InspectorIndex { get; }
        public ResourcesCategoryType Category { get; }

        public RemoveCategoryResultModel(string resultPath, int inspectorIndex, ResourcesCategoryType category)
        {
            ResultPath = resultPath;
            InspectorIndex = inspectorIndex;
            Category = category;
        }

        public RemoveCategoryResultModel(string resultPath)
        {
            ResultPath = resultPath;
            InspectorIndex = 0;
            Category = ResourcesCategoryType.None;
        }
    }
}