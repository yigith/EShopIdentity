using EShop.ApplicationCore.Entities;
using EShop.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EShop.ApplicationCore.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> _categoryRepository;

        public CategoryService(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public List<Category> ListCategories()
        {
            return _categoryRepository.GetAll().ToList();
        }
    }
}
