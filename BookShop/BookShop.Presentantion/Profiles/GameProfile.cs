namespace BookShop.Presentantion.Profiles
{
    using AutoMapper;
    using BookShop.Presentantion.Dto;
    using BookShop.Application.Games;
    using BookShop.Application.Games.Commands.CreateGame;

    public class GameProfile : Profile
    {
        public GameProfile()
        {
            CreateMap<GameDto, GameGetDto>();

            CreateMap<GamePostDto, CreateGameCommand>();
        }
    }
}
