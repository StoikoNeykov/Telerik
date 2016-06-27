function solve(args) {
    args = args[0].split('\n');
    var size = +(args.shift());
    args = args[0].split(' ');
    console.log(counter(size, args));

    function counter(size, args) {
        var count = 0;
        for (var i = 1; i < size - 1; i++) {
            if (+args[i] > +args[i - 1] && +args[i] > +args[i + 1]) {
                count += 1;
            }
        }
        return count;
    }
}