using POS_System.Interfaces;
using POS_System.Models.RequestApiModels;
using System.Web.Mvc;

namespace POS_System.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategories _categories;

        public CategoriesController(ICategories categories)
        {
            _categories = categories;
        }

        public ActionResult Index()
        {
            return View();
        }

        
        [HttpGet]
        public ActionResult GetAllCategories(CategoriesRequestApi requestAPI)
        {
            var result = _categories.GetAllCategories(requestAPI);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        
        [HttpGet]
        public ActionResult GetCategoriesByCategoryId(CategoriesRequestApi requestAPI)
        {
            var result = _categories.GetCategoriesByCategoryId(requestAPI);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        
        [HttpPost]
        public ActionResult AddCategoriesDetails(CategoriesRequestApi requestAPI)
        {
            var result = _categories.AddCategoriesDetails(requestAPI);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

       
        [HttpPost]
        public ActionResult PutCategoriesDetails(CategoriesRequestApi requestAPI)
        {
            var result = _categories.PutCategoriesDetails(requestAPI);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}