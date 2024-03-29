﻿namespace BookShop.Application.Games
{
    public class GameDto : BaseProductDto
    {
        public string Manufacturer { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string Genre { get; set; } = null!;

        public string[] Images { get; set; } = null!;
    }
}
