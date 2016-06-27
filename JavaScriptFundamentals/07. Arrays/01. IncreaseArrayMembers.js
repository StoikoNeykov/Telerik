function solve(args) {
    var arr = [args | 0];
    for (var i = 0; i < args | 0; i += 1) {
        arr[i] = 5 * i;
        console.log(arr[i]);
    }
}