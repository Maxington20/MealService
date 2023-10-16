using MealService.Models;

namespace MealService.Services
{
    public interface IRecipeApiClient
    {
        Task<RecipeSummaryDTO> GetRecipeByIdAsync(int recipeId);
    }
}
