function solve(args) {
    args = args[0].split('\n');
    var n = +(args.shift());

    var length = args.length;

    for (var i = 0; i < length - 1; i++) {
        var min = i;
        for (var j = i + 1; j < length; j++) {
            if (+args[j] < +args[min]) {
                min = j;
            }
        }
        if (min != i) {
            var tmp = +args[i];
            args[i] = +args[min];
            args[min] = tmp;
        }
    }

    console.log(args.join('\n'));
}