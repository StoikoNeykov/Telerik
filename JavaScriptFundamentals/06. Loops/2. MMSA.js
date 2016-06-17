function solve(args) {
    var min = +args[0];
    var max = +args[0];
    var sum = 0;
    var avg = 0;
    for (var i = 0; i < args.length; i++) {
        var num = +args[i];
        if (num < min) {
            min = num;
        }
        if (num > max) {
            max = num;
        }
        sum += num;
    }
    console.log('min=' + min.toFixed(2));
    console.log('max=' + max.toFixed(2));
    console.log('sum=' + sum.toFixed(2));
    console.log('avg=' + (sum / i).toFixed(2));
}