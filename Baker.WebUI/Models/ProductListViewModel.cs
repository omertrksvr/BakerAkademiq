using Baker.WebUI.Dtos.Category;
using Baker.WebUI.Dtos.Product;

namespace Baker.WebUI.Models
{
    public class ProductListViewModel
    {
        public List<ProductWithCategoryDto> Products { get; set; }
        public List<ResultCategoryDto> Categories { get; set; }
    }
}