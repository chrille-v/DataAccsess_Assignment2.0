using DataAccsess_Assignment2._0.Models;

namespace DataAccsess_Assignment2._0.Services
{
    public interface ICustomerService
    {
        public Task<CustomerModel> PostAsync(CustomerModel customer);
        public Task<IEnumerable<CustomerModel>> GetAllAsync();
        public Task<CustomerModel> UpdateCustomerAsync(int id, CustomerModel customer);

        public Task<bool> DeleteAsync(int id);

    }
}
