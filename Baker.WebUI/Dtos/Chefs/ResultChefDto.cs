using Newtonsoft.Json;

namespace Baker.WebUI.Dtos.Chefs
{
    public class ResultChefDto
    {

        [JsonProperty("chefId")]
        public int ChefId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("ImageUrll")]
        public string ImageUrl { get; set; }

    }
}