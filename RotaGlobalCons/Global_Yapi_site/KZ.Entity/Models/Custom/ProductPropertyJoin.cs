namespace KZ.Entity.Models.Custom
{
    public class ProductPropertyJoin
    {
        public int Id { get; set; }

        public string Value { get; set; }

        public string Icon { get; set; }

        public int PropertyId { get; set; }

        public int ProductId { get; set; }

        public string PropertyName { get; set; }

        public int SequenceNumber { get; set; }

        public int GroupId { get; set; }
    }
}
