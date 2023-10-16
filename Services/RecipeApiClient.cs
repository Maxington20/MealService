using MealService.Models;
using Newtonsoft.Json;

namespace MealService.Services
{
    public class RecipeApiClient : IRecipeApiClient
    {
        private readonly HttpClient _httpClient;
        public RecipeApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<RecipeSummaryDTO> GetRecipeByIdAsync(int recipeId)
        {
            var response = await _httpClient.GetAsync($"api/recipes/{recipeId}");
            
            if (response.IsSuccessStatusCode)
            {
                var recipe = await response.Content.ReadAsStringAsync();
                var recipeDto = JsonConvert.DeserializeObject<RecipeSummaryDTO>(recipe);
                return recipeDto;
            }

            return null;
        }
    }
}
