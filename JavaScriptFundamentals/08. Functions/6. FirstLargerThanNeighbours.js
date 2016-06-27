function solve(args) {
    args = args[0].split('\n');
    var size = +(args.shift());
    args = args[0].split(' ');
    console.log(counter(size, args));

    function counter(size, args) {
        for (var i = 1; i < size - 1; i++) {
            if (+args[i] > +args[i - 1] && +args[i] > +args[i + 1]) {
                return i;
            }
        }
        return -1;
    }
}