using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KZ.Entity.Models.Data
{
    public class GeneralSetting
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required, StringLength(155)]
        public string Logo { get; set; }

        [StringLength(250)]
        public string Address { get; set; }
        
        [StringLength(250)]
        public string Address2 { get; set; }

        [StringLength(20)]
        public string Phone { get; set; }

        [StringLength(20)]
        public string Phone2 { get; set; }

        [StringLength(20)]
        public string Phone3 { get; set; }

        [StringLength(20)]
        public string Phone4 { get; set; }

        [StringLength(50)]
        public string Whatsapp { get; set; }

        [StringLength(50)]
        public string Whatsapp2 { get; set; }

        [StringLength(20)]
        public string Fax { get; set; }

        [StringLength(50)]
        public string Mail { get; set; }

        [StringLength(50)]
        public string Mail2 { get; set; }

        [StringLength(300)]
        public string Facebook { get; set; }

        [StringLength(300)]
        public string Twitter { get; set; }

        [StringLength(300)]
        public string Google_Plus { get; set; }

        [StringLength(300)]
        public string Instagram { get; set; }

        [StringLength(300)]
        public string Youtube { get; set; }

        [StringLength(300)]
        public string Pinterest { get; set; }

        [StringLength(300)]
        public string Vk { get; set; }

        [StringLength(300)]
        public string Linkedin { get; set; }

        public string Code { get; set; }

        public string Maps { get; set; }

        public string PaymentDescription { get; set; }

        [StringLength(500)]
        public string SeoTitle { get; set; }

        [StringLength(500)]
        public string SeoDescription { get; set; }

        [StringLength(500)]
        public string SeoKeyword { get; set; }
    }
}
