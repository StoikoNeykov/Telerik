function solve(args) {
    var num = args[0];
    if (num < 700) {
        console.log('false 0');
    } else if ((num / 100 | 0) % 10 == 7) {
        console.log('true');
    } else {
        console.log('false ' + (num / 100 | 0) % 10);
    }
}