using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using KZ.Entity.Models.Data.General;

namespace KZ.Entity.Models.Data
{
    public class User : BaseEntity, IAuiditEntity
    {
        [Required, StringLength(50)]
        public string Name { get; set; }

        [Required, StringLength(50)]
        public string Surname { get; set; }

        [Required, StringLength(50)]
        public string Mail { get; set; }

        [Required]
        public bool IsMailVerify { get; set; }

        [Required]
        public bool IsStatus { get; set; }

        public bool IsView { get; set; }

        public bool IsDeleted { get; set; }

        [Required, StringLength(100)]
        public string Password { get; set; }

        [Required]
        public int TypeId { get; set; }

        public virtual UserType Type { get; set; } //Kullanıcının tek tipi olabilir anlamına gelmektedir.

        public virtual List<LoginLog> LoginLogs { get; set; }

        public DateTime CreationDate { get; set; }
    }
}
