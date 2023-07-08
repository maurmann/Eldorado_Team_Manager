using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeamManager.Domain.Entities
{
    [Table("team")]
    public class Team : BaseEntity
    {
        [Column("name")]
        [Display(Name = "Nome")]
        [Required(AllowEmptyStrings=false,ErrorMessage = "Por favor informe o nome da equipe")]
        [StringLength(30,ErrorMessage = "O nome da equipe não pode possuir mais do que 30 caracteres")]
        public string Name { get; set; }
    }
}
