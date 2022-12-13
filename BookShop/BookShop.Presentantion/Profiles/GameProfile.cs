namespace BookShop.Presentantion.Profiles
{
    using AutoMapper;
    using BookShop.Application.Games;
    using BookShop.Application.Games.Commands.CreateGame;
    using BookShop.Presentantion.Dto;

    public class GameProfile : Profile
    {
        public GameProfile()
        {
            CreateMap<GameDto, GameGetDto>();

            CreateMap<GamePostDto, CreateGameCommand>();
        }
    }
}
