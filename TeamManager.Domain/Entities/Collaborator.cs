using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeamManager.Domain.Entities
{
    [Table("colaborator")]
    public class Collaborator
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        [Display(Name = "Nome")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Por favor informe o nome do colaborador")]
        [StringLength(50, ErrorMessage = "O nome do colaborador não pode possuir mais do que 50 caracteres")]
        public string Name { get; set; }

        [Column("email")]
        [Display(Name = "E-mail")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Por favor informe o e-mail do colaborador")]
        [StringLength(50, ErrorMessage = "O e-mail não pode possuir mais do que 50 caracteres")]
        [RegularExpression(@"/^[a-z0-9.]+@[a-z0-9]+\.[a-z]+\.([a-z]+)?$/i", ErrorMessage = "O e-mail informado não é válido.")]
        public string Email { get; set; }

        [Column("unit_id")]
        [Display(Name = "Unidade")]
        [Required(ErrorMessage = "Por favor selecione a unidade do colaborador")]
        public int UnitId { get; set; }

        [Column("Equipe")]
        [Display(Name = "team-id")]
        public int? TeamId { get; set; }
    }
}
