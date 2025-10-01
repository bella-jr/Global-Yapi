using System.ComponentModel.DataAnnotations;
using KZ.Entity.Models.Data.General;

namespace KZ.Entity.Models.Data
{
    public class ProductProperty : BaseEntity
    {
        [Required, StringLength(50)]
        public string Value { get; set; }

        [Required]
        public int PropertyId { get; set; }

        [Required]
        public int GrupId { get; set; }

        [Required]
        public int ProductId { get; set; }

        public virtual Property Property { get; set; }

        public virtual Product Product { get; set; }
    }
}
