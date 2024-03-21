namespace CookUp_Companion_web.Models
{
    public class Ingredient
    {

        public string IngredientName { get; private set; }
        public List<string> MeasurementUnits { get; private set; }
        public float Quantity { get; private set; }


        public Ingredient(string ingredientName, List<string> measurementUnits, float quantity)
        {
            IngredientName = ingredientName;
            MeasurementUnits = measurementUnits;
            Quantity = quantity;
        }

    }
}
