function solve(args) {
    var data = JSON.parse(args[0]),
        result;

    String.prototype.replacePlaceholders = function (data) {
        var regex = /#\{(\w+)\}/g,
            result = this.replace(regex, function (match) {
                matchX = match.slice(2, match.length - 1);
                return data[matchX] || match;
            });

        return result;
    };

    result = args[1].replacePlaceholders(data);
    console.log(result);
}