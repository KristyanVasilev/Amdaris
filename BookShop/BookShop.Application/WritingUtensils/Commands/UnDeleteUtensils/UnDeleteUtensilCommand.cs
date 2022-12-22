namespace BookShop.Application.WritingUtensils.Commands.UnDeleteUtensils
{
    using MediatR;

    public class UnDeleteUtensilCommand : IRequest<WritingUtensilDto>
    {
        public UnDeleteUtensilCommand(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }
    }
}
