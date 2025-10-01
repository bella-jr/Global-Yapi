using KZ.Entity.Models.Data.General;
using System;
using System.ComponentModel.DataAnnotations;

namespace KZ.Entity.Models.Data
{
    public class SSS : BaseEntity, IAuiditEntity
    {
        [Required, StringLength(150)]
        public string Question { get; set; }

        public string Answer { get; set; }

        public bool IsView { get; set; }

        public bool IsHome { get; set; }
        [Required]
        public int LanguageId { get; set; }

        public DateTime CreationDate { get; set; }
    }
}
