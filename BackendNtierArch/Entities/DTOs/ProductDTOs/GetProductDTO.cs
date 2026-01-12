using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs.ProductDTOs
{
    public class GetProductDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
