// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function initClock() {
    function updateClock() {
        var d = new Date(),
            second = d.getSeconds().toString().length === 1 ? '0' + d.getSeconds() : d.getSeconds(),
            minutes = d.getMinutes().toString().length === 1 ? '0' + d.getMinutes() : d.getMinutes(),
            hours = d.getHours().toString().length === 1 ? '0' + d.getHours() : d.getHours(),
            //ampm = d.getHours() >= 12 ? 'pm' : 'am',
            months = ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'],
            days = ['Minggu', 'Senin', 'Selasa', 'Rabu', 'Kamis', 'Jumat', 'Sabtu'];
        document.getElementById("time").innerHTML = days[d.getDay()] + ', ' + d.getDate() + ' ' + months[d.getMonth()] + ' ' + d.getFullYear() + ' ' + hours + ':' + minutes + ':' + second;
    }

    updateClock();
    setInterval(updateClock, 1000);
}

initClock();