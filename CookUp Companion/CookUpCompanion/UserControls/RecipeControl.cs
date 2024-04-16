using CookUp_Companion_BusinessLogic.Manager;
using CookUpCompanion.Forms;
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
    public partial class RecipeControl : UserControl
    {
        public RecipeControl()
        {
            InitializeComponent();
        }

        #region Properties

        private byte[] _recipePicture;
        private string _recipeName;
        private string _recipeCreatorName;
        private int _prepTime;
        private int _cookTime;

        private void btnMoreInfo_Click(object sender, EventArgs e)
        {
            RecipeControl recipeControl = new RecipeControl();
            MoreOptionsMenuMenu.Visible = false;
            //userMoreInfo.Show();
        }



        private void MoreOptions_Click(object sender, EventArgs e)
        {
            if (MoreOptionsMenuMenu.Visible == true)
            {
                MoreOptionsMenuMenu.Visible = false;
            }
            else
            {
                MoreOptionsMenuMenu.Visible = true;
            }
        }

        private void btnMoreInfo_Click_1(object sender, EventArgs e)
        {

        }

        private void btnEditRecipe_Click(object sender, EventArgs e)
        {

        }

        private void btnDeleteRecipe_Click(object sender, EventArgs e)
        {

        }

        [Category("RecipeData")]
        public byte[] RecipePicture
        {
            get { return _recipePicture; }
            set
            {
                _recipePicture = value;
                using (MemoryStream ms = new MemoryStream(value))
                {
                    pbRecipePicture.Image = Image.FromStream(ms);
                }
            }
        }

        [Category("RecipeData")]
        public string RecipeName
        {
            get { return _recipeName; }
            set { _recipeName = value; lbRecipeName.Text = value; }
        }
        [Category("RecipeData")]
        public string Creator
        {
            get { return _recipeCreatorName; }
            set { _recipeCreatorName = value; lbRecipeCreator.Text = value; }
        }
        [Category("RecipeData")]

        public int PrepTime
        {
            get { return _prepTime; }
            set { _prepTime = value; lbPrepTime.Text = Convert.ToString(value); }
        }

        [Category("RecipeData")]
        public int CookTime
        {
            get { return _cookTime; }
            set { _cookTime = value; lbCookTime.Text = Convert.ToString(value); }
        }


        #endregion
    }
}
