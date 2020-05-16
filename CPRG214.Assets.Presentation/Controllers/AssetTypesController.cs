using CPRG214.Assets.BLL;
using CPRG214.Assets.Domain;
using Microsoft.AspNetCore.Mvc;

namespace CPRG214.Assets.AssetTracking.Controllers
{
    public class AssetTypesController : Controller
    {
        // GET: AssetTypes
        public ActionResult Index()
        {
            var assetType = AssetTypesManager.GetAssetTypes();
            return View(assetType);
        }

        // GET: AssetTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AssetTypes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AssetType type)
        {
            try
            {
                AssetTypesManager.Add(type);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AssetTypes/Edit/5
        public ActionResult Edit(int id)
        {
            var assetType = AssetTypesManager.Find(id);
            return View(assetType);
        }

        // POST: AssetTypes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AssetType type)
        {
            try
            {
                AssetTypesManager.Update(type);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}