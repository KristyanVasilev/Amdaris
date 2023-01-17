namespace BookShop.Presentantion.Profiles
{
    using AutoMapper;
    using BookShop.Application.Orders;
    using BookShop.Application.Orders.Commands.CreateOrder;
    using BookShop.Domain;
    using BookShop.Presentantion.DTOs;

    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<OrderPostDto, CreateOrderCommand>()
                     .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products))
                     .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => src.TotalPrice));

            CreateMap<OrderPostDto, OrderDto>()
                     .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products))
                     .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => src.TotalPrice));

            CreateMap<ProductPostDto, Product>();
        }
    }
}

