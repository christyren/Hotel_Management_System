using Final.ApplicationCore.Entitity;
using Final.ApplicationCore.Exceptions;
using Final.ApplicationCore.Model.Request;
using Final.ApplicationCore.Model.Response;
using Final.ApplicationCore.RepositoryInterface;
using Final.ApplicationCore.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.Infrastructure.Service
{
    public class CustomerService:ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;

        }

        public async Task<bool> AddCustomer(CustomerRegisterRequestModel customer)
        {
            var dbCustomer = await _customerRepository.GetCustomerByEmail(customer.Email);
            if (dbCustomer != null)
            {
                throw new ConflictException("Email already exists");
            }

            var c = new Customer
            {
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
            var createdCustomer = _customerRepository.AddAsync(c);

            if (createdCustomer != null && createdCustomer.Id > 0)
            {
                return true;
            }

            return false;
        }

        public async Task DeleteCustomerById(int id)
        {
            var res = _customerRepository.GetByIdAsync(id).Result;
            if (res == null)
            {
                Console.WriteLine("not found Client with Id:" + id);
            }
            else
            {
                await _customerRepository.DeleteAsync(res);
            }
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            return await _customerRepository.GetByIdAsync(id);
        }

        public Task<Customer> GetCustomerByEmail(string email)
        {
            return _customerRepository.GetCustomerByEmail(email);
        }

        public Task<IEnumerable<Customer>> ListAll()
        {
            return _customerRepository.ListAllAsync();
        }

        public async Task<Customer> UpdateCustomer(int id, CustomerRegisterRequestModel client)
        {
            return await _customerRepository.UpdateCustomer(id, client);

        }


    }
}
