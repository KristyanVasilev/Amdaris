namespace BookShop.Presentantion.Profiles
{
    using AutoMapper;
    using BookShop.Application.Publications;
    using BookShop.Application.Publications.Commands.CreatePublication;
    using BookShop.Application.Publications.Commands.UpdatePublication;
    using BookShop.Presentantion.Dto;

    public class PublicationProfile : Profile
    {
        public PublicationProfile()
        {
            CreateMap<PublicationDto, PublicationGetDto>();

            CreateMap<PublicationPostDto, CreatePublicationCommand>();

            CreateMap<PublicationPutDto, UpdatePublicationCommand>();
        }
    }
}
