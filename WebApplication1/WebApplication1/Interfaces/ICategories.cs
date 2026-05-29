using POS_System.Models;
using POS_System.Models.RequestApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_System.Interfaces
{
    public interface ICategories
    {
        Response AddCategoriesDetails(CategoriesRequestApi requestAPI);

        Response GetAllCategories(CategoriesRequestApi requestAPI);

        Response GetCategoriesByCategoryId(CategoriesRequestApi requestAPI);

        Response PutCategoriesDetails(CategoriesRequestApi requestAPI);
    }
}
