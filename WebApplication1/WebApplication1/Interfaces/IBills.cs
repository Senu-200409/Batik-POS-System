using POS_System.Models;
using POS_System.Models.RequestApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_System.Interfaces
{
    public interface IBills
    {
        Response AddBillsDetails(BillsRequestApi requestAPI);

        Response GetAllBills(BillsRequestApi requestAPI);

        Response GetBillsByBillId(BillsRequestApi requestAPI);

        Response PutBillsDetails(BillsRequestApi requestAPI);
    }
}
