namespace KZ.WebUI.Models
{
    public class SessionUser
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }

        public string Mail { get; set; }

        public byte TypeId { get; set; }

        public byte LoginTypeId { get; set; }
    }
}