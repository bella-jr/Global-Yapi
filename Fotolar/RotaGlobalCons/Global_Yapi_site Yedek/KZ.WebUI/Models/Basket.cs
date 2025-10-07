namespace KZ.WebUI.Models
{
    public class Basket
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string MoneyType { get; set; }
        public string MoneySymbol { get; set; }
        public int MoneyTypeId { get; set; }
        public decimal HavalePrice { get; set; }
        public string Image { get; set; }
        public int Quantity { get; set; }
        public int StartQuantity { get; set; }
        public int UserId { get; set; }
        public decimal Total { get; set; }
        public decimal TotalHavale { get; set; }
        public string Size { get; set; }
        public string DeliveryTime { get; set; }
    }
}