namespace KZ.Entity.Models.Custom
{
    public class ProductImageJoin
    {
        public int Id { get; set; }

        public string Image { get; set; }

        public int ProductId { get; set; }

        public int SequenceNumber { get; set; }

        public string ProductImage { get; set; }
        public string ProductImage2 { get; set; }
    }
}
