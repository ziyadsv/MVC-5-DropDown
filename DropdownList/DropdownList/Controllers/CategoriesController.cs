using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DropdownList.Models;

namespace DropdownList.Controllers
{
    public class CategoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult DropDownName()
        {
            IEnumerable<SelectListItem> items = db.Categories.Select(c => new SelectListItem
            {
                Value = c.CategoriesId.ToString(),
                Text = c.Name
            });
            ViewBag.TestingId = items;
            return View();
        }

        public ActionResult DropDownName2()
        {
            var query = db.Categories.Select(c => new { c.CategoriesId, c.Name });
            ViewBag.Categories = new SelectList(query.AsEnumerable(), "CategoriesId", "Name");
            return View();
        }
      
        //Multiple select
        public ActionResult DropDownList3()
        {
            var categories = db.Categories.Select(c => new
                                                           {
                                                               CategoryID = c.CategoriesId,
                                                               CategoryName = c.Name
                                                           }).ToList();
            ViewBag.Category = new MultiSelectList(categories, "CategoryID", "CategoryName");
            return View();
        }

        public ActionResult TimeDropDown()
        {
            return View();
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoriesId,Name")] Categories categories)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(categories);
                db.SaveChanges();
                return RedirectToAction("DropDownName2");
            }

            return View(categories);
        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
