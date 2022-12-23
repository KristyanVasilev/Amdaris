namespace BookShop.Presentantion.Filters
{
    using BookShop.Presentantion.Contracts;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;

    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var apiError = new Error
                {
                    StatusCode = 400,
                    TimeSpan = DateTime.UtcNow,
                };
                var errors = context.ModelState.AsEnumerable();


                foreach (var error in errors)
                {
                    foreach (var inner in error.Value.Errors)
                    {
                        apiError.Message.Add(inner.ErrorMessage);
                    }
                }

                context.Result = new BadRequestObjectResult(apiError);
            }
        }
    }
}
