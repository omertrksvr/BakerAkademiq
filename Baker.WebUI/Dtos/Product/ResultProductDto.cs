namespace Baker.WebUI.Dtos.Product
{
    public class ResultProductDto
    {
        public int productId { get; set; }
        public string? name { get; set; }
        public decimal price { get; set; }
        public string? description { get; set; }
        public string? imageUrl { get; set; }
        public int categoryId { get; set; }
    }
}