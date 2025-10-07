using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KZ.Entity.Models.Data.General
{
    public class BaseEntity
    {
        [Key]
        [Column(Order = 1)]
        public int Id { get; set; }
    }
}
