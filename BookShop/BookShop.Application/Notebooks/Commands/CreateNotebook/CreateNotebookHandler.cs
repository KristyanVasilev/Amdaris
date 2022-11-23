namespace BookShop.Application.Notebooks.Commands.CreateNotebook
{
    using BookShop.Domain.ForSchool.Notebooks.Enums;
    using BookShop.Domain.ForSchool.Notebooks;
    using MediatR;

    public class CreateNotebookHandler : IRequestHandler<CreateNotebookCommand, int>
    {
        private readonly IProductRepository repository;

        public CreateNotebookHandler(IProductRepository repository)
        {
            this.repository = repository;
        }

        public Task<int> Handle(CreateNotebookCommand command, CancellationToken cancellationToken)
        {
            var isEnumParsed = Enum.TryParse(command.LineType, true, out LineType parsedEnumValue);
            Console.WriteLine(isEnumParsed ? parsedEnumValue : throw new InvalidOperationException("Invalid enum type!"));

            var notebook = new Notebook
            {
                Id = command.Id,
                Price = command.Price,
                Name = command.Name,
                Color= command.Color,
                Manufacturer = command.Manufacturer,
                PageCount = command.PageCount,
                LineType = parsedEnumValue,
            };
            
            this.repository.CreateNotebook(notebook);

            return Task.FromResult(notebook.Id);
        }
    }
}
