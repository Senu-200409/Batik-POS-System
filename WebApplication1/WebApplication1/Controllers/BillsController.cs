using POS_System.Interfaces;
using POS_System.Models.RequestApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace POS_System.Controllers
{
    public class BillsController : Controller
    {
        private readonly IBills _bills;

        public BillsController(IBills bills)
        {
            _bills = bills;
        }

        public ActionResult Index()
        {
            return View();
        }


        // GET ALL bills

        [HttpGet]
        public ActionResult GetAllBills(BillsRequestApi requestAPI)
        {
            var result = _bills.GetAllBills(requestAPI);
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        // GET SUB bills BY ID

        [HttpGet]
        public ActionResult GetBillsByBillId(BillsRequestApi requestAPI)
        {
            var result = _bills.GetBillsByBillId(requestAPI);
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        // ADD SUB bills

        [HttpPost]
        public ActionResult AddBillsDetails(BillsRequestApi requestAPI)
        {
            var result = _bills.AddBillsDetails(requestAPI);
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        // UPDATE bills

        [HttpPost]
        public ActionResult PutBillsDetails(BillsRequestApi requestAPI)
        {
            var result = _bills.PutBillsDetails(requestAPI);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}