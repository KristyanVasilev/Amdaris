namespace BookShop.Application.Users.Commands.CreateApplicatioUser
{
    using BookShop.Domain.ApplicationUser;
    using MediatR;

    public class CreateApplicationUserHandler : IRequestHandler<CreateApplicationUserCommand, int>
    {
        private readonly IApplicationUserRepository repository;

        public CreateApplicationUserHandler(IApplicationUserRepository repository)
        {
            this.repository = repository;
        }

        public Task<int> Handle(CreateApplicationUserCommand command, CancellationToken cancellationToken)
        {
            var user = new ApplicationUser
            {
                Id= command.Id,
                FirstName = command.FirstName,
                LastName = command.LastName,
                Email = command.Email,
            };

            this.repository.CreateUser(user);

            return Task.FromResult(user.Id);
        }
    }
}
