using System.ComponentModel.DataAnnotations;
using KZ.Entity.Models.Data.General;

namespace KZ.Entity.Models.Data
{
    public class ProductImage : BaseEntity
    {
        [Required, StringLength(155)]
        public string Image { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public int SequenceNumber { get; set; }

        public virtual Product Product { get; set; }

    }
}
