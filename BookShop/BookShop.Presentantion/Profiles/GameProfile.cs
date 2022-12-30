namespace BookShop.Presentantion.Profiles
{
    using AutoMapper;
    using BookShop.Application.Games;
    using BookShop.Application.Games.Commands.CreateGame;
    using BookShop.Presentantion.DTOs;

    public class GameProfile : Profile
    {
        public GameProfile()
        {
            CreateMap<GameDto, GameGetDto>();

            CreateMap<GamePostDto, CreateGameCommand>();
        }
    }
}
