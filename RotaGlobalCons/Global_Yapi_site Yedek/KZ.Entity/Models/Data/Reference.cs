using KZ.Entity.Models.Data.General;
using System;
using System.ComponentModel.DataAnnotations;

namespace KZ.Entity.Models.Data
{
    public class Reference : BaseEntity, IAuiditEntity
    {
        [Required, StringLength(250)]
        public string Title { get; set; }

        [Required, StringLength(155)]
        public string Image { get; set; }

        public bool IsStatus { get; set; }

        public byte TypeId { get; set; }

        public byte LanguageId { get; set; }

        public int SequenceNumber { get; set; }

        public DateTime CreationDate { get; set; }

        public virtual Language Language { get; set; }
    }
}
