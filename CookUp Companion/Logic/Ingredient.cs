namespace Logic
{
    public class Ingredient
    {
        public byte[] IngredientPicture { get; private set; }
        public int IngredientId { get; private set; }
        public string IngredientName { get; private set; }
        public List<string> MeasurementUnits { get; private set; }
        public float Quantity { get; private set; }
        public string SelectedUnit { get; private set; }


        public Ingredient(byte[] ingredientPicture, int ingredientId,string ingredientName, string measurementUnits, float quantity)
        {
            IngredientPicture = ingredientPicture;
            IngredientId = ingredientId;
            IngredientName = ingredientName;
            MeasurementUnits = measurementUnits.Split(',').ToList();
            Quantity = quantity;
            SelectedUnit = null;
        }

        public string GetBase64Image()
        {
            if (IngredientPicture != null && IngredientPicture.Length > 0)
            {
                return $"data:image/jpeg;base64,{Convert.ToBase64String(IngredientPicture)}";
            }
            return string.Empty;
        }

    }
}
