using System;

namespace KZ.Entity.Models.Custom
{
    public class BlogJoin
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Image { get; set; }

        public bool IsStatus { get; set; }

        public bool IsDetail { get; set; }

        public string Link { get; set; }

        public DateTime CreationDate { get; set; }

        public string TypeName { get; set; }
    }
}
