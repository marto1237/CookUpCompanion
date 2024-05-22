namespace Logic
{
    public class Ingredient
    {
        public byte[] IngredientPicture { get; private set; }
        public int IngredientId { get; set; }
        public string IngredientName { get; set; }
        public List<string> MeasurementUnits { get; set; }
        public float Quantity { get; set; }
        public string SelectedUnit { get; set; }
        public bool IsSelected { get; set; }

        public Ingredient()
        {
        }

        public Ingredient(byte[] ingredientPicture, int ingredientId, string ingredientName, string measurementUnits, float quantity)
        {
            if (string.IsNullOrWhiteSpace(ingredientName))
                throw new ArgumentException("Ingredient name must not be empty.", nameof(ingredientName));

            if (quantity < 0)
                throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity must not be negative.");

            if (string.IsNullOrWhiteSpace(measurementUnits))
                throw new ArgumentException("Measurement unit must not be empty.", nameof(measurementUnits));
            IngredientPicture = ingredientPicture;
            IngredientId = ingredientId;
            IngredientName = ingredientName;
            MeasurementUnits = measurementUnits.Split(',').ToList();
            Quantity = quantity;
            SelectedUnit = null;
        }
        //This is for saving ingredient for the recipes
        public Ingredient(byte[] ingredientPicture, int ingredientId, string ingredientName, float quantity, string measurementUnit)
        {
            if (string.IsNullOrWhiteSpace(ingredientName))
                throw new ArgumentException("Ingredient name must not be empty.", nameof(ingredientName));

            if (quantity < 0)
                throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity must not be negative.");

            if (string.IsNullOrWhiteSpace(measurementUnit))
                throw new ArgumentException("Measurement unit must not be empty.", nameof(measurementUnit));
            IngredientPicture = ingredientPicture;
            IngredientId = ingredientId;
            IngredientName = ingredientName;
            Quantity = quantity;
            SelectedUnit = measurementUnit;
        }

        public string GetBase64Image()
        {
            if (IngredientPicture != null && IngredientPicture.Length > 0)
            {
                return $"data:image/jpeg;base64,{Convert.ToBase64String(IngredientPicture)}";
            }
            return string.Empty;
        }

        public void ChangeQuantity(float newquantity)
        {
            if (newquantity < 0)
                throw new ArgumentOutOfRangeException(nameof(newquantity), "New quantity must not be negative.");
            Quantity = newquantity;
        }
        public void ChangeSelectedUnit(string newSelectedUnit)
        {
            SelectedUnit = newSelectedUnit;
        }
    }
}
