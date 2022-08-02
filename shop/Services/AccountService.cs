using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using shop.Models;
using shop.Services.Infrastructure;

namespace shop.Services
{
    public class AccountService:IAccountService
    {
        private readonly AppDbContext _DbContext;

        public AccountService(AppDbContext dbContext)
        {
            _DbContext = dbContext;
        }
    }
}