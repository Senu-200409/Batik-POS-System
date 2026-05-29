using POS_System.Models;
using POS_System.Models.RequestApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_System.Interfaces
{
    public interface ISubCategories
    {
        Response GetAllSubCategories(SubCategoriesRequestApi requestAPI);
        Response GetSubCategoriesBySubCategoryId(SubCategoriesRequestApi requestAPI);
        Response AddSubCategoriesDetails(SubCategoriesRequestApi requestAPI);
        Response PutSubCategoriesDetails(SubCategoriesRequestApi requestAPI);
    }
}
