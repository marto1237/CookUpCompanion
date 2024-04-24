// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

//Open modal with settings

$(document).ready(function () {
    $('#settings-link').click(function () {
        $('#settingsModal').modal('show');
    });

    //Open accound settings
    $('#AccountButton').click(function () {
        $('#settingsModal').modal('hide');
        $('#accountModal').modal('show');
    });
    //Open  profile settings
    $('#ProfileButton').click(function () {
        $('#settingsModal').modal('hide'); 
        $('#profileModal').modal('show');
    });
    //Open EditProfile
    $('#editProfileButton').click(function () {
        $('#profileModal').modal('show');
    });

    //Open preferances
    $('#PreferencesButton').click(function () {
        $('#settingsModal').modal('hide');
        $('#preferancesModal').modal('show');
    });

    //Open account email
    $('#editEmail').click(function () {
        $('#accountModal').modal('hide')
        $('#userConfirmModal').modal('show');
        $('#VerifyAccount').off('click').on('click', function () {
            $('#accountModal').modal('hide')
            $('#userConfirmModal').modal('hide')
            $('#changeEmailModal').modal('show');
        });
    });

    // Open account password
    $('#editPassword').click(function () {
        $('#accountModal').modal('hide')
        $('#userConfirmModal').modal('show');
        $('#VerifyAccount').off('click').on('click', function () {
            $('#accountModal').modal('hide')
            $('#userConfirmModal').modal('hide')
            $('#changePasswordModal').modal('show');
        });
    });

    // Open the serach bar with the dislike ingredients

    $('#DislikesButton').click(function () {
        $('#preferancesModal').modal('hide')
        $('#dislikesModal').modal('show');
    });
    
});
function goBackToSettingsModal() {
    $('#accountModal').modal('hide'); // Hide the account modal
    $('#settingsModal').modal('show'); // Show the settings modal
}



//To upderline the activity / created selected button in profile
function toggleButton(button) {
    // Remove 'selected' class from all buttons
    var buttons = document.querySelectorAll('.recipe-button');
    buttons.forEach(function (btn) {
        btn.classList.remove('selected');
    });

    // Add 'selected' class to the clicked button
    button.classList.add('selected');

    var createdContent = document.getElementById('createdContent');
    var activityContent = document.getElementById('activityContent');
    if (button.textContent.trim() === 'Created') {
        createdContent.style.display = 'block';
        activityContent.style.display = 'none'; 
    } else {
        activityContent.style.display = 'block';
        createdContent.style.display = 'none';
    }
}

var loadFile = function (event) {
    var image = document.getElementById("output");
    image.src = URL.createObjectURL(event.target.files[0]);
};



// Function to handle save button hover and click events
document.addEventListener('DOMContentLoaded', function () {
    var buttons = document.querySelectorAll('.bookmark-container button');
    buttons.forEach(function (button) {
        button.addEventListener('click', function () {
            button.classList.toggle('saved');
            var icon = button.querySelector('i');
            var saveTooltip = button.querySelector('.save-tooltip');
            if (button.classList.contains('saved')) {
                icon.classList.remove('fa-regular');
                icon.classList.add('fa-solid');
                icon.style.color = '#FFD43B';
                saveTooltip.textContent = 'Remove';
            } else {
                icon.classList.remove('fa-solid');
                icon.classList.add('fa-regular');
                icon.style.color = '#ffffff';
                saveTooltip.textContent = 'Save';
            }
        });
    });
});
//function to show the more option to the recipe 
document.addEventListener('DOMContentLoaded', function () {
    document.querySelectorAll('.card-recipe .more').forEach(button => {
        button.addEventListener('click', function (event) {
            event.preventDefault();  // Prevent navigating if it's in an anchor tag.
            event.stopPropagation(); // Stop the event from bubbling up to parent elements.

            const card = button.closest('.card-recipe'); // Find closest parent '.card-recipe'
           
            showOptionsMenu(id);
        });
    });
});
// function to show the Options menu
function showOptionsMenu(button) {
    var recipeId = button.getAttribute('data-recipe-id');

    // Store this ID in hidden inputs inside the modals
    document.querySelectorAll('input[name="CurrentRecipeId"]').forEach(input => {
        input.value = recipeId;
    });

    // Now show the modal
    $('#moreOptionsModal').modal('show');
}

//function to close more Option modal to show add to modal

function addToModal() {
    $('#moreOptionsModal').modal('hide'); // Hide the moreOption modal
    $('#AddToModal').modal('show'); // Show the settings modal
}
//function to show recipe ingredients modal in combo box
function recipeIngredientsModal() {
    $('#AddToModal').modal('hide'); // Hide the AddToModa modal
    $('#RecipeIngredientsModal').modal('show'); // Show the ingredients modal
}

//function to show the picture  of the recipe when creating new one
function displaySelectedImage(event, elementId) {
    const selectedImage = document.getElementById(elementId);
    const fileInput = event.target;

    if (fileInput.files && fileInput.files[0]) {
        const reader = new FileReader();

        reader.onload = function (e) {
            selectedImage.src = e.target.result;
        };

        reader.readAsDataURL(fileInput.files[0]);
    }
}
// For Ingredients to be added when creating recipe
document.querySelector('.add-ingredient').addEventListener('click', function (event) {
    event.preventDefault(); // Prevent form submission
    const container = document.querySelector('.ingredients-container');
    const ingredientInput = document.createElement('div');
    const index = document.querySelectorAll('.ingredient-input').length; // Get the current number of ingredients
    
    ingredientInput.classList.add('ingredient-input');
    ingredientInput.innerHTML = `<img class="ingredient-image" name="IngredientPicture[${index}]" style="display: none;" />
                                <input type="hidden" class="image-string"  name="IngredientPicture[${index}]" />
                                <input type="hidden" name="IngredientId[${index}]" class="ingredientID" />
                                <input type="text" name="IngredientName[${index}]" class="form-control ingredient" placeholder="Ingredient name" onblur="loadIngredientDetails(this)" />
                                <select name="SelectedIngredientMeasurmentUnits[${index}]" class="form-select possible-units" style="display: none;"></select>
                                <input type="number" name="IngredientQuanity[${index}]" class="form-control ingredient-quantity" min="0" max="1000"  placeholder="Quantity" />
                                <button class="btn btn-danger remove-ingredient" type="button">Remove</button>`;
                                    
    

    container.appendChild(ingredientInput);

});

// Function to load ingredient details when the input field changes
async function loadIngredientDetails(inputField) {
    let ingredientName = inputField.value.trim().toLowerCase(); // Convert to lowercase
    if (!ingredientName) return;

    // Fetch ingredient details asynchronously
    const response = await fetch(`/IngredientInfo?name=${ingredientName}`);
    if (response.ok) {
        const responseData = await response.text();
        // Get the HTML content of the response
        const parser = new DOMParser();
        const responseDoc = parser.parseFromString(responseData, 'text/html');
        // Get the div element
        var ingredientInfoDiv = responseDoc.getElementById('ingredient-info');

        // Parse the JSON string stored in the data-ingredient attribute
        var ingredientData = JSON.parse(ingredientInfoDiv.dataset.ingredient);
        console.log(ingredientData)
        if (ingredientData) {

            // Get the ingredient ID from the response
            const ingredientId = ingredientData.ingredientId;
            console.log(ingredientId)
            // Assign the retrieved ingredient ID to the ingredient entity
            const ingredientIdInput = inputField.parentElement.querySelector('.ingredientID');
            ingredientIdInput.value = ingredientId;
            // Update the ingredient image
            const imageElement = inputField.parentElement.querySelector('.ingredient-image');
            imageElement.src = 'data:image/jpeg;base64,' + ingredientData.ingredientPicture;
            imageElement.style.display = 'block';

            const imageString = inputField.parentElement.querySelector('.image-string');
            imageString.value = ingredientData.ingredientPicture;


            // Fill the combo box with units
            const unitsSelect = inputField.parentElement.querySelector('.possible-units');
            unitsSelect.innerHTML = ''; // Clear previous options
            ingredientData.measurementUnits.forEach(unit => {
                // Remove the square brackets and double quotes from the unit
                unit = unit.replace(/[\[\]"]/g, '');
                unitsSelect.innerHTML += `<option value="${unit}">${unit}</option>`;
            });
            unitsSelect.style.display = 'block';

        }
        else {
            const imageElement = inputField.parentElement.querySelector('.ingredient-image');
            imageElement.src = "https://cdn1.iconfinder.com/data/icons/ui-beast-9/32/ui-35-512.png";
            imageElement.style.display = 'block';
            
        }
    }
}


// Attach event listener to dynamically added input fields
document.addEventListener('focusout', function (event) {
    if (event.target.classList.contains('ingredient')) {
        loadIngredientDetails(event.target);
    }
});

document.addEventListener('click', function (event) {
    if (event.target.classList.contains('remove-ingredient')) {
        event.target.parentElement.remove();
    }
});


document.addEventListener('click', function (event) {
    if (event.target.classList.contains('remove-instruction')) {
        event.target.parentElement.remove();
    }
});

// Function to handle form submission
document.querySelector('form').addEventListener('submit', function (event) {
    // Check validity of dynamically added inputs
    const ingredientInputs = document.querySelectorAll('.ingredient');
    ingredientInputs.forEach(function (input) {
        if (!input.value.trim()) {
            input.nextElementSibling.textContent = 'Ingredient is required.';
        } else {
            input.nextElementSibling.textContent = ''; // Clear previous error message
        }
    });

    const instructionInputs = document.querySelectorAll('.instruction');
    instructionInputs.forEach(function (input) {
        if (!input.value.trim()) {
            input.nextElementSibling.textContent = 'Instruction is required.';
        } else {
            input.nextElementSibling.textContent = ''; // Clear previous error message
        }
    });

    // Prevent form submission if there are validation errors
    if (document.querySelectorAll('.text-danger').length > 0) {
        event.preventDefault();
    }
});
// Function to handle file input change event
document.getElementById('uploadRecipePicture').addEventListener('change', function (event) {
    var file = event.target.files[0];
    var reader = new FileReader();

    reader.onload = function () {
        var arrayBuffer = reader.result;
        var array = new Uint8Array(arrayBuffer);

        // Convert the byte array to a string and set it as the value of the hidden input field
        var imageData = Array.prototype.map.call(array, function (byte) {
            return String.fromCharCode(byte);
        }).join('');

        document.getElementById('imageData').value = imageData;
    };

    reader.readAsArrayBuffer(file);
});

function RateRecipe() {
    $('#rateRecipeModal').modal('show')
}
/* Calendar */

function toggleRate(choice) {
    if (choice === 'like') {
        document.getElementById('like_option').checked = true;
    } else if (choice === 'dislike') {
        document.getElementById('dislike_option').checked = true;
    }
}

/* To prevent open recipe and show the modal for remove recipe from saved */
function showRemoveModal(event) {
    event.preventDefault();
    event.stopPropagation();  // Prevent the click from affecting parent elements

    var recipeId = event.currentTarget.dataset.recipeId;
    document.getElementById('recipeIdToRemove').value = recipeId;
    $('#removeSavedRecipeModal').modal('show');
}

document.getElementById('filterRecipe').addEventListener('change', function () {
    this.form.submit();
});

function switchTab(button) {
    var tabName = button.getAttribute('data-tab');
    document.querySelectorAll('.recipe-button').forEach(btn => {
        btn.classList.remove('selected');
    });
    button.classList.add('selected');

    var activityHasRecipes = document.getElementById('activityContent').querySelectorAll('.card-recipe').length > 0;
    var createdHasRecipes = document.getElementById('createdContent').querySelectorAll('.card-recipe').length > 0;


    document.getElementById('activityContent').style.display = (tabName === 'activity' && activityHasRecipes) ? 'flex' :
        (tabName === 'activity' && !activityHasRecipes) ? 'block' : 'none';
    document.getElementById('createdContent').style.display = (tabName === 'created' && createdHasRecipes) ? 'flex' :
        (tabName === 'created' && !createdHasRecipes) ? 'block' : 'none';

    window.history.pushState({ tab: tabName }, '', `?tab=${tabName}`);
}
function displaySelectedImage(event, imgId) {
    var output = document.getElementById(imgId);
    output.src = URL.createObjectURL(event.target.files[0]);
    output.onload = function () {
        URL.revokeObjectURL(output.src)
    }
}
// Write your JavaScript code.
