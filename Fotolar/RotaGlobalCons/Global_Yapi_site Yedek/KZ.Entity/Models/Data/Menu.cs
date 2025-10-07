using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using KZ.Entity.Models.Data.General;

namespace KZ.Entity.Models.Data
{
    public class Menu : BaseEntity
    {
        [Required, StringLength(100)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Image { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        [Required]
        public int MainMenuId { get; set; }

        public bool IsExternal { get; set; }

        public bool IsFooter { get; set; }

        public bool IsFooter2 { get; set; }

        public bool IsTarget { get; set; }

        public bool IsHome { get; set; }

        public bool IsHome2 { get; set; }

        public bool IsForm { get; set; }

        public bool IsDetailPage { get; set; }

        public bool IsProduct { get; set; }

        public bool IsOtherService { get; set; }

        public bool IsGrades { get; set; }

        public bool IsHomeDefaultSelected { get; set; }

        public bool IsMega { get; set; }

        public bool IsMegaSubView { get; set; }

        public bool IsHeaderAccordion { get; set; }

        public bool IsHeaderMainAccordion { get; set; }

        public bool IsSidebar { get; set; }

        public bool IsHeader { get; set; }

        public bool IsHeaderTop { get; set; }

        public bool IsSubMenuListView { get; set; }

        public bool IsLeftView { get; set; }

        public bool IsRightView { get; set; }

        public int MegaItemCount { get; set; }

        [StringLength(250)]
        public string Link { get; set; }

        public int SequenceNumber { get; set; }

        public int FooterSequenceNumber { get; set; }

        public int HomeSequenceNumber { get; set; }

        public int HomeSequenceNumber2 { get; set; }

        public int AccordionSequenceNumber { get; set; }

        public int SidebarSequenceNumber { get; set; }

        public int HeaderTopSequenceNumber { get; set; }

        public int HeaderLeftSequenceNumber { get; set; }

        public int HeaderRightSequenceNumber { get; set; }


        [Required]
        public byte TypeId { get; set; }


        [Required]
        public int LanguageId { get; set; }

        [StringLength(300)]
        public string SeoDescription { get; set; }

        public virtual List<Article> Articles { get; set; }

        public virtual Language Language { get; set; }
    }
}
