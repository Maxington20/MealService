using MealService.Models;

namespace MealService.Services
{
    public interface IMealService
    {
        Task<IEnumerable<Meal>> GetMealsAsync(Guid userId, DateTime date);
        Task<Meal> GetMealByIdAsync(Guid id);
        Task<Meal> AddMealAsync(Meal meal);
        Task UpdateMealAsync(Meal meal);
        Task DeleteMealAsync(Guid id);
    }
}
