using AutoMapper;
using DataAccsess_Assignment2._0.Data.Entity;
using DataAccsess_Assignment2._0.Models;

namespace DataAccsess_Assignment2._0.Profiles
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<CustomerEntity, CustomerModel>();
            CreateMap<CustomerModel, CustomerEntity>();

            CreateMap<AddressEntity, AddressModel>();
            CreateMap<AddressModel, AddressEntity>();

            CreateMap<ProductEntity, ProductModel>();
            CreateMap<ProductModel, ProductEntity>();

            CreateMap<CategoryEntity, CategoryModel>();
            CreateMap<CategoryModel, CategoryEntity>();
        }
    }
}
