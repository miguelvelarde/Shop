﻿namespace Shop.Web.Helpers
{
    using System.Threading.Tasks;
    using Data.Entities;
    using Microsoft.AspNetCore.Identity;

    public interface IUserHelper
    {
        public Task<User> GetUserByEmailAsync(string email);

        public Task<IdentityResult> AddUserAsync(User user, string password);
    }
}
