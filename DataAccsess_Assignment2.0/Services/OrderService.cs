using AutoMapper;
using DataAccsess_Assignment2._0.Data;
using DataAccsess_Assignment2._0.Data.Entity;
using DataAccsess_Assignment2._0.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccsess_Assignment2._0.Services
{
    public interface IOrderService
    {
        public Task<OrderModel> PostAsync(OrderModel order);
        public Task<IEnumerable<OrderModel>> GetAllAsync();

        public Task<bool> DeleteAsync(int id);
    }
    public class OrderService : IOrderService
    {
        private readonly DataContext _context;
        private readonly IMapper _map;

        public OrderService(DataContext context, IMapper map)
        {
            _context = context;
            _map = map;
        }

        public async Task<OrderModel> PostAsync(OrderModel order)
        {
            var orderEntity = _map.Map<OrderEntity>(order);

            await _context.Orders.AddAsync(orderEntity);
            await _context.SaveChangesAsync();

            return new OrderModel
            {
                OrderDate = new DateTime(),
                OrderStatus = order.OrderStatus,
                OrderQuantity = order.OrderQuantity,
                Customer = new CustomerModel
                {
                    FirstName = order.Customer.FirstName,
                    LastName= order.Customer.LastName,
                },
                Product = new ProductModel
                {
                    ProductName = order.Product.ProductName
                }
            };
        }

        public async Task<IEnumerable<OrderModel>> GetAllAsync()
        {
            return _map.Map<IEnumerable<OrderModel>>(await _context.Product.Include(x => x.ProductName).ToListAsync());
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var customerEntity = await _context.Product.FindAsync(id);
            if (customerEntity != null)
            {
                _context.Product.Remove(customerEntity);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
