using System.ComponentModel.DataAnnotations.Schema;

namespace TeamManager.Domain.Entities
{
    [Table("team")]
    public class Team : BaseEntity
    {
        [Column("name")]
        public string Name { get; set; }
    }
}
