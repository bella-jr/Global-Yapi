using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using KZ.Entity.Models.Data.General;

namespace KZ.Entity.Models.Data
{
    public class Property : BaseEntity
    {
        [Required, StringLength(50)]
        public string Name { get; set; }

        [Required, StringLength(50)]
        public string Icon { get; set; }

        [Required]
        public int PropertyGroupId { get; set; }

        [Required]
        public int SequenceNumber { get; set; }

        public virtual PropertyGroup PropertyGroup { get; set; }

        public List<ProductProperty> ProductProperties { get; set; }

    }
}
