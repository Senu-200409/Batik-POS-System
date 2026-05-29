using POS_System.Database_Layer;
using POS_System.Interfaces;
using POS_System.Models;
using POS_System.Models.RequestApiModels;
using POS_System.Static;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace POS_System.DataAccess
{
    public class DAProducts : IProducts
    {
        private readonly string ProcedureName = "PSProducts";


        // =========================
        // GET ALL PRODUCTS
        // =========================
        public Response GetAllProducts(ProductsRequestApi requestAPI)
        {
            Response result = new Response();

            requestAPI.ActionType = "1";

            using (var dbConnect = new DBconnect())
            {
                ProcedureDBModel res = dbConnect.ProcedureRead(requestAPI, ProcedureName);

                if (res.ResultStatusCode == "1")
                {
                    List<ProductsModel> productsList = new List<ProductsModel>();

                    foreach (DataRow row in res.ResultDataTable.Rows)
                    {
                        ProductsModel product = new ProductsModel
                        {
                            ProductId = row["ppd_product_id"].ToString(),
                            ProductCode = row["ppd_product_code"].ToString(),
                            BarCode = row["ppd_barcode"].ToString(),
                            ProductName = row["ppd_product_name"].ToString(),
                            CategoryId = row["ppd_category_id"].ToString(),
                            SubCategoryId = row["ppd_subcategory_id"].ToString(),
                            Price = row["ppd_price"].ToString(),
                            ProductImage = row["ppd_product_image"].ToString(),
                            IsActive = row["ppd_is_active"].ToString(),
                            CreateDate = row["ppd_create_date"].ToString(),
                            CreatedBy = row["ppd_created_by"].ToString(),
                            UpdatedDate = row["ppd_updated_date"].ToString(),
                            UpdatedBy = row["ppd_updated_by"].ToString()
                        };

                        productsList.Add(product);
                    }

                    result.StatusCode = 200;
                    result.ResultSet = productsList;
                }
                else
                {
                    LogHandler.WriteToLog(
                        res.ExceptionMessage,
                        System.Reflection.MethodBase.GetCurrentMethod().Name
                    );

                    result.StatusCode = 500;
                    result.Result = res.ExceptionMessage;
                }
            }

            return result;
        }

        // =========================
        // GET PRODUCT BY ID
        // =========================
        public Response GetProductsByProductId(ProductsRequestApi requestAPI)
        {
            Response result = new Response();

            requestAPI.ActionType = "2";

            using (var dbConnect = new DBconnect())
            {
                ProcedureDBModel res = dbConnect.ProcedureRead(requestAPI, ProcedureName);

                if (res.ResultStatusCode == "1")
                {
                    ProductsModel product = new ProductsModel();

                    foreach (DataRow row in res.ResultDataTable.Rows)
                    {
                        product = new ProductsModel
                        {
                            ProductId = row["ppd_product_id"].ToString(),
                            ProductCode = row["ppd_product_code"].ToString(),
                            BarCode = row["ppd_barcode"].ToString(),
                            ProductName = row["ppd_product_name"].ToString(),
                            CategoryId = row["ppd_category_id"].ToString(),
                            SubCategoryId = row["ppd_subcategory_id"].ToString(),
                            Price = row["ppd_price"].ToString(),
                            ProductImage = row["ppd_product_image"].ToString(),
                            IsActive = row["ppd_is_active"].ToString(),
                            CreateDate = row["ppd_create_date"].ToString(),
                            CreatedBy = row["ppd_created_by"].ToString(),
                            UpdatedDate = row["ppd_updated_date"].ToString(),
                            UpdatedBy = row["ppd_updated_by"].ToString()
                        };
                    }

                    result.StatusCode = 200;
                    result.ResultSet = product;
                }
                else
                {
                    LogHandler.WriteToLog(
                        res.ExceptionMessage,
                        System.Reflection.MethodBase.GetCurrentMethod().Name
                    );

                    result.StatusCode = 500;
                    result.Result = res.ExceptionMessage;
                }
            }

            return result;
        }


        // =========================
        // ADD PRODUCT
        // =========================
        public Response AddProductsDetails(ProductsRequestApi requestAPI)
        {
            Response result = new Response();

            requestAPI.ActionType = "3";

            using (var dbConnect = new DBconnect())
            {
                ProcedureDBModel res = dbConnect.ProcedureRead(requestAPI, ProcedureName);

                if (res.ResultStatusCode == "1")
                {
                    result.StatusCode = 200;
                    result.Result = "Product added successfully!";
                }
                else
                {
                    result.StatusCode = 500;
                    result.Result = res.ExceptionMessage;
                }
            }

            return result;
        }


        // =========================
        // UPDATE PRODUCT
        // =========================
        public Response PutProductsDetails(ProductsRequestApi requestAPI)
        {
            Response result = new Response();

            requestAPI.ActionType = "4";

            using (var dbConnect = new DBconnect())
            {
                ProcedureDBModel res = dbConnect.ProcedureRead(requestAPI, ProcedureName);

                if (res.ResultStatusCode == "1")
                {
                    result.StatusCode = 200;
                    result.Result = "Product updated successfully!";
                }
                else
                {
                    result.StatusCode = 400;
                    result.Result = res.ExceptionMessage;
                }
            }

            return result;
        }
    }
}