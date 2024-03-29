﻿namespace BookShop.Application.Publications
{
    public class PublicationDto : BaseProductDto
    {
        public string Author { get; set; } = null!;

        public int PageCount { get; set; }

        public double Rating { get; set; }

        public string Description { get; set; } = null!;

        public string Genre { get; set; } = null!;

        public string[] Images { get; set; } = null!;
    }
}
