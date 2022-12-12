namespace BookShop.Presentantion.Profiles
{
    using AutoMapper;
    using BookShop.Application.Publications;
    using BookShop.Presentantion.Dto;

    public class PublicationProfile : Profile
    {
        public PublicationProfile()
        {
            CreateMap<PublicationDto, PublicationGetDto>();
        }
    }
}
