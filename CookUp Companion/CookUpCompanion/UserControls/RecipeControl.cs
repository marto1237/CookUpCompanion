using CookUp_Companion_BusinessLogic.Manager;
using CookUpCompanion.Forms;
using InterfacesLL;
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
        private readonly IRecipeManager recipeManager;
        public RecipeControl(IRecipeManager recipeManager)
        {
            InitializeComponent();
            this.recipeManager = recipeManager;
        }

        #region Properties

        private byte[] _recipePicture;
        private string _recipeName;
        private string _recipeCreatorName;
        private int _prepTime;
        private int _cookTime;


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

            RecipeMoreInfo recipeMoreInfo = new RecipeMoreInfo(recipeManager, _recipeName, _recipeCreatorName);
            MoreOptionsMenuMenu.Visible = false;
            recipeMoreInfo.Show();
        }



        private void btnDeleteRecipe_Click(object sender, EventArgs e)
        {
            DeleteRecipe deleteRecipe= new DeleteRecipe(recipeManager, _recipeName, _recipeCreatorName);
            MoreOptionsMenuMenu.Visible = false;
            deleteRecipe.Show();
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
