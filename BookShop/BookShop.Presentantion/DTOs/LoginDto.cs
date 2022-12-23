namespace BookShop.Presentantion.DTOs   
{
    using System.ComponentModel.DataAnnotations;

    public class LoginDto
    {
        [Required]
        public string UserName { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
    }
}
