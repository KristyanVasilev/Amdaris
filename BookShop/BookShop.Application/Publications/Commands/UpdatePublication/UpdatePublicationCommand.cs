using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Application.Publications.Commands.UpdatePublication
{
    public class UpdatePublicationCommand : BaseProductDto, IRequest<int>
    {
        public int Id { get; set; }

        public string Author { get; set; } = null!;

        public int PageCount { get; set; }

        public double Rating { get; set; }

        public string Description { get; set; } = null!;

        public string PublicationType { get; set; } = null!;

        public GenreDto Genre { get; set; } = null!;
    }
}
