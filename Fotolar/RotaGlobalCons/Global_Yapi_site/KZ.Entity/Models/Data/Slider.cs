using System;
using System.ComponentModel.DataAnnotations;
using KZ.Entity.Models.Data.General;

namespace KZ.Entity.Models.Data
{
    public class Slider : BaseEntity, IAuiditEntity
    {
        [StringLength(500)]
        public string Title { get; set; }

        [StringLength(500)]
        public string Title2 { get; set; }

        [StringLength(500)]
        public string Title3 { get; set; }

        [StringLength(500)]
        public string Title4 { get; set; }

        [Required, StringLength(155)]
        public string Image { get; set; }

        [StringLength(250)]
        public string Link2 { get; set; }

        [StringLength(50)]
        public string ButtonTitle2 { get; set; }

        [StringLength(250)]
        public string Link { get; set; }

        [StringLength(50)]
        public string ButtonTitle { get; set; }

        public bool IsStatus { get; set; }

        public bool IsVideo { get; set; }

        public string DirectionType { get; set; }

        [Required]
        public int LanguageId { get; set; }

        [Required]
        public int SequenceNumber { get; set; }

        public bool IsExternal { get; set; }

        public DateTime CreationDate { get; set; }

        public virtual Language Language { get; set; }
    }
}
