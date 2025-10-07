using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KZ.Entity.Models.Data
{
    public class UserType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required, StringLength(20)]
        public string Name { get; set; }

        //Bir tipin birden fazla kullanıcısı olabilir anlamına gelmektedir.
        public virtual List<User> Users { get; set; }
    }
}
