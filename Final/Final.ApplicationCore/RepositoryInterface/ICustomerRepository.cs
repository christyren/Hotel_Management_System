using Final.ApplicationCore.Entitity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final.ApplicationCore.Model.Request;
using System.Linq.Expressions;
using Final.ApplicationCore.Model.Response;
namespace Final.ApplicationCore.RepositoryInterface
{
    public interface ICustomerRepository
    {
        Task<Customer> GetCustomerByEmail(string email);
        Task<Customer> UpdateCustomer(int id, CustomerRegisterRequestModel customer);
        Task<Customer> GetByIdAsync(int Id); // return one record under certain class on corresponding Id

        //Creating
        Task<Customer> AddAsync(Customer entity);

        //Updating
        Task<Customer> UpdateAsync(Customer entity);

        //Delete
        Task DeleteAsync(Customer entity);

        Customer GetEntityById(int Id);
        //show all
        Task<IEnumerable<Customer>> ListAllAsync(); // return all records under certain class
        Task<IEnumerable<Customer>> ListAsync(Expression<Func<Customer, bool>> filter);

    }
}
