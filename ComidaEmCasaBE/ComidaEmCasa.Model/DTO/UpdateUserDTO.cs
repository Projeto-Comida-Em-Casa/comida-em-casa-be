using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ComidaEmCasa.Model.DTO
{
    public class UpdateUserDTO
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        [RegularExpression("(\\d{3})(\\d{3})(\\d{3})(\\d{2})")]
        public string Cpf { get; set; }
        public string Cellphone { get; set; }
    }
}
