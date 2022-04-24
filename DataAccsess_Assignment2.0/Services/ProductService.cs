using AutoMapper;
using DataAccsess_Assignment2._0.Data;
using DataAccsess_Assignment2._0.Data.Entity;
using DataAccsess_Assignment2._0.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccsess_Assignment2._0.Services
{
    public interface IProductService
    {
        public Task<ProductModel> PostAsync(ProductModel product);
        public Task<IEnumerable<ProductModel>> GetAllAsync();

        public Task<ProductModel> UpdateProductAsync(int id , ProductModel product);

        public Task<bool> DeleteAsync(int id);

    }
    public class ProductService : IProductService
    {
        private readonly DataContext _context;
        private readonly IMapper _map;

        public ProductService(DataContext context, IMapper map)
        {
            _context = context;
            _map = map;
        }

        public async Task<ProductModel> PostAsync(ProductModel product)
        {
            if (!await _context.Product.AnyAsync(x => x.ProductName == product.ProductName))
            {
                var productEntity = _map.Map<ProductEntity>(product);

                productEntity.Category = new CategoryEntity
                {
                    CategoryName = product.Category.CategoryName,
                };


                await _context.Product.AddAsync(productEntity);
                await _context.SaveChangesAsync();

                return new ProductModel
                {
                    ProductName = product.ProductName,
                    ArticleNumber = product.ArticleNumber,
                    Description = product.Description,
                    Price = product.Price,
                    Category = new CategoryModel
                    {
                        CategoryName = product.Category.CategoryName
                    }
                };
            }

            return null!;
        }

        public async Task<IEnumerable<ProductModel>> GetAllAsync()
        {
            return _map.Map<IEnumerable<ProductModel>>(await _context.Product.Include(x => x.Category).ToListAsync());
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

        public async Task<ProductModel> UpdateProductAsync(int id, ProductModel request)
        {
            var productEntity = await _context.Product.Include(x => x.Category).FirstOrDefaultAsync(x => x.ProductId == id);

            if (productEntity != null)
            {
                if (productEntity.ProductName != request.ProductName && !string.IsNullOrEmpty(request.ProductName))
                    productEntity.ProductName = request.ProductName;

                if (productEntity.Price != request.Price)
                    productEntity.Price = request.Price;

                if (productEntity.Description != request.Description)
                    productEntity.Description = request.Description;

                if (productEntity.Category.CategoryName != request.Category.CategoryName && !string.IsNullOrEmpty(request.Category.CategoryName))
                {
                    var categoryEntity = await _context.Category.FirstOrDefaultAsync(x => x.CategoryName == request.Category.CategoryName);
                    if (categoryEntity == null)
                    {
                        categoryEntity = new CategoryEntity { CategoryName = request.Category.CategoryName };
                        _context.Category.Add(categoryEntity);
                        await _context.SaveChangesAsync();
                    }

                    productEntity.Category.CategoryId = categoryEntity.CategoryId;
                }

                _context.Entry(productEntity).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return _map.Map<ProductModel>(productEntity);
            }

            return null!;
        }
    }
}
