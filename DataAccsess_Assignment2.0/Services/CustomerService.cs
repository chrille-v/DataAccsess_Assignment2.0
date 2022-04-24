using AutoMapper;
using DataAccsess_Assignment2._0.Data;
using DataAccsess_Assignment2._0.Data.Entity;
using DataAccsess_Assignment2._0.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccsess_Assignment2._0.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly DataContext _context;
        private readonly IMapper _map;

        public CustomerService(DataContext context, IMapper map)
        {
            _context = context;
            _map = map;
        }

        public async Task<CustomerModel> PostAsync(CustomerModel customer)
        {
            if (!await _context.Customer.AnyAsync(x => x.Email == customer.Email))
            {
                var customerEntity = _map.Map<CustomerEntity>(customer);
                
                customerEntity.Address = new AddressEntity 
                { 
                    Address = customer.Address.Address, 
                    City = customer.Address.City, 
                    PostalCode = customer.Address.PostalCode 
                };
                

                await _context.Customer.AddAsync(customerEntity);
                await _context.SaveChangesAsync();

                return new CustomerModel
                {
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    Email = customer.Email,
                    Address = new AddressModel
                    {
                        Address = customer.Address.Address,
                        City = customer.Address.City,
                        PostalCode = customer.Address.PostalCode,
                    }
                };
            }

            return null!;
        }

        public async Task<IEnumerable<CustomerModel>> GetAllAsync()
        {
            
            return _map.Map<IEnumerable<CustomerModel>>(await _context.Customer.Include(x => x.Address).ToListAsync());
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var customerEntity = await _context.Customer.FindAsync(id);
            if (customerEntity != null)
            {
                _context.Customer.Remove(customerEntity);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<CustomerModel> UpdateCustomerAsync(int id, CustomerModel customer)
        {
            var customerEntity = await _context.Customer.FirstOrDefaultAsync(x => x.CustomerId == id);
            if (customerEntity != null)
            {
                if (customerEntity.FirstName != customer.FirstName && !string.IsNullOrEmpty(customer.FirstName))
                    customer.FirstName = customer.FirstName;

                if (customerEntity.LastName != customer.LastName && !string.IsNullOrEmpty(customer.LastName))
                    customer.LastName = customer.LastName;


                if (customerEntity.Email != customer.Email && !string.IsNullOrEmpty(customer.Email))
                    customer.Email = customer.Email;

                _context.Entry(customerEntity).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return _map.Map<CustomerModel>(customerEntity);
            }

            return null!;
        }
    }
}
