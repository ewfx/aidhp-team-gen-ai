using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Hyper_Personalization.Models;

namespace Hyper_Personalization.Services
{
    public class RecommendationService
    {
        private readonly HttpClient _httpClient;
        private readonly string _openAiApiKey = "your-openai-api-key"; // Replace with your actual API key

        public RecommendationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetPersonalizedRecommendationAsync(CustomerProfile customerProfile)
        {
            var userProfile = $"Name: {customerProfile.Name}, Age: {customerProfile.Age}, " +
                              $"Gender: {customerProfile.Gender}, Interests: {string.Join(", ", customerProfile.Interests)}, " +
                              $"Purchase History: {customerProfile.PurchaseHistory}, Engagement Score: {customerProfile.EngagementScore}, " +
                              $"Sentiment Score: {customerProfile.SentimentScore}, Social Media Activity: {customerProfile.SocialMediaActivity}";

            var requestData = new
            {
                model = "gpt-3.5-turbo",
                prompt = $"Given the following user profile, suggest personalized product recommendations:\n{userProfile}",
                max_tokens = 100
            };

            var requestContent = new StringContent(
                JsonSerializer.Serialize(requestData),
                System.Text.Encoding.UTF8,
                "application/json"
            );

            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_openAiApiKey}");

            var response = await _httpClient.PostAsync("https://api.openai.com/v1/completions", requestContent);
            var responseData = await response.Content.ReadAsStringAsync();

            var jsonResponse = JsonSerializer.Deserialize<JsonElement>(responseData);
            return jsonResponse.GetProperty("choices")[0].GetProperty("text").GetString();
        }
    }
}
