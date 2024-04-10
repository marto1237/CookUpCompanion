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
    const index = document.querySelectorAll('.ingredient-input').length + 1; // Get the current number of ingredients
    ingredientInput.classList.add('ingredient-input');
    ingredientInput.innerHTML = `<img class="ingredient-image" style="display: none;" />
                                     <input type="hidden" asp-for="Ingredients[i].IngredientId" class="ingredientID" />
                                    <input type="text" asp-for="Ingredients[i].IngredientName" class="form-control ingredient" placeholder="Add one or paste multiple items" onblur="loadIngredientDetails(this)" />
                                                        <select class="form-select possible-units" style="display: none;"></select>
                                                        <input type="number" asp-for="Ingredients[i].Quantity" class="form-control ingredient-quantity" min="0" max="1000" placeholder="Quantity" />
                                                        <span asp-validation-for="Ingredients[i].IngredientName" class="text-danger"></span>
                                                        <button class="btn btn-danger remove-ingredient">Remove</button>`;
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

// Function to gather ingredient data and submit it to the server
async function submitIngredientList() {
    const ingredientInputs = document.querySelectorAll('.ingredient-input');
    const ingredients = [];

    ingredientInputs.forEach(input => {
        const ingredientName = input.querySelector('.ingredient').value;
        const quantity = parseFloat(input.querySelector('.ingredient-quantity').value);
        const selectedUnit = input.querySelector('.possible-units').value;
        const ingredientId = parseInt(input.querySelector('.ingredientID').value);
        const ingredientPicture = input.querySelector('.ingredient-image').src;

        // Convert the ingredientPicture to a base64 string
        const base64Image = ingredientPicture.split(',')[1];

        const ingredient = {
            ingredientPicture: base64Image,
            ingredientId: ingredientId,
            ingredientName: ingredientName,
            measurementUnits: [], // Initialize an empty array for measurement units
            quantity: quantity
        };

        // Get all possible units for this ingredient
        const possibleUnits = input.querySelector('.possible-units').options;
        for (let i = 0; i < possibleUnits.length; i++) {
            ingredient.measurementUnits.push(possibleUnits[i].value);
        }

        ingredients.push(ingredient);
    });

    // Send ingredient data to the server using AJAX
    const response = await fetch('/CreateRecipe', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(ingredients)
    });

    if (response.ok) {
        // Handle successful response
    } else {
        // Handle error
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

/* Calendar */


// Write your JavaScript code.
