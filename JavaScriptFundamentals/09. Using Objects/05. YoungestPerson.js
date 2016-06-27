function solve(args) {
    var min = 5000, // lets say there is not extreme numbers 
        person,
        curentYongest;

    while (args.length > 0) {
        person = args.splice(0, 3);
        person = new Person(person[0], person[1], +person[2]);
        if (person.age < min) {
            min = person.age;
            curentYongest = new Person(person.firstName, person.lastName, person.age);
        }
    }

    console.log(curentYongest.firstName + ' ' + curentYongest.lastName);

    function Person(firstName, lastName, age) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
    }
}