function solve(args) {
    args = args[0].split('\n');
    var n = +(args.shift());
    var needed = +args.pop();
    if (needed < +args[0] || needed > +args[args.length - 1]) {
        return '-1';
    }
    var min = 0;
    var max = args.length - 1;
    var mid;
    while (true) {
        if (min === max && +args[min] !== needed) {
            return '-1';
        }
        mid = ((min + max) / 2) | 0;
        if (needed === +args[mid]) {
            return mid;
        } else if (needed < +args[mid]) {
            max = mid - 1;
        } else {
            min = mid + 1;
        }
    }
}