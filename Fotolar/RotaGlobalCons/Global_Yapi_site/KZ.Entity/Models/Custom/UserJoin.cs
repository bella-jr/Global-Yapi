using System;

namespace KZ.Entity.Models.Custom
{
    public class UserJoin
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Mail { get; set; }

        public bool IsStatus { get; set; }

        public int TypeId { get; set; }

        public string TypeName { get; set; }

        public DateTime CreationDate { get; set; }
    }
}
