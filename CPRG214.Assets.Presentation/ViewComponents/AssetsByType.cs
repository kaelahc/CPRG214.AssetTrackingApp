using CPRG214.Assets.AssetTracking.Models;
using CPRG214.Assets.BLL;
using CPRG214.Assets.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CPRG214.Assets.AssetTracking.ViewComponents
{
    public class AssetsByTypeViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            IList<Asset> assets = null;

            if (id == 0)
            {
                assets = AssetsManager.GetAll();
            }
            else
            {
                assets = AssetsManager.GetAllByAssetType(id);
            }

            var assetList = assets.Select(a => new AssetViewModel
            {
                Id = a.Id,
                TagNumber = a.TagNumber,
                AssetType = a.AssetType.Name,
                Description = a.Description,
                SerialNumber = a.SerialNumber
            }).ToList();

            return View(assetList);
        }
    }
}
