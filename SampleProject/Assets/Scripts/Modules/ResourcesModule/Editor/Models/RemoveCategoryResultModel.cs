using Modules.ResourcesModule.Enums;

namespace Modules.ResourcesModule.Editor.Models
{
    public class RemoveCategoryResultModel
    {
        public string ResultPath { get; }
        public int InspectorIndex { get; }
        public ResourcesCategory Category { get; }

        public RemoveCategoryResultModel(string resultPath, int inspectorIndex, ResourcesCategory category)
        {
            ResultPath = resultPath;
            InspectorIndex = inspectorIndex;
            Category = category;
        }

        public RemoveCategoryResultModel(string resultPath)
        {
            ResultPath = resultPath;
            InspectorIndex = 0;
            Category = ResourcesCategory.None;
        }
    }
}