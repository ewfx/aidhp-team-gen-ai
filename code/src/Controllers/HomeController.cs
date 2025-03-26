using System.Diagnostics;
using Hyper_Personalization.Models;
using Hyper_Personalization.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Hyper_Personalization.Controllers
{
    public class HomeController : Controller
    {
        private readonly RecommendationService _recommendationService;

        public HomeController(RecommendationService recommendationService)
        {
            _recommendationService = recommendationService;
        }

        // Index page to show user data and recommendations
        public IActionResult Index()
        {
            return View();
        }

        // API endpoint to get recommendations based on the user profile
        [HttpPost]
        public async Task<IActionResult> GetRecommendations([FromBody] CustomerProfile userProfile)
        {
            if (userProfile == null)
            {
                return BadRequest("Invalid user profile data.");
            }

            var recommendation = await _recommendationService.GetPersonalizedRecommendationAsync(userProfile);
            return Ok(recommendation);
        }
    }
}
