using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KZ.Entity.Models.Data
{
    public class MailSetting
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Server { get; set; }

        [Required]
        public int Port { get; set; }

        [Required]
        public bool Ssl { get; set; }

        [Required, StringLength(100)]
        public string Account { get; set; }

        [Required, StringLength(100)]
        public string Password { get; set; }

        [Required, StringLength(100)]
        public string Address { get; set; }

        [Required, StringLength(100)]
        public string Title { get; set; }

        [Required, StringLength(100)]
        public string ContactMail { get; set; }

        [Required, StringLength(100)]
        public string OrderMail { get; set; }
    }
}
