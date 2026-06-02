using POS_System.Models;
using POS_System.Models.RequestApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_System.Interfaces
{
    public interface IUser
    {
        Response AddUserDetails(UserRequestApi requestAPI);

        Response GetAllUsers(UserRequestApi requestAPI);

        Response LoginUser(UserRequestApi requestAPI);

        Response PutUserDetails(UserRequestApi requestAPI);
        Response GetUsersByUserId(UserRequestApi requestAPI);
    }
}
