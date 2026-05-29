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
    public class DASubCategories : ISubCategories
    {
        private readonly string ProcedureName = "PSSubCategories";

        // =========================
        // GET ALL SUB CATEGORIES
        // =========================
        public Response GetAllSubCategories(SubCategoriesRequestApi requestAPI)
        {
            Response result = new Response();

            requestAPI.ActionType = "1";

            using (var db = new DBconnect())
            {
                ProcedureDBModel res = db.ProcedureRead(requestAPI, ProcedureName);

                if (res.ResultStatusCode == "1")
                {
                    List<SubCategoriesModel> subCategoryList = new List<SubCategoriesModel>();

                    foreach (DataRow row in res.ResultDataTable.Rows)
                    {
                        subCategoryList.Add(new SubCategoriesModel
                        {
                            SubCategoryId = row["psd_subcategory_id"].ToString(),
                            CategoryId = row["psd_category_id"].ToString(),
                            SubCategoryName = row["psd_subcategory_name"].ToString(),
                            IsActive = row["psd_is_active"].ToString(),
                            CreateDate = row["psd_create_date"].ToString(),
                            CreatedBy = row["psd_created_by"].ToString(),
                            UpdatedDate = row["psd_updated_date"].ToString(),
                            UpdatedBy = row["psd_updated_by"].ToString()
                        });
                    }

                    result.StatusCode = 200;
                    result.ResultSet = subCategoryList;
                }
                else
                {
                    LogHandler.WriteToLog(res.ExceptionMessage, "GetAllSubCategories");

                    result.StatusCode = 500;
                    result.Result = res.ExceptionMessage;
                }
            }

            return result;
        }

        // =========================
        // GET SUB CATEGORY BY ID
        // =========================
        public Response GetSubCategoriesBySubCategoryId(SubCategoriesRequestApi requestAPI)
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

                    SubCategoriesModel subCategory = new SubCategoriesModel
                    {
                        SubCategoryId = row["psd_subcategory_id"].ToString(),
                        CategoryId = row["psd_category_id"].ToString(),
                        SubCategoryName = row["psd_subcategory_name"].ToString(),
                        IsActive = row["psd_is_active"].ToString(),
                        CreateDate = row["psd_create_date"].ToString(),
                        CreatedBy = row["psd_created_by"].ToString(),
                        UpdatedDate = row["psd_updated_date"].ToString(),
                        UpdatedBy = row["psd_updated_by"].ToString()
                    };

                    result.StatusCode = 200;
                    result.ResultSet = subCategory;
                }
                else
                {
                    result.StatusCode = 404;
                    result.Result = "Sub Category not found!";
                }
            }

            return result;
        }

        // =========================
        // ADD SUB CATEGORY
        // =========================
        public Response AddSubCategoriesDetails(SubCategoriesRequestApi requestAPI)
        {
            Response result = new Response();

            requestAPI.ActionType = "3";

            using (var db = new DBconnect())
            {
                ProcedureDBModel res = db.ProcedureRead(requestAPI, ProcedureName);

                if (res.ResultStatusCode == "1")
                {
                    result.StatusCode = 200;
                    result.Result = "Sub Category added successfully!";
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
        // UPDATE SUB CATEGORY
        // =========================
        public Response PutSubCategoriesDetails(SubCategoriesRequestApi requestAPI)
        {
            Response result = new Response();

            requestAPI.ActionType = "4";

            using (var db = new DBconnect())
            {
                ProcedureDBModel res = db.ProcedureRead(requestAPI, ProcedureName);

                if (res.ResultStatusCode == "1")
                {
                    result.StatusCode = 200;
                    result.Result = "Sub Category updated successfully!";
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