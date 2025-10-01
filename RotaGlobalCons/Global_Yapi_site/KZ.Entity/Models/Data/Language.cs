using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KZ.Entity.Models.Data
{
    public class Language
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string Name { get; set; }

        public virtual List<Article> Articles { get; set; }

        public virtual List<Menu> Menus { get; set; }

        public virtual List<Blog> Blogs { get; set; }

        public virtual List<Product> Products { get; set; }

        public virtual List<PropertyGroup> PropertyGroups { get; set; }

        public virtual List<Slider> Sliders { get; set; }

        public virtual List<TabFilter> TabFilters { get; set; }

        public virtual List<ExternalArticle> ExternalArticles { get; set; }

        public virtual List<HomePageContent> HomePageContents { get; set; }

        public virtual List<Reference> References { get; set; }
    }
}