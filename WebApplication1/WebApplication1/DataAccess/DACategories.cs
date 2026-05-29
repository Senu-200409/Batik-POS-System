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
    public class DACategories : ICategories
    {
        private readonly string ProcedureName = "PSCategories";

        // Get All 
        public Response GetAllCategories(CategoriesRequestApi requestAPI)
        {
            Response result = new Response();

            requestAPI.ActionType = "1";

            using (var db = new DBconnect())
            {
                ProcedureDBModel res = db.ProcedureRead(requestAPI, ProcedureName);

                if (res.ResultStatusCode == "1")
                {
                    List<CategoriesModel> categoryList = new List<CategoriesModel>();

                    foreach (DataRow row in res.ResultDataTable.Rows)
                    {
                        categoryList.Add(new CategoriesModel
                        {
                            CategoryId = row["pcd_category_id"].ToString(),
                            CategoryName = row["pcd_category_name"].ToString(),
                            IsActive = row["pcd_is_active"].ToString(),
                            CreateDate = row["pcd_create_date"].ToString(),
                            CreatedBy = row["pcd_created_by"].ToString(),
                            UpdatedDate = row["pcd_updated_date"].ToString(),
                            UpdatedBy = row["pcd_updated_by"].ToString()
                        });
                    }

                    result.StatusCode = 200;
                    result.ResultSet = categoryList;
                }
                else
                {
                    LogHandler.WriteToLog(res.ExceptionMessage, "GetAllCategories");

                    result.StatusCode = 500;
                    result.Result = res.ExceptionMessage;
                }
            }

            return result;
        }

        
        // GET CATEGORY BY ID
        
        public Response GetCategoriesByCategoryId(CategoriesRequestApi requestAPI)
        {
            Response result = new Response();

            requestAPI.ActionType = "2";

            using (var db = new DBconnect())
            {
                ProcedureDBModel res = db.ProcedureRead(requestAPI, ProcedureName);

                if (res.ResultStatusCode == "1" &&
                    res.ResultDataTable != null &&
                    res.ResultDataTable.Rows.Count > 0)
                {
                    DataRow row = res.ResultDataTable.Rows[0];

                    CategoriesModel category = new CategoriesModel
                    {
                        CategoryId = row["pcd_category_id"].ToString(),
                        CategoryName = row["pcd_category_name"].ToString(),
                        IsActive = row["pcd_is_active"].ToString(),
                        CreateDate = row["pcd_create_date"].ToString(),
                        CreatedBy = row["pcd_created_by"].ToString(),
                        UpdatedDate = row["pcd_updated_date"].ToString(),
                        UpdatedBy = row["pcd_updated_by"].ToString()
                    };

                    result.StatusCode = 200;
                    result.ResultSet = category;
                }
                else
                {
                    result.StatusCode = 404;
                    result.Result = "Category not found!";
                }
            }

            return result;
        }

        // ADD CATEGORY
       
        public Response AddCategoriesDetails(CategoriesRequestApi requestAPI)
        {
            Response result = new Response();

            requestAPI.ActionType = "3";

            using (var db = new DBconnect())
            {
                ProcedureDBModel res = db.ProcedureRead(requestAPI, ProcedureName);

                if (res.ResultStatusCode == "1")
                {
                    result.StatusCode = 200;
                    result.Result = "Category added successfully!";
                }
                else
                {
                    result.StatusCode = 500;
                    result.Result = res.ExceptionMessage;
                }
            }

            return result;
        }

        //  UPDATE CATEGORY
        
        public Response PutCategoriesDetails(CategoriesRequestApi requestAPI)
        {
            Response result = new Response();

            requestAPI.ActionType = "4";

            using (var db = new DBconnect())
            {
                ProcedureDBModel res = db.ProcedureRead(requestAPI, ProcedureName);

                if (res.ResultStatusCode == "1")
                {
                    result.StatusCode = 200;
                    result.Result = "Category updated successfully!";
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