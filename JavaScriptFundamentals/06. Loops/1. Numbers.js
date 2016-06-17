function solve(args) {
    var n = +args[0];
    var str = '';
    for (var i = 1; i <= n; i++) {
        str += i;
        if (i < n) {
            str += ' ';
        }
    }
    console.log(str);
}