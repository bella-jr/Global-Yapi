using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using KZ.Entity.Models.Data.General;

namespace KZ.Entity.Models.Data
{
    public class TabFilter : BaseEntity, IAuiditEntity
    {
        [Required, StringLength(50)]
        public string Name { get; set; }

        public bool IsDefaultSelected { get; set; }

        public bool IsView { get; set; }

        [Required]
        public int LanguageId { get; set; }

        [Required]
        public int SequenceNumber { get; set; }

        public DateTime CreationDate { get; set; }

        public virtual Language Language { get; set; }

        public virtual List<TabFilterProduct> TabFilterProducts { get; set; }
    }
}
