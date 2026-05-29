using POS_System.Models;
using POS_System.Models.RequestApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_System.Interfaces
{
    public interface IProducts
    {
        Response GetAllProducts(ProductsRequestApi requestAPI);
        Response GetProductsByProductId(ProductsRequestApi requestAPI);
        Response AddProductsDetails(ProductsRequestApi requestAPI);
        Response PutProductsDetails(ProductsRequestApi requestAPI);
    }
}
