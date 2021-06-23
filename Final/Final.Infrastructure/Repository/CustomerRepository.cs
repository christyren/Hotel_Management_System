using Final.ApplicationCore.Entitity;
using Final.ApplicationCore.Model.Request;
using Final.ApplicationCore.RepositoryInterface;
using Final.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Final.Infrastructure.Repository
{

    public class CustomerRepository : ICustomerRepository
    {
        private readonly FinalDbContext _dbContext;
        public CustomerRepository(FinalDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Customer> AddAsync(Customer entity)
        {
            _dbContext.Set<Customer>().Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
        public async Task DeleteAsync(Customer entity)
        {
            _dbContext.Set<Customer>().Remove(entity);

            await _dbContext.SaveChangesAsync();
        }
        public async Task<Customer> GetByIdAsync(int Id)
        {
            return await _dbContext.Set<Customer>().FindAsync(Id);
        }

        public async Task<Customer> GetCustomerByEmail(string email)
        {
            return await _dbContext.Customers.FirstOrDefaultAsync(m => m.Email == email);
        }

        public Customer GetEntityById(int Id)
        {
            return  _dbContext.Set<Customer>().Find(Id);
        }


        public async Task<IEnumerable<Customer>> ListAllAsync()
        {
            return await _dbContext.Set<Customer>().ToListAsync();
        }

        public async Task<IEnumerable<Customer>> ListAsync(Expression<Func<Customer, bool>> filter)
        {
            return await _dbContext.Set<Customer>().ToListAsync();
        }

        public async Task<Customer> UpdateAsync(Customer entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<Customer> UpdateCustomer(int id, CustomerRegisterRequestModel customer)
        {
            var local = _dbContext.Set<Customer>().Local.FirstOrDefault(c => c.Id == id);
            if (local != null) _dbContext.Entry(local).State = EntityState.Detached;
            var entity = new Customer
            { Id = id,
                RoomNo = customer.RoomNo,
                CName = customer.CName,
                Address = customer.Address,
                Phone = customer.Phone,
                Email = customer.Email,
                Checkin = customer.Checkin,
                TotalPersons = customer.TotalPersons,
                BookingDays = customer.BookingDays,
                Advance = customer.Advance
            };
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
