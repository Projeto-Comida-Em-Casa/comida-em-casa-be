using ComidaEmCasa.Model.Enums;

namespace ComidaEmCasa.Model.DTO
{
    public class InstituteDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public InstituteCategoryEnum Category { get; set; }
        public string LogoPath { get; set; }
    }
}
