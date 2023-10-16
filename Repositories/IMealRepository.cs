using MealService.Models;

namespace MealService.Repositories
{
    public interface IMealRepository
    {
        Task<IEnumerable<Meal>> GetMealsAsync(Guid userid, DateTime date);
        Task<Meal> GetMealByIdAsync(Guid id);
        Task<Meal> AddMealAsync(Meal meal);
        Task UpdateMealAsync(Meal meal);
        Task DeleteMealAsync(Guid id);
    }
}
