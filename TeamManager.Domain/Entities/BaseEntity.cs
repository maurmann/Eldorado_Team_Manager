using System.ComponentModel.DataAnnotations.Schema;

namespace TeamManager.Domain.Entities
{
    public abstract class BaseEntity
    {
        [Column("id")]
        public int Id { get; set; }
    }
}
