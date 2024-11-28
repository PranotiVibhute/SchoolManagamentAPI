using Asp.NetFirstCodeEF.Context;
using Asp.NetFirstCodeEF.Entities;
using Asp.NetFirstCodeEF.Interface;
using Microsoft.EntityFrameworkCore;

namespace Asp.NetFirstCodeEF.Services
{
    public class CustomerService:ICustomer
    {
        private readonly SchoolDbContext _dbContext;
        public CustomerService(SchoolDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Customer>> GetAllCustomer()
        {
            return await _dbContext.Customers.ToListAsync();
        }

    }
}
