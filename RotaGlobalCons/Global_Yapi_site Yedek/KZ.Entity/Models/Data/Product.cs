using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using KZ.Entity.Models.Data.General;

namespace KZ.Entity.Models.Data
{
    public class Product : BaseEntity, IAuiditEntity
    {
        [Required, StringLength(50)]
        public string Code { get; set; }

        [Required, StringLength(150)]
        public string TopTitle { get; set; }

        [Required, StringLength(150)]
        public string Title { get; set; }

        [Required]
        public decimal Price { get; set; }

        public decimal Old_Price { get; set; }

        public decimal Havale_Price { get; set; }

        [Required]
        public int StartQuantity { get; set; }

        [Required, StringLength(155)]
        public string Image { get; set; }

        [Required, StringLength(155)]
        public string Image2 { get; set; }

        public string Description1 { get; set; }

        public string Description2 { get; set; }


        public bool IsStatus { get; set; }

        public bool IsPopular { get; set; }

        public bool IsNew { get; set; }

        public bool IsDiscount { get; set; }

        public bool IsStock { get; set; }

        public bool IsHome { get; set; }

        public bool IsMadeInTurkey { get; set; }

        public bool IsSoon { get; set; }

        public string Discount { get; set; }

        [StringLength(300)]
        public string SeoTitle { get; set; }

        [StringLength(300)]
        public string SeoDescription { get; set; }

        [StringLength(300)]
        public string SeoKeywords { get; set; }

        public int LanguageId { get; set; }

        public int ReferenceId { get; set; }

        public int PopularSequenceNumber { get; set; }

        public int HomeSequenceNumber { get; set; }

        public DateTime CreationDate { get; set; }

        public virtual List<ProductImage> ProductImages { get; set; }

        public virtual List<ProductMenu> ProductMenus { get; set; }

        public virtual List<ProductProperty> ProductProperties { get; set; }

        public virtual Language Language { get; set; }

        public virtual List<TabFilterProduct> TabFilterProducts { get; set; }

    }
}
