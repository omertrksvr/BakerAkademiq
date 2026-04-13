namespace Baker.WebUI.Dtos.Testimonial
{
    public class UpdateTestimonialDto
    {
        public int TestimonialId { get; set; }
        public string Name { get; set; }
        public string JobName { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}