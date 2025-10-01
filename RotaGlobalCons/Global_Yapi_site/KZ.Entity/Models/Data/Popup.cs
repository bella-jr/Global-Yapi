using System;
using KZ.Entity.Models.Data.General;

namespace KZ.Entity.Models.Data
{
    public class Popup : BaseEntity
    {
        public string Image { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool IsStatus { get; set; }

        public bool IsDateLimited { get; set; }

        public int LanguageId { get; set; }
    }
}
