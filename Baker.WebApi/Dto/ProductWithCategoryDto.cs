namespace Baker.WebApi.Dto
{
    public class ProductWithCategoryDto
    {
        public int ProductId { get; set; }
        public string? Name { get; set; }

        public decimal Price { get; set; }

        public string? İmageUrl { get; set; }

        public string? CategoryName { get; set; }
    }
}