using CPRG214.Assets.Data;
using CPRG214.Assets.Domain;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CPRG214.Assets.BLL
{
    public class AssetTypesManager
    {
        public static List<AssetType> GetAssetTypes()
        {
            var context = new AssetContext();
            var assetTypes = context.AssetTypes.OrderBy(t => t.Name).ToList();
            return assetTypes;
        }

        public static void Add(AssetType type)
        {
            var context = new AssetContext();
            context.AssetTypes.Add(type);
            context.SaveChanges();
        }

        public static void Update(AssetType assetType)
        {
            var context = new AssetContext();
            var originalType = context.AssetTypes.Find(assetType);
            originalType.Name = assetType.Name;
            context.SaveChanges();
        }

        public static IList GetAsKeyValuePairs()
        {
            var context = new AssetContext();
            var assetTypes = context.AssetTypes.Select(a => new
            {
                Value = a.Id,
                Text = a.Name,
            }).ToList();
            return assetTypes;
        }
    }
}
