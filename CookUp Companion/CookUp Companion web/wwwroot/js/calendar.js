
const daysTag = document.querySelector(".days");
const currentWeek = document.querySelector(".current-week");
const nextIcon = document.querySelector("#next");
const prevIcon = document.querySelector("#prev");

let startDate = new Date();
let dayOfWeek = startDate.getDay(); // Get the day of the week (0 - 6)
let diff = startDate.getDate() - dayOfWeek + (dayOfWeek === 0 ? -6 : 1); // Adjust when day is Sunday
startDate = new Date(startDate.setDate(diff)); // Set the startDate to Monday
let endDate = new Date(startDate);
endDate.setDate(startDate.getDate() + 6); // End on Sunday

const months = [
    "January", "February", "March", "April", "May", "June",
    "July", "August", "September", "October", "November", "December"
];

const renderCalendar = () => {
    const startDay = startDate.getDate();
    const startMonth = startDate.getMonth();
    const startYear = startDate.getFullYear();

    currentWeek.innerText = `${startDay} ${months[startMonth]} - ${endDate.getDate()} ${months[endDate.getMonth()]}`;

    let liTag = "";
    let currentDate = new Date(startDate); // Create a new date object to manipulate without changing startDate

    for (let i = 0; i < 7; i++) {
        let isToday = currentDate.toDateString() === new Date().toDateString() ? "active" : "";

        // Format the ID with the full date
        let dateForId = `${currentDate.getFullYear()}-${String(currentDate.getMonth() + 1).padStart(2, '0')}-${String(currentDate.getDate()).padStart(2, '0')}`;
        let dayName = currentDate.toLocaleString('en-us', { weekday: 'long' }); // Get the day name in the same format as the class name

        // Find the day container by class name and set the id
        let dayContainer = document.querySelector(`.Day-${dayName}`);
        if (dayContainer) {
            dayContainer.id = `${dateForId}`;
        }

        liTag += `<li class="${isToday}">${currentDate.getDate()}</li>`;
        currentDate.setDate(currentDate.getDate() + 1);
    }

    daysTag.innerHTML = liTag;
};


renderCalendar();

nextIcon.addEventListener("click", () => {
    // Move the start date to the next week
    startDate.setDate(startDate.getDate() + 7);
    // Update the end date to be 6 days after the new start date
    endDate = new Date(startDate);
    endDate.setDate(startDate.getDate() + 6);
    renderCalendar();
});

prevIcon.addEventListener("click", () => {
    // Move the start date to the previous week
    startDate.setDate(startDate.getDate() - 7);
    // Update the end date to be 6 days after the new start date
    endDate = new Date(startDate);
    endDate.setDate(startDate.getDate() + 6);
    renderCalendar();
});