using EShop.ApplicationCore.Entities;
using EShop.ApplicationCore.Interfaces;
using EShop.Web.Interfaces;
using EShop.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Web.Services
{
    public class HomeIndexViewModelService : IHomeIndexViewModelService
    {
        private readonly IRepository<Category> _categoryRepository;
        private readonly IRepository<Product> _productRepository;
        public HomeIndexViewModelService(IRepository<Category> categoryRepository, IRepository<Product> productRepository)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
        }

        public HomeIndexViewModel GetHomeIndexViewModel(int pageIndex, int itemsPage, int? categoryId)
        {
            IQueryable<Product> queryProducts = _productRepository.GetAll();

            if (categoryId != null)
            {
                queryProducts = queryProducts.Where(x => x.CategoryId == categoryId);
            }

            var totalItems = queryProducts.Count();

            queryProducts = queryProducts.Skip((pageIndex - 1) * itemsPage).Take(itemsPage);
            var productsOnPage = queryProducts.Select(x => new ProductViewModel
            {
                Id = x.Id,
                ProductName = x.ProductName,
                UnitPrice = x.UnitPrice,
                ImagePath = x.ImagePath
            }).ToList();

            var vm = new HomeIndexViewModel
            {
                Categories = _categoryRepository.GetAll().Select(x => new CategoryViewModel
                {
                    Id = x.Id,
                    CategoryName = x.CategoryName,
                    ProductCount = x.Products.Count
                }).ToList(),
                Products = productsOnPage,
                PaginationInfo = new PaginationInfoViewModel
                {
                    ActualPage = pageIndex,
                    ItemsPerPage = productsOnPage.Count,
                    TotalItems = totalItems,
                    TotalPages = (int)Math.Ceiling((decimal)totalItems / itemsPage)
                }
            };

            vm.PaginationInfo.Next = (vm.PaginationInfo.ActualPage == vm.PaginationInfo.TotalPages) ? "passive" : " active";
            vm.PaginationInfo.Previous = (vm.PaginationInfo.ActualPage == 1) ? "passive" : "active";

            return vm;
        }
    }
}
