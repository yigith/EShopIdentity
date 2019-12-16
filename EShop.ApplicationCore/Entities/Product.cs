using System;
using System.Collections.Generic;
using System.Text;

namespace EShop.ApplicationCore.Entities
{
    public class Product : BaseEntity
    {
        public int CategoryId { get; set; }

        public string ProductName { get; set; }

        public decimal UnitPrice { get; set; }

        public string ImagePath { get; set; }


        public Category Category { get; set; }
    }
}
