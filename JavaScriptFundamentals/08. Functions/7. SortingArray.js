function solve(args) {
    args = args[0].split('\n');
    var size = +(args.shift());
    if(size===0){
        return '';
    }
    args = args[0].split(' ');
    var i = 0;
    while (i < size) {
        if (isNaN(+args[i])) {
            args.splice(i, i + 1);
        } else {
            i++;
        }
    }
    args = sorter(size, args);
    console.log(args.join(' '));

    function sorter(size, args) {
        var begin = 0;
        var end = args.length - 1;

        for (var i = end; i >= 0; i -= 1) {
            var index = returnMaxIndex(args, 0, i);
            var temp = +args[i];
            args[i] = +args[index];
            args[index] = temp;
        }

        return args;
    }

    function returnMaxIndex(args, start, stop) {
        var max = +args[start];
        maxIndex = 0;
        for (var i = start + 1; i <= stop; i += 1) {
            if (+args[i] > max) {
                max = +args[i];
                maxIndex = i;
            }
        }
        return maxIndex;
    }
}
