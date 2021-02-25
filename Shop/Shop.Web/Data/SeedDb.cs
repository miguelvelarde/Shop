﻿namespace Shop.Web.Data
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Entities;

    public class SeedDb
    {
        private readonly DataContext context;
        private Random random;

        public SeedDb(DataContext context)
        {
            this.context = context;
            this.random = new Random();

        }

        public async Task SeedAsync() 
        {
            await this.context.Database.EnsureCreatedAsync();

            if (!this.context.Products.Any()) 
            {
                this.AddProduct("IPhone X");
                this.AddProduct("Magic Mouse");
                this.AddProduct("IWatch Series 4");
            }
        }

        private void AddProduct(string name)
        {
            this.context.Products.Add(new Product
            {
                Name = name,
                Price = this.random.Next(100),
                IsAvailable = true,
                Stock = this.random.Next(100)
            });
        }
    }
}
