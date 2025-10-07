using System;
using KZ.Entity.Models.Data.General;

namespace KZ.Entity.Models.Data
{
    public class MostSearched : BaseEntity, IAuiditEntity
    {
        public string Title { get; set; }
        public string Link { get; set; }
        public bool IsView { get; set; }
        public int SequenceNumber { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
