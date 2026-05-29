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
    public class DAUser : IUser
    {
        private readonly string ProcedureName = "PSUsers";

        // =========================
        // 1 = REGISTER USER
        // =========================
        public Response AddUserDetails(UserRequestApi requestAPI)
        {
            Response result = new Response();
            requestAPI.ActionType = "1";

            using (var db = new DBconnect())
            {
                ProcedureDBModel res = db.ProcedureRead(requestAPI, ProcedureName);

                if (res.ResultStatusCode == "1")
                {
                    result.StatusCode = 200;
                    result.Result = "User registered successfully!";
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
        // 2 = LOGIN USER
        // =========================
        public Response LoginUser(UserRequestApi requestAPI)
        {
            Response result = new Response();

            requestAPI.ActionType = "2"; // LOGIN

            using (var db = new DBconnect())
            {
                var res = db.ProcedureRead(requestAPI, ProcedureName);

                if (res.ResultStatusCode == "1" &&
                    res.ResultDataTable != null &&
                    res.ResultDataTable.Rows.Count > 0)
                {
                    DataRow row = res.ResultDataTable.Rows[0];

                    result.StatusCode = 200;
                    result.ResultSet = new
                    {
                        UserId = row["pud_user_id"].ToString(),
                        UserName = row["pud_username"].ToString(),
                        RoleName = row["pud_role_name"].ToString(),
                        IsActive = row["pud_is_active"].ToString()
                    };
                }
                else
                {
                    result.StatusCode = 401;
                    result.Result = "Invalid username or password";
                }
            }

            return result;
        }

        // =========================
        // 3 = UPDATE USER
        // =========================
        public Response PutUserDetails(UserRequestApi requestAPI)
        {
            Response result = new Response();
            requestAPI.ActionType = "3";

            using (var db = new DBconnect())
            {
                ProcedureDBModel res = db.ProcedureRead(requestAPI, ProcedureName);

                if (res.ResultStatusCode == "1")
                {
                    result.StatusCode = 200;
                    result.Result = "User updated successfully!";
                }
                else
                {
                    result.StatusCode = 400;
                    result.Result = res.ExceptionMessage;
                }
            }

            return result;
        }

        // =========================
        // 4 = GET ALL USERS
        // =========================
        public Response GetAllUsers(UserRequestApi requestAPI)
        {
            Response result = new Response();

            requestAPI.ActionType = "4";

            using (var db = new DBconnect())
            {
                ProcedureDBModel res = db.ProcedureRead(requestAPI, ProcedureName);

                if (res.ResultStatusCode == "1")
                {
                    List<UserModel> userList = new List<UserModel>();

                    foreach (DataRow row in res.ResultDataTable.Rows)
                    {
                        userList.Add(new UserModel
                        {
                            UserId = row["pud_user_id"].ToString(),
                            UserName = row["pud_username"].ToString(),
                            RoleName = row["pud_role_name"].ToString(),
                            IsActive = row["pud_is_active"].ToString(),
                            CreateDate = row["pud_create_date"].ToString(),
                            CreatedBy = row["pud_created_by"].ToString(),
                            UpdatedDate = row["pud_updated_date"].ToString(),
                            UpdatedBy = row["pud_updated_by"].ToString()
                        });
                    }

                    result.StatusCode = 200;
                    result.ResultSet = userList;
                }
                else
                {
                    LogHandler.WriteToLog(res.ExceptionMessage, "GetAllUsers");
                    result.StatusCode = 500;
                    result.Result = res.ExceptionMessage;
                }
            }

            return result;
        }
    }
}