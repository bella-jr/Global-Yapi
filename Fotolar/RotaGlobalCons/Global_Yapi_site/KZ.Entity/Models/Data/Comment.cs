using KZ.Entity.Models.Data.General;
using System;
using System.ComponentModel.DataAnnotations;

namespace KZ.Entity.Models.Data
{
    public class Comment : BaseEntity, IAuiditEntity
    {
        [Required, StringLength(150)]
        public string Name { get; set; }

        [Required, StringLength(150)]
        public string Surname { get; set; }

        public string Description { get; set; }

        public bool IsView { get; set; }

        public bool IsHome { get; set; }

        public DateTime CreationDate { get; set; }
    }
}
