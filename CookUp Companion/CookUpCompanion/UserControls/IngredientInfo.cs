using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CookUpCompanion.UserControls
{
    public partial class IngredientInfo : UserControl
    {
        public IngredientInfo()
        {
            InitializeComponent();

        }

        #region Properties

        private byte[] _ingredientPicture;
        private string _ingredientName;
        private int _ingredientUnitQuantity;
        private string _ingredientUnit;


        [Category("IngredientData")]
        public byte[] IngredientPicture
        {
            get { return _ingredientPicture; }
            set
            {
                _ingredientPicture = value;
                using (MemoryStream ms = new MemoryStream(value))
                {
                    pbIngredient.Image = Image.FromStream(ms);
                }
            }
        }

        [Category("IngredientData")]
        public string IngredienteName
        {
            get { return _ingredientName; }
            set { _ingredientName = value; lbIngredient.Text = value; }
        }
        [Category("IngredientData")]
        public int IngredientUnitQuantity
        {
            get { return _ingredientUnitQuantity; }
            set { _ingredientUnitQuantity = value; lbQuantitiy.Text = Convert.ToString(value); }
        }
        [Category("IngredientData")]

        public string Unit
        {
            get { return _ingredientUnit; }
            set { _ingredientUnit = value; lbUnit.Text = Convert.ToString(value); }
        }

        


        #endregion
    }
}
