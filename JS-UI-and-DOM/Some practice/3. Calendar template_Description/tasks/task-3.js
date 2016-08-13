function solve() {
    return function (selector) {
        var template = 
        '<div class="event-calendar">' +
            '<h2 class="header">Appointments for <span class="month">{{this.month}}</span> <span class="year">{{this.year}}</span></h2>' +
            '{{#each days}}' +
                '<div class="col-date">' +
                '<div class="date">{{this.day}}</div>' +
                '<div class="events">' +
                '{{#each events}}' +
                    '<div class="event {{this.importance}}" title="duration: {{this.duration}}" >' +
                    '<div class = "title">{{#if title}}{{this.title}}{{else}}Free slot{{/if}}</div>' +
                    '{{#if time}}<span class="time">at: {{this.time}}</span>{{/if}}'+
                    '</div>' +
                '{{/each}}' +
                '</div>' +
                '</div>'+
            '{{/each}}'+
        '</div>';

        document.getElementById(selector).innerHTML = template;
    };
}

module.exports = solve;

        // <div class="event-calendar">
        // <h2 class="header">Appointments for <span class="month">August</span> <span class="year">2015</span></h2>
        // <div class="col-date">
        //         <div class="date">4</div>
        //         <div class="events">
        //             <div class="event none">
        //                 <div class="title">Free slot</div>
        //             </div>
        //             <div class="event important" title="duration: 480">
        //                 <div class="title">Prepare for the Exam</div>
        //                 <span class="time">at: 12:30</span>
        //             </div>
        //             <div class="event none">
        //                 <div class="title">Free slot</div>
        //             </div>
        //         </div>
        // </div>
        // </div>