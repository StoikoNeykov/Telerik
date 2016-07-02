function solve(args) {
    var n = +args[0],
        k = +args[1];
    arr = args[2].split(' ').map(Number);
    var i,
        result = [];
    for (i = 0; i < n - k + 1; i++) {
        result.push(calcMinMaxSum(arr.slice(i, i + k)));
    }
    console.log(result.join(','));

    function calcMinMaxSum(part) {
        var min = part[0],
            max = part[0],
            i, len;
        for (i = 1, len = part.length; i < len; i += 1) {
            min = Math.min(min, part[i]);
            max = Math.max(max, part[i]);
        }
        return min + max;
    }
}