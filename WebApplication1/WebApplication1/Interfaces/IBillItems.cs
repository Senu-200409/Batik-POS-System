using POS_System.Models;
using POS_System.Models.RequestApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_System.Interfaces
{
    public interface IBillItems
    {
        Response AddBillItemsDetails(BillItemsRequestApi requestAPI);

        Response GetAllBillItems(BillItemsRequestApi requestAPI);

        Response GetBillItemsByBillItemsId(BillItemsRequestApi requestAPI);

        Response PutBillItemsDetails(BillItemsRequestApi requestAPI);
    }
}
