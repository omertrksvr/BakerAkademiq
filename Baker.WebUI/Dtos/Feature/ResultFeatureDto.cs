namespace Baker.WebUI.Dtos.Feature
{
    public class ResultFeatureDto
    {
        public int FeatureId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        // Eksik olan alanları ekliyoruz:
        public string ImageUrl { get; set; }
        public string SubTitle { get; set; }
    }
}