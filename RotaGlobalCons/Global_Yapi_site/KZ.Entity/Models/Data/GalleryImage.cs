using System.ComponentModel.DataAnnotations;
using KZ.Entity.Models.Data.General;

namespace KZ.Entity.Models.Data
{
    public class GalleryImage : BaseEntity
    {
        [Required, StringLength(155)]
        public string Image { get; set; }

        [Required]
        public int GalleryId { get; set; }

        [Required]
        public int SequenceNumber { get; set; }

        public virtual Gallery Gallery { get; set; }
    }
}
