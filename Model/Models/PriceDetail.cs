﻿namespace Model.Models
{
    public class PriceDetail
    {
        public string Code { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public decimal Total { get; set; }
    }
}