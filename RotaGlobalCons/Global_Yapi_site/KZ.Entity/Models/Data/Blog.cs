using System;
using System.ComponentModel.DataAnnotations;
using KZ.Entity.Models.Data.General;

namespace KZ.Entity.Models.Data
{
    public class Blog : BaseEntity, IAuiditEntity
    {
        [Required, StringLength(150)]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required, StringLength(155)]
        public string Image { get; set; }

        public bool IsStatus { get; set; }

        public bool IsDetail { get; set; }

        [Required, StringLength(250)]
        public string Link { get; set; }

        public int BlogTypeId { get; set; }

        public int GalleryId { get; set; }

        public int LanguageId { get; set; }

        public int SequenceNumber { get; set; }

        [Required, StringLength(300)]
        public string SeoTitle { get; set; }

        [StringLength(300)]
        public string SeoDescription { get; set; }

        [StringLength(300)]
        public string SeoKeywords { get; set; }

        public DateTime CreationDate { get; set; }

        public virtual BlogType BlogType { get; set; }

        public virtual Language Language { get; set; }
    }
}
