using System;
using System.ComponentModel.DataAnnotations;
using KZ.Entity.Models.Data.General;

namespace KZ.Entity.Models.Data
{
    public class ExternalArticle : BaseEntity, IAuiditEntity
    {
        [Required, StringLength(150)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public bool IsStatus { get; set; }

        public bool IsGoogleIndex { get; set; }

        [Required, StringLength(250)]
        public string Link { get; set; }

        [Required]
        public int GalleryId { get; set; }

        [Required]
        public int LanguageId { get; set; }

        [Required, StringLength(300)]
        public string SeoTitle { get; set; }

        [Required, StringLength(300)]
        public string SeoDescription { get; set; }

        [Required, StringLength(300)]
        public string SeoKeywords { get; set; }

        public DateTime CreationDate { get; set; }

        public virtual Language Language { get; set; }
    }
}