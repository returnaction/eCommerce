using AutoMapper;
using FullStackAuth_WebAPI.DataTransferObjects;
using FullStackAuth_WebAPI.Models;

namespace FullStackAuth_WebAPI.Managers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserForRegistrationDto, User>();
            CreateMap<User, UserForDisplayDto>();
            CreateMap<Product, ProductForDisplayDto>();
            CreateMap<ProductImage, ProductImageForDisplayDto>();
            CreateMap<Purchase, PurchaseForDisplayDto>();
            CreateMap<ProfileImage, ProfileImageforDisplayDto>();
            CreateMap<ReviewImage, ReviewImageForDisplayDto>();
            CreateMap<Review, ReviewForDisplayDto>();
        }
    }
}
//5612909609