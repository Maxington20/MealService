using MealService.Data;
using MealService.Models;
using Microsoft.EntityFrameworkCore;

namespace MealService.Repositories
{
    public class MealRepository : IMealRepository
    {
        private readonly ApplicationDbContext _context;

        public MealRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Meal>> GetMealsAsync(Guid userId, DateTime date)
        {
            return await _context.Meals.Where(meal => meal.UserId == userId && meal.SelectedDate.Date == date.Date).ToListAsync();
        }

        public async Task<Meal> GetMealByIdAsync(Guid id)
        {
            return await _context.Meals.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<Meal> AddMealAsync(Meal meal)
        {
            _context.Meals.Add(meal);
            await _context.SaveChangesAsync();
            return meal;
        }

        public async Task UpdateMealAsync(Meal meal)
        {
            _context.Entry(meal).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMealAsync(Guid id)
        {
            var meal = await _context.Meals.FindAsync(id);
            if (meal != null)
            {
                _context.Meals.Remove(meal);
                await _context.SaveChangesAsync();
            }
        }
    }
}
