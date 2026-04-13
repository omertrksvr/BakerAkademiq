using Baker.WebApi.Context;
using Baker.WebApi.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Baker.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly BakerContext _context;

        public CategoryController(BakerContext context)
        {
            _context = context;
        }

        // Kategori Listesini Getir (UI'daki CategoryList için)
        [HttpGet]
        public IActionResult CategoryList()
        {
            var values = _context.Categories.ToList();
            return Ok(values);
        }

        // Yeni Kategori Ekle (UI'daki CreateCategory için)
        [HttpPost]
        public IActionResult CreateCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return Ok("Kategori başarıyla eklendi");
        }

        // Güncelleme işlemi için tek bir kategori getir (UI'daki UpdateCategory Get metodu için)
        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            var value = _context.Categories.Find(id);
            if (value == null)
            {
                return NotFound("Kategori bulunamadı");
            }
            return Ok(value);
        }

        // Kategoriyi Güncelle (UI'daki UpdateCategory Post metodu için)
        [HttpPut]
        public IActionResult UpdateCategory(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
            return Ok("Kategori başarıyla güncellendi");
        }

        // Kategoriyi Sil (UI'daki DeleteCategory için)
        // Dikkat: UI'da '?id={id}' şeklinde query parametresi olarak gönderdiğin için
        // buradaki route'a "{id}" yazmamıza gerek yok, .NET bunu otomatik yakalar.
        [HttpDelete]
        public IActionResult DeleteCategory(int id)
        {
            var value = _context.Categories.Find(id);
            if (value == null)
            {
                return NotFound("Silinecek kategori bulunamadı");
            }

            _context.Categories.Remove(value);
            _context.SaveChanges();
            return Ok("Kategori başarıyla silindi");
        }
    }
}