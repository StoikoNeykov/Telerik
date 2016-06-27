function solve(args) {
    var arr = args.splice(0,4);
    var len1 = calcLen(arr);
    arr = args.splice(0,4);
    var len2 = calcLen(arr);
    arr = args.splice(0,4);
    var len3 = calcLen(arr);

    console.log(len1.toFixed(2) + '\n' + len2.toFixed(2) + '\n' + len3.toFixed(2));

    if (isTrianglePosible(len1, len2, len3)) {
        return 'Triangle can be built';
    } else {
        return "Triangle can not be built";
    }

    function calcLen(arr) {
        var x1 = +arr[0],
            y1 = +arr[1],
            x2 = +arr[2],
            y2 = +arr[3];
        return Math.sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
    }

    function isTrianglePosible(len1, len2, len3) {
        return ((len1 + len2 > len3) && (len1 + len3 > len2) && (len2 + len3 > len1));
    }
}