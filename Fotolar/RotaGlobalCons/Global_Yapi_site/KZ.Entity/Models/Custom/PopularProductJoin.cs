namespace KZ.Entity.Models.Custom
{
    public class PopularProductJoin
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public string Title { get; set; }

        public string Image { get; set; }

        public decimal Price { get; set; }

        public decimal Old_Price { get; set; }

        public bool IsNew { get; set; }

        public bool IsDiscount { get; set; }

        public bool IsStock { get; set; }

        public bool IsSoon { get; set; }

        public string Discount { get; set; }

        public string SeoKeywords { get; set; }
    }
}
