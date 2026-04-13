namespace Baker.WebUI.Dtos.Services
{
    public class UpdateServicesDto
    {
        public int ServiceId { get; set; }
        public string Description { get; set; }
        public string ServiceName { get; set; }
        public string ServiceIconUrl { get; set; }
    }
}