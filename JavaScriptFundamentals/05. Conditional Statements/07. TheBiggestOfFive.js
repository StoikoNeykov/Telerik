function solve(args) {
    var a = +args[0];
    for (var i = 1; i < args.length; i++) {
        var b = +args[i];
        if (a < b) {
            a = b;
        }
    }
    console.log(a);
}