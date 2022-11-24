namespace BookShop.Application.Notebooks.Commands.CreateNotebook
{
    using BookShop.Domain.ForSchool.Notebooks.Enums;
    using BookShop.Domain.ForSchool.Notebooks;
    using MediatR;
    using BookShop.Application.Contracts;

    public class CreateNotebookHandler : IRequestHandler<CreateNotebookCommand, int>
    {
        private readonly INotebookRepository repository;

        public CreateNotebookHandler(INotebookRepository repository)
        {
            this.repository = repository;
        }

        public Task<int> Handle(CreateNotebookCommand request, CancellationToken cancellationToken)
        {
            var isEnumParsed = Enum.TryParse(request.LineType, true, out LineType parsedEnumValue);
            Console.WriteLine(isEnumParsed ? parsedEnumValue : throw new InvalidOperationException("Invalid enum type!"));

            var notebook = new Notebook
            {
                Id = request.Id,
                Price = request.Price,
                Name = request.Name,
                Color= request.Color,
                Manufacturer = request.Manufacturer,
                PageCount = request.PageCount,
                LineType = parsedEnumValue,
            };
            
            this.repository.CreateNotebook(notebook);

            return Task.FromResult(notebook.Id);
        }
    }
}
