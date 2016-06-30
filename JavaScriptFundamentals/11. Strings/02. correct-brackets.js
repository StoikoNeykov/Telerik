function solve(args) {
    var str = args[0] + '',
        i,
        len,
        count = 0;

    for (i = 0, len = str.length; i < len; i += 1) {
        if (str[i] === '(') {
            count++;
        } else if (str[i] === ')') {
            count--;
        }
    }

    console.log(count ? 'Incorrect' : 'Correct');
}