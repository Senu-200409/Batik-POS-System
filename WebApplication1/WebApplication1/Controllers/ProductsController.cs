using POS_System.Interfaces;
using POS_System.Models;
using POS_System.Models.RequestApiModels;
using POS_System.DataAccess;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace POS_System.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProducts _products;

        public ProductsController(IProducts products)
        {
            _products = products;
        }

        // =========================
        // INDEX
        // =========================
        public ActionResult Index()
        {
            return View();
        }

        // =========================
        // GET ALL PRODUCTS
        // =========================
        [HttpGet]
        public ActionResult GetAllProducts(ProductsRequestApi requestAPI)
        {
            var result = _products.GetAllProducts(requestAPI);

            if (result.StatusCode == 200 && result.ResultSet is List<ProductsModel> productsList)
            {
                foreach (var product in productsList)
                {
                    product.ProductImage = Url.Action(
                        "ProductPhotoPreview",
                        "Products",
                        new { ProductId = product.ProductId },
                        Request.Url.Scheme
                    );
                }
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // =========================
        // GET PRODUCT BY ID
        // =========================
        [HttpGet]
        public ActionResult GetProductsByProductId(ProductsRequestApi requestAPI)
        {
            var result = _products.GetProductsByProductId(requestAPI);

            if (result.StatusCode == 200 && result.ResultSet is ProductsModel product)
            {
                product.ProductImage = Url.Action(
                    "ProductPhotoPreview",
                    "Products",
                    new { ProductId = product.ProductId },
                    Request.Url.Scheme
                );
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // =========================
        // ADD PRODUCT
        // =========================
        //[HttpPost]
        //public ActionResult AddProductsDetails(ProductsRequestApi requestAPI, HttpPostedFileBase file)
        //{
        //    Response res;

        //    try
        //    {
        //        // Upload Image
        //        if (file != null && file.ContentLength > 0)
        //        {
        //            string[] allowedExtensions = { ".jpg", ".jpeg", ".png", ".gif", ".bmp", ".webp" };

        //            string extension = Path.GetExtension(file.FileName).ToLower();

        //            if (!allowedExtensions.Contains(extension))
        //            {
        //                return Json(new
        //                {
        //                    StatusCode = 400,
        //                    Result = "Invalid image type"
        //                }, JsonRequestBehavior.AllowGet);
        //            }

        //            string folderPath = @"C:\Users\senul\Desktop\Office Assignment\Batik POS System\Image";
        //         //   string folderPath = @"C:\inetpub\wwwroot\testRccBackend\Image\Image";

        //            if (!Directory.Exists(folderPath))
        //            {
        //                Directory.CreateDirectory(folderPath);
        //            }

        //            //string fileName = Guid.NewGuid().ToString() + extension;
        //            string fileName = Guid.NewGuid().ToString() + extension;

        //            string filePath = Path.Combine(folderPath, fileName);

        //            file.SaveAs(filePath);

        //            requestAPI.ProductImage = fileName;
        //        }

        //        res = _products.AddProductsDetails(requestAPI);
        //    }
        //    catch (Exception ex)
        //    {
        //        res = new Response
        //        {
        //            StatusCode = 500,
        //            Result = ex.Message
        //        };
        //    }

        //    return Json(res, JsonRequestBehavior.AllowGet);
        //}

        [HttpPost]
        public ActionResult AddProductsDetails(ProductsRequestApi requestAPI, HttpPostedFileBase[] files)
        {
            Response res;

            try
            {
                string folderPath = @"C:\Users\senul\Desktop\Office Assignment\Batik POS System\Image";

                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);

                List<string> imageNames = new List<string>();

                if (files != null)
                {
                    foreach (var file in files)
                    {
                        if (file == null || file.ContentLength == 0)
                            continue;

                        string ext = Path.GetExtension(file.FileName).ToLower();

                        string[] allowed = { ".jpg", ".jpeg", ".png", ".gif", ".bmp", ".webp" };

                        if (!allowed.Contains(ext))
                            continue;

                        string fileName = Guid.NewGuid().ToString() + ext;
                        string path = Path.Combine(folderPath, fileName);

                        file.SaveAs(path);

                        imageNames.Add(fileName);
                    }
                }

                // 🔥 IMPORTANT FIX (NEVER NULL)
                requestAPI.ProductImage =
                    imageNames.Count > 0 ? string.Join(",", imageNames) : "";

                res = _products.AddProductsDetails(requestAPI);
            }
            catch (Exception ex)
            {
                res = new Response
                {
                    StatusCode = 500,
                    Result = ex.Message
                };
            }

            return Json(res, JsonRequestBehavior.AllowGet);
        }

        // =========================
        // UPDATE PRODUCT
        // =========================
        //[HttpPost]
        //public ActionResult PutProductsDetails(ProductsRequestApi requestAPI, HttpPostedFileBase file)
        //{
        //    Response res;

        //    try
        //    {
        //        if (file != null && file.ContentLength > 0)
        //        {
        //            string[] allowedExtensions = { ".jpg", ".jpeg", ".png", ".gif", ".bmp", ".webp" };

        //            string extension = Path.GetExtension(file.FileName).ToLower();

        //            if (!allowedExtensions.Contains(extension))
        //            {
        //                return Json(new
        //                {
        //                    StatusCode = 400,
        //                    Result = "Invalid image type"
        //                }, JsonRequestBehavior.AllowGet);
        //            }

        //            string folderPath = @"C:\Users\senul\Desktop\Office Assignment\Batik POS System\Image";
        //          //  string folderPath = @"C:\inetpub\wwwroot\testRccBackend\Image\Image";

        //            if (!Directory.Exists(folderPath))
        //            {
        //                Directory.CreateDirectory(folderPath);
        //            }

        //            // Delete old image
        //            var oldFiles = Directory.GetFiles(folderPath, requestAPI.ProductId + ".*");

        //            foreach (var old in oldFiles)
        //            {
        //                System.IO.File.Delete(old);
        //            }

        //            string fileName = requestAPI.ProductId + extension;

        //            string filePath = Path.Combine(folderPath, fileName);

        //            file.SaveAs(filePath);

        //            requestAPI.ProductImage = fileName;
        //        }

        //        res = _products.PutProductsDetails(requestAPI);
        //    }
        //    catch (Exception ex)
        //    {
        //        res = new Response
        //        {
        //            StatusCode = 500,
        //            Result = ex.Message
        //        };
        //    }

        //    return Json(res, JsonRequestBehavior.AllowGet);
        //}

        [HttpPost]
        public ActionResult PutProductsDetails(ProductsRequestApi requestAPI, HttpPostedFileBase[] files)
        {
            Response res;

            try
            {
                List<string> imageNames = new List<string>();

                if (files != null && files.Length > 0)
                {
                    string folderPath = @"C:\Users\senul\Desktop\Office Assignment\Batik POS System\Image";

                    if (!Directory.Exists(folderPath))
                        Directory.CreateDirectory(folderPath);

                    foreach (var file in files)
                    {
                        if (file == null || file.ContentLength == 0)
                            continue;

                        string ext = Path.GetExtension(file.FileName).ToLower();

                        string[] allowed = { ".jpg", ".jpeg", ".png", ".gif", ".bmp", ".webp" };

                        if (!allowed.Contains(ext))
                            continue;

                        string fileName = Guid.NewGuid().ToString() + ext;
                        string path = Path.Combine(folderPath, fileName);

                        file.SaveAs(path);

                        imageNames.Add(fileName);
                    }

                    if (imageNames.Count > 0)
                    {
                        requestAPI.ProductImage = string.Join(",", imageNames);
                    }
                }

                // 🔥 CRITICAL FIX: DON'T SEND NULL IMAGE
                // keep old image if no new upload

                if (string.IsNullOrEmpty(requestAPI.ProductImage))
                {
                    // fetch existing image from DB
                    var existing = _products.GetProductsByProductId(requestAPI);

                    if (existing?.ResultSet is ProductsModel p)
                    {
                        requestAPI.ProductImage = p.ProductImage;
                    }
                }

                res = _products.PutProductsDetails(requestAPI);
            }
            catch (Exception ex)
            {
                res = new Response
                {
                    StatusCode = 500,
                    Result = ex.Message
                };
            }

            return Json(res, JsonRequestBehavior.AllowGet);
        }


        // =========================
        // PRODUCT IMAGE PREVIEW
        // =========================
        //[HttpGet]
        //public ActionResult ProductPhotoPreview(string imageName)
        //{
        //    try
        //    {
        //        if (string.IsNullOrEmpty(imageName))
        //        {
        //            return HttpNotFound("Image name is required");
        //        }

        //        string folderPath = @"C:\Users\senul\Desktop\Office Assignment\Batik POS System\Image";
        //     //   string folderPath = @"C:\inetpub\wwwroot\testRccBackend\Image\Image";

        //        if (!Directory.Exists(folderPath))
        //        {
        //            return HttpNotFound("Image folder not found");
        //        }

        //        string filePath = Path.Combine(folderPath, imageName);

        //        if (!System.IO.File.Exists(filePath))
        //        {
        //            return HttpNotFound("Image not found");
        //        }

        //        string extension = Path.GetExtension(filePath).ToLower();

        //        string mimeType = GetMimeType(extension);

        //        byte[] imageBytes = System.IO.File.ReadAllBytes(filePath);

        //        return File(imageBytes, mimeType);
        //    }
        //    catch (Exception ex)
        //    {
        //        return HttpNotFound(ex.Message);
        //    }
        //}
        [HttpGet]
        public ActionResult ProductPhotoPreview(string ProductId)
        {
            try
            {
                var requestAPI = new ProductsRequestApi
                {
                    ProductId = ProductId
                };

                var result = _products.GetProductsByProductId(requestAPI);

                if (result.StatusCode != 200 || result.ResultSet == null)
                {
                    return HttpNotFound("Product not found");
                }

                ProductsModel product = result.ResultSet as ProductsModel;

                if (product == null || string.IsNullOrEmpty(product.ProductImage))
                {
                    return HttpNotFound("Image not found");
                }

                string folderPath = @"C:\Users\senul\Desktop\Office Assignment\Batik POS System\Image";

                if (!Directory.Exists(folderPath))
                {
                    return HttpNotFound("Image folder not found");
                }

                string filePath = Path.Combine(folderPath, product.ProductImage);

                if (!System.IO.File.Exists(filePath))
                {
                    return HttpNotFound("Image file not found");
                }

                string extension = Path.GetExtension(filePath).ToLower();

                string mimeType = GetMimeType(extension);

                byte[] imageBytes = System.IO.File.ReadAllBytes(filePath);

                return File(imageBytes, mimeType);
            }
            catch (Exception ex)
            {
                return HttpNotFound(ex.Message);
            }
        }

        // =========================
        // MIME TYPE
        // =========================
        private string GetMimeType(string extension)
        {
            switch (extension.ToLower())
            {
                case ".jpg":
                case ".jpeg":
                    return "image/jpeg";

                case ".png":
                    return "image/png";

                case ".gif":
                    return "image/gif";

                case ".bmp":
                    return "image/bmp";

                case ".webp":
                    return "image/webp";

                default:
                    return "application/octet-stream";
            }
        }
    }
}