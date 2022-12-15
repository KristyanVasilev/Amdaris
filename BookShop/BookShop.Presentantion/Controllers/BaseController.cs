namespace BookShop.Presentantion.Controllers
{
    using AutoMapper;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    public class BaseController<T> : ControllerBase where T : BaseController<T>
    {
        private ILogger<T>? logger;
        private IMapper? mapper;
        private IMediator? mediator;

        protected ILogger<T> Logger
            => this.logger ??= HttpContext.RequestServices.GetRequiredService<ILogger<T>>();

        protected IMapper Mapper
            => this.mapper ??= HttpContext.RequestServices.GetRequiredService<IMapper>();

        protected IMediator Mediator
            => this.mediator ??= HttpContext.RequestServices.GetRequiredService<IMediator>();
    }
}
