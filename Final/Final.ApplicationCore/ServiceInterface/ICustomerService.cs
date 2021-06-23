using Final.ApplicationCore.Entitity;
using Final.ApplicationCore.Model.Request;
using Final.ApplicationCore.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.ApplicationCore.ServiceInterface
{
    public interface ICustomerService
    {

        Task<Customer> GetCustomerById(int id);
        Task<Customer> UpdateCustomer(int id, CustomerRegisterRequestModel customer);
        Task DeleteCustomerById(int id);
        Task<bool> AddCustomer(CustomerRegisterRequestModel customer);
        Task<IEnumerable<Customer>> ListAll();
        Task<Customer> GetCustomerByEmail(string email);

    }
}
