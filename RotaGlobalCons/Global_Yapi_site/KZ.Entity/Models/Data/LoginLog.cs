using System;
using System.ComponentModel.DataAnnotations;
using KZ.Entity.Models.Data.General;

namespace KZ.Entity.Models.Data
{
    public class LoginLog : BaseEntity, IAuiditEntity
    {
        [Required, StringLength(20)]
        public string Ip { get; set; }

        public DateTime CreationDate { get; set; }

        [Required]
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
