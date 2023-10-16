using MealService.Models;
using MealService.Repositories;

namespace MealService.Services
{
    public class MealService : IMealService
    {
        private readonly IMealRepository _repository;

        public MealService(IMealRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Meal>> GetMealsAsync(Guid userId, DateTime date)
        {
            return await _repository.GetMealsAsync(userId, date);
        }

        public async Task<Meal> GetMealByIdAsync(Guid id)
        {
            return await _repository.GetMealByIdAsync(id);
        }

        public async Task<Meal> AddMealAsync(Meal meal)
        {
            return await _repository.AddMealAsync(meal);
        }

        public async Task UpdateMealAsync(Meal meal)
        {
            await _repository.UpdateMealAsync(meal);
        }

        public async Task DeleteMealAsync(Guid id)
        {
            await _repository.DeleteMealAsync(id);
        }
    }
}
