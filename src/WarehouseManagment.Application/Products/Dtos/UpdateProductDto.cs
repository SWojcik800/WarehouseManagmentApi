﻿namespace WarehouseManagment.Application.Products.Dtos
{
    public class UpdateProductDto
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Manufacturer { get; set; }
    }
}
