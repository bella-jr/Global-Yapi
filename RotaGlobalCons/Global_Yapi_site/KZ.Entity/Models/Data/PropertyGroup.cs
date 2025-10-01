using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using KZ.Entity.Models.Data.General;

namespace KZ.Entity.Models.Data
{
    public class PropertyGroup : BaseEntity
    {
        [Required, StringLength(50)]
        public string Name { get; set; }

        [Required]
        public int LanguageId { get; set; }

        public virtual List<Property> Properties { get; set; }

        public virtual Language Language { get; set; }

    }
}
