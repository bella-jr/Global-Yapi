using System.ComponentModel.DataAnnotations;
using KZ.Entity.Models.Data.General;

namespace KZ.Entity.Models.Data
{
    public class SeoPage : BaseEntity
    {
        [Required]
        public string Url { get; set; }

        [Required, StringLength(300)]
        public string SeoTitle { get; set; }

        [Required, StringLength(300)]
        public string SeoDescription { get; set; }

        [Required, StringLength(300)]
        public string SeoKeywords { get; set; }
    }
}
