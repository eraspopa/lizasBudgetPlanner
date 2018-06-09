using System;
using System.Collections.Generic;
using System.Web.Mvc;
using BlipDrop.Data;
using BlipDrop.ViewModels;

namespace BlipDrop.Controllers
{
    public class RecordController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            var repo = new RecordsRepository();
            var recordsList = repo.GetRecords();
            return View(recordsList);
        }

        [HttpGet]
        public ActionResult GetCategories(string subcategoryCode)
        {
            if (!string.IsNullOrWhiteSpace(subcategoryCode))
            {
                var repo = new CategoriesRepository();

                IEnumerable<SelectListItem> categories = repo.GetCategories(subcategoryCode);
                return Json(categories, JsonRequestBehavior.AllowGet);
            }
            return null;
        }

        [HttpGet]
        public ActionResult GetSubcategories(string typeCode)
        {
            if (!string.IsNullOrWhiteSpace(typeCode))
            {
                var repo = new SubcategoryRepository();

                IEnumerable<SelectListItem> subCategories = repo.GetSubcategories(typeCode);
                return Json(subCategories, JsonRequestBehavior.AllowGet);
            }
            return null;
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            var repo = new RecordsRepository();
            var customer = repo.CreateRecord();
            return View(customer);
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "RecordId, RecordValue, SelectedExpenseTypeId, SelectedSubcategoryId, SelectedCategoryCode, SelectedPeriodCode")] RecordEditViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var repo = new RecordsRepository();
                    bool saved = repo.SaveRecord(model);
                    if (saved)
                    {
                        return RedirectToAction("Index");
                    }
                }
                // Handling model state errors is beyond the scope of the demo, so just throwing an ApplicationException when the ModelState is invalid
                // and rethrowing it in the catch block.
                throw new ApplicationException("Invalid model");
            }
            catch (ApplicationException ex)
            {
                throw ex;
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
