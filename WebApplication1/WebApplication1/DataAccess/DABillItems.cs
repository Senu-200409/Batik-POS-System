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
    public class DABillItems : IBillItems
    {
        private readonly string ProcedureName = "PSBillItems";

        // =========================
        // GET ALL BILL ITEMS
        // =========================
        public Response GetAllBillItems(BillItemsRequestApi requestAPI)
        {
            Response result = new Response();

            requestAPI.ActionType = "1";

            using (var db = new DBconnect())
            {
                ProcedureDBModel res = db.ProcedureRead(requestAPI, ProcedureName);

                if (res.ResultStatusCode == "1")
                {
                    List<BillItemsModel> billItemsList = new List<BillItemsModel>();

                    foreach (DataRow row in res.ResultDataTable.Rows)
                    {
                        billItemsList.Add(new BillItemsModel
                        {
                            BillItemId = row["pid_billitem_id"].ToString(),
                            BillId = row["pid_bill_id"].ToString(),
                            ProductId = row["pid_product_id"].ToString(),
                            Qty = row["pid_qty"].ToString(),
                            UnitPrice = row["pid_unit_price"].ToString(),
                            Total = row["pid_total"].ToString(),
                            CreateDate = row["pid_create_date"].ToString(),
                            CreatedBy = row["pid_created_by"].ToString(),
                            UpdatedDate = row["pid_updated_date"].ToString(),
                            UpdatedBy = row["pid_updated_by"].ToString()
                        });
                    }

                    result.StatusCode = 200;
                    result.ResultSet = billItemsList;
                }
                else
                {
                    LogHandler.WriteToLog(res.ExceptionMessage, "GetAllBillItems");

                    result.StatusCode = 500;
                    result.Result = res.ExceptionMessage;
                }
            }

            return result;
        }

        // =========================
        // GET BILL ITEM BY ID
        // =========================
        public Response GetBillItemsByBillItemsId(BillItemsRequestApi requestAPI)
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

                    BillItemsModel billItem = new BillItemsModel
                    {
                        BillItemId = row["pid_billitem_id"].ToString(),
                        BillId = row["pid_bill_id"].ToString(),
                        ProductId = row["pid_product_id"].ToString(),
                        Qty = row["pid_qty"].ToString(),
                        UnitPrice = row["pid_unit_price"].ToString(),
                        Total = row["pid_total"].ToString(),
                        CreateDate = row["pid_create_date"].ToString(),
                        CreatedBy = row["pid_created_by"].ToString(),
                        UpdatedDate = row["pid_updated_date"].ToString(),
                        UpdatedBy = row["pid_updated_by"].ToString()
                    };

                    result.StatusCode = 200;
                    result.ResultSet = billItem;
                }
                else
                {
                    result.StatusCode = 404;
                    result.Result = "Bill item not found!";
                }
            }

            return result;
        }

        // =========================
        // ADD BILL ITEM
        // =========================
        public Response AddBillItemsDetails(BillItemsRequestApi requestAPI)
        {
            Response result = new Response();

            requestAPI.ActionType = "3";

            using (var db = new DBconnect())
            {
                ProcedureDBModel res = db.ProcedureRead(requestAPI, ProcedureName);

                if (res.ResultStatusCode == "1")
                {
                    result.StatusCode = 200;
                    result.Result = "Bill item added successfully!";
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
        // UPDATE BILL ITEM
        // =========================
        public Response PutBillItemsDetails(BillItemsRequestApi requestAPI)
        {
            Response result = new Response();

            requestAPI.ActionType = "4";

            using (var db = new DBconnect())
            {
                ProcedureDBModel res = db.ProcedureRead(requestAPI, ProcedureName);

                if (res.ResultStatusCode == "1")
                {
                    result.StatusCode = 200;
                    result.Result = "Bill item updated successfully!";
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