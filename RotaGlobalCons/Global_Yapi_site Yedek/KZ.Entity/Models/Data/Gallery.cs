using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using KZ.Entity.Models.Data.General;

namespace KZ.Entity.Models.Data
{
    public class Gallery : BaseEntity, IAuiditEntity
    {

        [Required, StringLength(50)]
        public string Name { get; set; }

        [Required, StringLength(155)]
        public string Image { get; set; }

        [Required]
        public bool IsStatus { get; set; }
        
        public bool IsHome { get; set; }

        public int SequenceNumber { get; set; }

        public DateTime CreationDate { get; set; }

        public virtual List<GalleryImage> GalleryImages { get; set; }

    }
}
