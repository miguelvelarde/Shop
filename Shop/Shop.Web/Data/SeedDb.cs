namespace Shop.Web.Data
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using Entities;

    public class SeedDb
    {
        private readonly DataContext context;
        private readonly UserManager<User> userManager;
        private Random random;

        public SeedDb(DataContext context, UserManager<User> userManager)
        {
            this.context = context;
            this.userManager = userManager;
            this.random = new Random();

        }

        public async Task SeedAsync() 
        {
            await this.context.Database.EnsureCreatedAsync();

            var user = await this.userManager.FindByEmailAsync("mvelarde@astrum.com.mx");
            
            if (user == null) 
            {
                user = new User
                {
                    FirstName = "Miguel",
                    LastName = "Velarde",
                    Email = "mvelarde@astrum.com.mx",
                    UserName = "mvelarde@astrum.com.mx"
                };

                var result = await this.userManager.CreateAsync(user, "mvelarde01");
                if (result != IdentityResult.Success) 
                {
                    throw new InvalidOperationException("Could not create user in seeder");
                }
            }

            if (!this.context.Products.Any()) 
            {
                this.AddProduct("IPhone X", user);
                this.AddProduct("Magic Mouse", user);
                this.AddProduct("IWatch Series 4", user);
                await this.context.SaveChangesAsync();
            }
        }

        private void AddProduct(string name, User user)
        {
            this.context.Products.Add(new Product
            {
                Name = name,
                Price = this.random.Next(100),
                IsAvailable = true,
                Stock = this.random.Next(100),
                User = user
            });
        }
    }
}
