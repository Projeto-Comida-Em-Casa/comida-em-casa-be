using System.ComponentModel.DataAnnotations;

namespace ComidaEmCasa.Model.DTO
{
    public class CreateUserDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        [RegularExpression("(\\d{3})(\\d{3})(\\d{3})(\\d{2})")]
        public string Cpf { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(35, MinimumLength = 8)]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        [StringLength(35, MinimumLength = 8)]
        public string ConfirmPassword { get; set; }
        public string Cellphone { get; set; }
    }
}
