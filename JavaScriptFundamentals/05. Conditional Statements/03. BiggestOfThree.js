function solve(args) {
    var a = +args[0];
    var b = +args[1];
    if (a < b) {
        a = b;
    }
    b = +args[2];
    if (a < b) {
        a = b;
    }
    console.log(a);
}