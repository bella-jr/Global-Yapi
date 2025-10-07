using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KZ.Entity.Models.Data.General;

namespace KZ.Entity.Models.Data
{

    public class Article : BaseEntity, IAuiditEntity
    {
        [Required, StringLength(150)]
        [Column(Order = 2)]
        public string Title { get; set; }

        [Column(Order = 3)]
        public string Description { get; set; }

        [Required]
        [Column(Order = 4)]
        public bool IsStatus { get; set; }

        [Required, StringLength(300)]
        [Column(Order = 5)]
        public string SeoTitle { get; set; }

        [Required, StringLength(300)]
        [Column(Order = 6)]
        public string SeoDescription { get; set; }

        [Required, StringLength(300)]
        [Column(Order = 7)]
        public string SeoKeywords { get; set; }

        [Required]
        [Column(Order = 8)]
        public int MenuId { get; set; }

        [Required]
        [Column(Order = 9)]
        public int GalleryId { get; set; }

        [Required]
        [Column(Order = 10)]
        public int LanguageId { get; set; }

        public byte PageTypeId { get; set; }

        public virtual Menu Menu { get; set; }

        public DateTime CreationDate { get; set; }

        public virtual Language Language { get; set; }
    }
}
