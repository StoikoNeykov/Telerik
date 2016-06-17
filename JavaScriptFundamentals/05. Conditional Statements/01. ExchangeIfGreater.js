function solve(args) {
    var f = +args[0];
    var s = +args[1];
    if (s - f > 0) {
        console.log(f + ' ' + s);
    } else {
        console.log(s + ' ' + f);
    }
}