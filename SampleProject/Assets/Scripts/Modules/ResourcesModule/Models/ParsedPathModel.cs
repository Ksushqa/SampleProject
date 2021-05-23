namespace Modules.ResourcesModule.Models
{
    public class ParsedPathModel
    {
        public string AssetPathInsideCategory { get; }
        public string CategoryType { get; }

        public ParsedPathModel(string assetPathInsideCategory, string categoryType)
        {
            AssetPathInsideCategory = assetPathInsideCategory;
            CategoryType = categoryType;
        }
    }
}