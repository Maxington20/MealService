using MealService.Models;
using MealService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MealService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealsController : ControllerBase
    {
        private readonly IMealService _mealService;

        public MealsController(IMealService mealService)
        {
            _mealService = mealService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Meal>>> GetMeals(Guid userId, DateTime date)
        {
            return Ok(await _mealService.GetMealsAsync(userId, date));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Meal>> GetMeal(Guid id)
        {
            var meal = await _mealService.GetMealByIdAsync(id);

            if (meal == null)
            {
                return NotFound();
            }

            return Ok(meal);
        }

        [HttpPost]
        public async Task<ActionResult<Meal>> CreateMeal(Meal meal)
        {
            await _mealService.AddMealAsync(meal);
            return CreatedAtAction(nameof(GetMeal), new { id = meal.Id }, meal);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMeal(Guid id, Meal meal)
        {
            if (id != meal.Id)
            {
                return BadRequest();
            }

            await _mealService.UpdateMealAsync(meal);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMeal(Guid id)
        {
            await _mealService.DeleteMealAsync(id);
            return NoContent();
        }
    }
}
