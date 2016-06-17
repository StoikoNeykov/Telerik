function solve(args) {
    var num = +args[0];
    if (num < 0) {
        num = -num;
    }
    var str = '';
    for (var i = 1; i <= num; i++) {
        str += i;
        if (i < num) {
            str += ' ';
        }
    }
    console.log(str);
    var sli = 2;
    for (i = 1; i < num; i++) {
        if (i === 10) {
            sli++;
        }
        if (i === 100) {
            sli++;
        }
        str = str.slice(sli) + ' ' + (num + i);
        console.log(str);
    }
}