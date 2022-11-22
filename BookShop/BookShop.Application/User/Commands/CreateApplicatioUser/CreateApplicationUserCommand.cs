namespace BookShop.Application.User.Commands.CreateApplicatioUser
{
    using MediatR;

    public class CreateApplicationUserCommand : IRequest<int>
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;
    }
}
