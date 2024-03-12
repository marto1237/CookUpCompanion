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


//function to show the profile picture on log in
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
    ingredientInput.classList.add('ingredient-input');
    ingredientInput.innerHTML = `
        <input type="text" class="form-control ingredient" placeholder="Add one or paste multiple items">
        <button class="btn btn-danger remove-ingredient">Remove</button>
    `;
    container.appendChild(ingredientInput);
});

document.addEventListener('click', function (event) {
    if (event.target.classList.contains('remove-ingredient')) {
        event.target.parentElement.remove();
    }
});


//For Instruction to be added when creating recipe

document.querySelector('.add-instruction').addEventListener('click', function (event) {
    event.preventDefault(); // Prevent form submission
    const container = document.querySelector('.instructions-container');
    const instructionsInput = document.createElement('div');
    instructionsInput.classList.add('instruction-input');
    instructionsInput.innerHTML = `
        <textarea class="form-control instruction" placeholder="Paste one or multiple steps"></textarea>
        <button class="btn btn-danger remove-instruction">Remove</button>
    `;
    container.appendChild(instructionsInput);
});

document.addEventListener('click', function (event) {
    if (event.target.classList.contains('remove-instruction')) {
        event.target.parentElement.remove();
    }
});

// Write your JavaScript code.
