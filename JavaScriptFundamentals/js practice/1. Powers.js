function solve(args) {
    var nk = args[0].split(' ').map(Number),
        arr = args[1].split(' ').map(Number),
        result = [],
        i, j, k, len, sum;
    for (i = 0, k = nk[1]; i < k; i += 1) {
        for (j = 0, len = nk[0]; j < len; j += 1) {
            result.push(transform(arr[j], j, arr));
        }
        arr = result.slice();
        result = [];
    }
    sum = arr.reduce(function (sum, item) {
        return sum + item;
    }, 0);

    console.log(sum);

    function transform(item, index, arr) {
        var begin,
            after,
            len = arr.length,
            curent;
        begin = (typeof arr[index - 1] === 'undefined') ? arr[len - 1] : arr[index - 1];
        after = (typeof arr[index + 1] === 'undefined') ? arr[0] : arr[index + 1];

        if (item === 0) {
            curent = Math.abs(begin - after);
        } else if (item === 1) {
            curent = begin + after;
        } else if (item % 2) {
            curent = Math.min(begin, after);
        } else {
            curent = Math.max(begin, after);
        }

        return curent;
    }
}