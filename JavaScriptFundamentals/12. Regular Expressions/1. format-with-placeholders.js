function solve(args) {
    var data = JSON.parse(args[0]),
        result;

    String.prototype.replacePlaceholders = function (data) {
        let result = this;
        for (const option in data) {
            if ({}.hasOwnProperty.call(data, option)) {
                let regex = new RegExp(`#{${option}}`, 'g');
                result = result.replace(regex, data[option]);
            }
        }

        return result;
    };

    result = args[1].replacePlaceholders(data);
    console.log(result);
}

text = [
'{ "name": "John", "age": 13 }',
"My name is #{name} and I am #{age}-years-old"
];

solve(text);