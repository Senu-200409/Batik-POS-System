using POS_System.Interfaces;
using POS_System.Models.RequestApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace POS_System.Controllers
{
    public class SubCategoriesController : Controller
    {
        private readonly ISubCategories _subCategories;

        public SubCategoriesController(ISubCategories subCategories)
        {
            _subCategories = subCategories;
        }

        public ActionResult Index()
        {
            return View();
        }

        
        // GET ALL SUB CATEGORIES
        
        [HttpGet]
        public ActionResult GetAllSubCategories(SubCategoriesRequestApi requestAPI)
        {
            var result = _subCategories.GetAllSubCategories(requestAPI);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        
        // GET SUB CATEGORY BY ID
        
        [HttpGet]
        public ActionResult GetSubCategoriesBySubCategoryId(SubCategoriesRequestApi requestAPI)
        {
            var result = _subCategories.GetSubCategoriesBySubCategoryId(requestAPI);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        
        // ADD SUB CATEGORY
        
        [HttpPost]
        public ActionResult AddSubCategoriesDetails(SubCategoriesRequestApi requestAPI)
        {
            var result = _subCategories.AddSubCategoriesDetails(requestAPI);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        
        // UPDATE SUB CATEGORY
     
        [HttpPost]
        public ActionResult PutSubCategoriesDetails(SubCategoriesRequestApi requestAPI)
        {
            var result = _subCategories.PutSubCategoriesDetails(requestAPI);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}