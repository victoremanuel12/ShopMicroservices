﻿namespace Catolog.API.Models
{
    public class Product
    {

        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public List<string> Category { get; set; } = new();
        public string Description { get; set; } = default!;
        public string ImageFile { get; set; } = default!;
        public decimal Price { get; set; }
        protected Product() { }
        public Product(Guid id, string name, List<string> category, string description, string imageFile, decimal price)
        {
            Id = id;
            Name = name;
            Category = category;
            Description = description;
            ImageFile = imageFile;
            Price = price;
        }
    }
}
