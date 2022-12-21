namespace BookShop.Presentantion.Filters
{
    using System.ComponentModel.DataAnnotations;

    public class ValidateUrlsInArrayAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string[] array = value as string[];

            foreach (var item in array)
            {
                bool result = Uri.TryCreate(item, UriKind.Absolute, out Uri uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

                if (!result)
                {
                    return new ValidationResult(this.ErrorMessage);
                }
            }

            return ValidationResult.Success;
        }
    }
}
