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
            return View();
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
            return View();
        }

        // POST: AssetTypes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AssetType type)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}