namespace BookShop.Presentantion.Profiles
{
    using AutoMapper;
    using BookShop.Application.Publications;
    using BookShop.Domain;
    using BookShop.Presentantion.Dto;

    public class PublicationProfile : Profile
    {
        public PublicationProfile()
        {
            CreateMap<Publication, PublicationGetDto>();
            CreateMap<PublicationGetDto, Publication>();

        }
    }
}
