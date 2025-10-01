using System;

namespace KZ.Entity.Models.Custom
{
    public class ArticleJoin
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public bool IsStatus { get; set; }

        public string SeoTitle { get; set; }

        public string SeoDescription { get; set; }

        public string SeoKeywords { get; set; }

        public int MenuId { get; set; }
        public int PageTypeId { get; set; }

        public int GalleryId { get; set; }

        public int LanguageId { get; set; }

        public DateTime CreationDate { get; set; }

        public string MenuName { get; set; }
    }
}
