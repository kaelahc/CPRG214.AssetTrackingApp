using CPRG214.Assets.AssetTracking.Models;
using CPRG214.Assets.BLL;
using CPRG214.Assets.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace CPRG214.Assets.AssetTracking.Controllers
{
    public class AssetsController : Controller
    {
        public IActionResult Index()
        {
            var assets = BLL.AssetsManager.GetAll();
            var viewModels = assets.Select(a => new AssetViewModel
            {
                Id = a.Id,
                Description = a.Description,
                AssetType = a.AssetType.Name,
                TagNumber = a.TagNumber,
                SerialNumber = a.SerialNumber
            }).ToList();
            return View(viewModels);
        }

        public IActionResult Create()
        {
            var assetTypes = AssetTypesManager.GetAsKeyValuePairs();
            var list = new SelectList(assetTypes, "Value", "Text");
            ViewBag.AssetTypeList = list;

            return View();
        }

        [HttpPost]
        public IActionResult Create(Asset asset)
        {
            try
            {
                AssetsManager.Add(asset);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public IActionResult GetAssetsByType(int id)
        {
            return ViewComponent("AssetsByType", id);
        }

    }
}