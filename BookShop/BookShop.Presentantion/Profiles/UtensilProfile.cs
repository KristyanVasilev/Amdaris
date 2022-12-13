namespace BookShop.Presentantion.Profiles
{
    using AutoMapper;
    using BookShop.Application.WritingUtensils;
    using BookShop.Application.WritingUtensils.Commands.CreateUtensils;
    using BookShop.Presentantion.Dto;

    public class UtensilProfile : Profile
    {
        public UtensilProfile()
        {
            CreateMap<WritingUtensilDto, UtensilGetDto>();

            CreateMap<UtensilPostDto, CreateUtensilsCommand>();
        }
    }
}
