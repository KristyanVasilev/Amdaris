namespace BookShop.Presentantion.Filters
{
    using BookShop.Presentantion.Contracts;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;

    public class GlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var error = new Error
            {
                StatusCode = "500",
                TimeSpan = DateTime.UtcNow,
            };
            error?.Message?.Add(context.Exception.Message);

            context.Result = new JsonResult(error) { StatusCode = 500 };
        }
    }
}
