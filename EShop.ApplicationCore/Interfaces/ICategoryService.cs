using EShop.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EShop.ApplicationCore.Interfaces
{
    public interface ICategoryService
    {
        List<Category> ListCategories();
    }
}
