using POS_System.BusinessLayer;
using POS_System.Interfaces;
using POS_System.Models;
using POS_System.Models.RequestApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace POS_System.Controllers
{
    public class UserController : Controller
    {
        private readonly IUser _user;

        public UserController(IUser user)
        {
            _user = user;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetAllUsers(UserRequestApi requestAPI)
        {
            var result = _user.GetAllUsers(requestAPI);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        //[HttpPost]
        //public ActionResult LoginUser(UserRequestApi requestAPI)
        //{
        //    var result = _user.LoginUser(requestAPI);
        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}
        [HttpPost]
        public ActionResult LoginUser(UserRequestApi requestAPI)
        {
            var loginResult = _user.LoginUser(requestAPI);

            if (loginResult != null &&
                loginResult.StatusCode == 200 &&
                loginResult.ResultSet != null)
            {
                // Convert ResultSet to UserModel
                var user = Newtonsoft.Json.JsonConvert.DeserializeObject<UserModel>(
                    Newtonsoft.Json.JsonConvert.SerializeObject(loginResult.ResultSet)
                );

                if (user != null)
                {
                    string userId = user.UserId.ToString();
                    string roleName = user.RoleName;
                    string userName = user.UserName;
                    string password = requestAPI.Password;

                    // Generate AuthKey
                    string authKey = AuthKeyGenerator.GenerateAuthKey(
                        userId,
                        roleName,
                        password,
                        userName
                    );

                    // Store values
                    HttpContext.Items["UserRole"] = roleName;
                    HttpContext.Items["UserId"] = userId;
                    HttpContext.Items["AuthKey"] = authKey;

                    // Replace ResultSet
                    loginResult.ResultSet = new UserAuthKeyModel
                    {
                        UserId = userId,
                        RoleName = roleName,
                        UserName = userName,
                        AuthKey = authKey
                    };
                }
            }

            return Json(loginResult, JsonRequestBehavior.AllowGet);
        }



        [HttpPost]
        public ActionResult AddUserDetails(UserRequestApi requestAPI)
        {
            var result = _user.AddUserDetails(requestAPI);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult PutUserDetails(UserRequestApi requestAPI)
        {
            var result = _user.PutUserDetails(requestAPI);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetUsersByUserId(UserRequestApi requestAPI)
        {
            var result = _user.GetUsersByUserId(requestAPI);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}