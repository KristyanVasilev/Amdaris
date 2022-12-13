namespace BookShop.Presentantion.Profiles
{
    using AutoMapper;
    using BookShop.Presentantion.Dto;
    using BookShop.Application.Publications;
    using BookShop.Application.Publications.Commands.CreatePublication;
    using BookShop.Application.Publications.Commands.UpdatePublication;

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
