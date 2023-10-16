namespace MealService.Models
{
    public class Meal
    {
        public Guid Id { get; set; }

        public string MealOfTheDay { get; set; }

        public DateTime SelectedDate { get; set; }

        public Guid RecipeId { get; set; }

        public Guid UserId { get; set; }
    }
}
