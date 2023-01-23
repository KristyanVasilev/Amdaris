namespace BookShop.Presentantion.Filters
{
    using BookShop.Application.SeedWork.Exceptions;
    using BookShop.Presentantion.Contracts;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;

    public class GlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var statusCode = 500;

            if (context.Exception is GameNotFoundException || context.Exception is PublicationNotFoundException || context.Exception is WritingUtensilNotFoundException)
            {
                statusCode = 404;
            }

            if (context.Exception is ProductDontHaveEnoughQuantity)
            {
                statusCode = 401;
            }

            var error = new Error
            {
                StatusCode = statusCode,
                TimeSpan = DateTime.UtcNow,
            };
            error?.Message?.Add(context.Exception.Message);

            context.Result = new JsonResult(error) { StatusCode = statusCode };
        }
    }
}
