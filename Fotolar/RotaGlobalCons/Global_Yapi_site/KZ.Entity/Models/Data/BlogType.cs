using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KZ.Entity.Models.Data
{
    public class BlogType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string Name { get; set; }

        public virtual List<Blog> Blogs { get; set; }
    }
}
