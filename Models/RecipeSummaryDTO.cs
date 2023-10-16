using System.Diagnostics.Contracts;

namespace MealService.Models
{
    public class RecipeSummaryDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string Ingredients { get; set; }

        public string Directions { get; set; }
    }
}
