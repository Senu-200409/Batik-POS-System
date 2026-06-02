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
    public class DABills : IBills
    {
        private readonly string ProcedureName = "PSBills";

        // =========================
        // GET ALL BILLS
        // =========================
        public Response GetAllBills(BillsRequestApi requestAPI)
        {
            Response result = new Response();

            requestAPI.ActionType = "1";

            using (var db = new DBconnect())
            {
                ProcedureDBModel res = db.ProcedureRead(requestAPI, ProcedureName);

                if (res.ResultStatusCode == "1")
                {
                    List<BillsModel> billsList = new List<BillsModel>();

                    foreach (DataRow row in res.ResultDataTable.Rows)
                    {
                        billsList.Add(new BillsModel
                        {
                            BillId = row["pbd_bill_id"].ToString(),
                            BillNo = row["pbd_bill_no"].ToString(),
                            BillDate = row["pbd_bill_date"].ToString(),
                            UserId = row["pbd_user_id"].ToString(),
                            TotalAmount = row["pbd_total_amount"].ToString(),
                            DiscountAmount = row["pbd_discount_amount"].ToString(),
                            NetAmount = row["pbd_net_amount"].ToString(),
                            PaidAmount = row["pbd_paid_amount"].ToString(),
                            ChangeAmount = row["pbd_change_amount"].ToString(),
                            PaymentType = row["pbd_payment_type"].ToString(),
                            CreateDate = row["pbd_create_date"].ToString(),
                            CreatedBy = row["pbd_created_by"].ToString(),
                            UpdatedDate = row["pbd_updated_date"].ToString(),
                            UpdatedBy = row["pbd_updated_by"].ToString()
                        });
                    }

                    result.StatusCode = 200;
                    result.ResultSet = billsList;
                }
                else
                {
                    LogHandler.WriteToLog(res.ExceptionMessage, "GetAllBills");

                    result.StatusCode = 500;
                    result.Result = res.ExceptionMessage;
                }
            }

            return result;
        }

        // =========================
        // GET BILL BY ID
        // =========================
        public Response GetBillsByBillId(BillsRequestApi requestAPI)
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

                    BillsModel bill = new BillsModel
                    {
                        BillId = row["pbd_bill_id"].ToString(),
                        BillNo = row["pbd_bill_no"].ToString(),
                        BillDate = row["pbd_bill_date"].ToString(),
                        UserId = row["pbd_user_id"].ToString(),
                        TotalAmount = row["pbd_total_amount"].ToString(),
                        DiscountAmount = row["pbd_discount_amount"].ToString(),
                        NetAmount = row["pbd_net_amount"].ToString(),
                        PaidAmount = row["pbd_paid_amount"].ToString(),
                        ChangeAmount = row["pbd_change_amount"].ToString(),
                        PaymentType = row["pbd_payment_type"].ToString(),
                        CreateDate = row["pbd_create_date"].ToString(),
                        CreatedBy = row["pbd_created_by"].ToString(),
                        UpdatedDate = row["pbd_updated_date"].ToString(),
                        UpdatedBy = row["pbd_updated_by"].ToString()
                    };

                    result.StatusCode = 200;
                    result.ResultSet = bill;
                }
                else
                {
                    result.StatusCode = 404;
                    result.Result = "Bill not found!";
                }
            }

            return result;
        }

        // =========================
        // ADD BILL
        // =========================
        public Response AddBillsDetails(BillsRequestApi requestAPI)
        {
            Response result = new Response();

            requestAPI.ActionType = "3";

            using (var db = new DBconnect())
            {
                ProcedureDBModel res = db.ProcedureRead(requestAPI, ProcedureName);

                if (res.ResultStatusCode == "1")
                {
                    result.StatusCode = 200;
                    result.Result = "Bill added successfully!";
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
        // UPDATE BILL
        // =========================
        public Response PutBillsDetails(BillsRequestApi requestAPI)
        {
            Response result = new Response();

            requestAPI.ActionType = "4";

            using (var db = new DBconnect())
            {
                ProcedureDBModel res = db.ProcedureRead(requestAPI, ProcedureName);

                if (res.ResultStatusCode == "1")
                {
                    result.StatusCode = 200;
                    result.Result = "Bill updated successfully!";
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