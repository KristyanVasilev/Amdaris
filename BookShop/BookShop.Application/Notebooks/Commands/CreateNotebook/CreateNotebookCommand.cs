namespace BookShop.Application.Notebooks.Commands.CreateNotebook
{
    using MediatR;

    public class CreateNotebookCommand : BaseProductModel, IRequest<int>
    {
        public string Color { get; set; } = null!;

        public string Manufacturer { get; set; } = null!;

        public int PageCount { get; set; }

        public string LineType { get; set; } = null!;
    }
}
