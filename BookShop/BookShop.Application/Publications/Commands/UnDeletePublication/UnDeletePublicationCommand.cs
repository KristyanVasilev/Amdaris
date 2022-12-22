namespace BookShop.Application.Publications.Commands.UnDeletePublication
{
    using MediatR;

    public class UnDeletePublicationCommand : IRequest<PublicationDto>
    {
        public UnDeletePublicationCommand(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }
    }
}
