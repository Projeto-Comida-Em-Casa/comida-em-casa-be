using ComidaEmCasa.Model.Enums;

namespace ComidaEmCasa.Model.Info
{
    public class InstituteInfo : BaseInfo
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public InstituteCategoryEnum Category { get; set; }
        public string LogoPath { get; set; }
        public int OwernId { get; set; }
        public UserInfo Owner { get; set; }
    }
}
