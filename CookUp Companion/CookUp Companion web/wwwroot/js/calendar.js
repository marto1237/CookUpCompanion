    /*carousel */

    //var items = document.querySelectorAll('.carousel .carousel-item');
    //items.forEach((e) => {
    //    const slide = 5;
    //    let next = e.nextElementSibling;
    //    for (var i = 0; i < slide; i++) {
    //        if (!next) {
    //            next = items[0]
    //        }

    //        let clonechild = next.cloneNode(true)
    //        e.appendChild(clonechild.children[0])
    //        next = next.nextElementSibling
    //    }
    //})

    /* Calendar*/



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
        const startMonth = months[startDate.getMonth()];
        const endDay = endDate.getDate();
        const endMonth = months[endDate.getMonth()];

        currentWeek.innerText = `${startDay} ${startMonth} - ${endDay} ${endMonth}`;

        let liTag = "";

        for (let i = 0; i < 7; i++) {
            let isToday = startDate.toDateString() === new Date().toDateString() ? "active" : "";
        liTag += `<li class="${isToday}">${startDate.getDate()}</li>`;
                    startDate.setDate(startDate.getDate() + 1);
                }

                daysTag.innerHTML = liTag;
            };

        renderCalendar();

        nextIcon.addEventListener("click", () => {
            startDate.setDate(startDate.getDate() ); // Increment by 7 days for the next week
            endDate.setDate(endDate.getDate() + 7); // Adjust end date accordingly
            renderCalendar();
        });

        prevIcon.addEventListener("click", () => {
            startDate.setDate(startDate.getDate() - 14); // Decrement by 7 days for the previous week
            endDate.setDate(endDate.getDate() - 7); // Adjust end date accordingly
            renderCalendar();
        });



