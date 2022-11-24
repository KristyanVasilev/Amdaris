namespace BookShop.Application.Users.Commands.CreateApplicatioUser
{
    using BookShop.Application.Contracts;
    using BookShop.Domain.ApplicationUser;
    using MediatR;

    public class CreateApplicationUserHandler : IRequestHandler<CreateApplicationUserCommand, int>
    {
        private readonly IApplicationUserRepository repository;

        public CreateApplicationUserHandler(IApplicationUserRepository repository)
        {
            this.repository = repository;
        }

        public Task<int> Handle(CreateApplicationUserCommand request, CancellationToken cancellationToken)
        {
            var user = new ApplicationUser
            {
                Id= request.Id,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
            };

            this.repository.CreateUser(user);

            return Task.FromResult(user.Id);
        }
    }
}
