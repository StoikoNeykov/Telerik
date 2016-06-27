function solve(args) {
    args = args[0].split('\n');
    var num = +(args.shift());
    var needed = +(args.pop());
    args = args[0].split(' ');

    console.log(counter(args, needed))
    function counter(args, needed) {
        var len = args.length;
        var count = 0;
        for (var i = 0; i < len; i++) {
            if (args[i] == needed) {
                count += 1;
            }
        }
        return count;
    }
}
