using ComidaEmCasa.Model.Enums;
using System.ComponentModel.DataAnnotations;

namespace ComidaEmCasa.Model.DTO
{
    public class CreateInstituteDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public InstituteCategoryEnum Category { get; set; }
        public string LogoPath { get; set; }
    }
}
