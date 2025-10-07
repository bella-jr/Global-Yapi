using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KZ.Entity.Models.Data
{
    public class HomePageContent
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public string Content1 { get; set; }

        public string Content2 { get; set; }

        public string Content3 { get; set; }

        public string Content4 { get; set; }
        public string Content5 { get; set; }

        [Required]
        public int LanguageId { get; set; }

        public virtual Language Language { get; set; }
    }
}
