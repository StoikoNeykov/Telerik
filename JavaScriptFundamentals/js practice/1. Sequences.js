function solve(args) {
    var num = +args[0];
    var arr = args.splice(1).map(Number);
    var last = arr[0];
    var count = 1;
    for (var i = 1, len = arr.length; i < len; i += 1) {
        if (arr[i] < last) {
            count += 1;
        }

        last = arr[i];
    }

    console.log(count);
}