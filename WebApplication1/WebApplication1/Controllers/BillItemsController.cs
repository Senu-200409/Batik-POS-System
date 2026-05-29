using POS_System.Interfaces;
using POS_System.Models.RequestApiModels;
using System.Web.Mvc;

namespace POS_System.Controllers
{
    public class BillItemsController : Controller
    {
        private readonly IBillItems _billItems;

        public BillItemsController(IBillItems billItems)
        {
            _billItems = billItems;
        }

        // =========================
        // INDEX
        // =========================
        public ActionResult Index()
        {
            return View();
        }

        // =========================
        // GET ALL BILL ITEMS
        // =========================
        [HttpGet]
        public ActionResult GetAllBillItems(BillItemsRequestApi requestAPI)
        {
            var result = _billItems.GetAllBillItems(requestAPI);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // =========================
        // GET BILL ITEM BY ID
        // =========================
        [HttpGet]
        public ActionResult GetBillItemsByBillItemsId(BillItemsRequestApi requestAPI)
        {
            var result = _billItems.GetBillItemsByBillItemsId(requestAPI);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // =========================
        // ADD BILL ITEM
        // =========================
        [HttpPost]
        public ActionResult AddBillItemsDetails(BillItemsRequestApi requestAPI)
        {
            var result = _billItems.AddBillItemsDetails(requestAPI);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // =========================
        // UPDATE BILL ITEM
        // =========================
        [HttpPost]
        public ActionResult PutBillItemsDetails(BillItemsRequestApi requestAPI)
        {
            var result = _billItems.PutBillItemsDetails(requestAPI);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}