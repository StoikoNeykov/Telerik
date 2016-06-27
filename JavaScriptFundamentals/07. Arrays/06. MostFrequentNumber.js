function solve(args) {
    args = args[0].split('\n');
    var n = +(args.shift());
    var arr = [];
    var max = 1;
    var value = +args[0];
    for (var i = 0; i < n; i++) {
        var curent = +args[i];
        if (typeof arr[curent] === 'undefined') {
            arr[curent] = 1;
        } else {
            arr[curent] += 1;
        }
        if (arr[curent] > max) {
            max = arr[curent];
            value = curent;
        }
    }

    console.log(value + ' (' + max + ' times)');
}