function solve(args) {
    var x = +args[0];
    var y = +args[1];
    var dis = Math.sqrt(x * x + y * y);
    if (dis > 2) {
        console.log('no ' + dis.toFixed(2));
    } else {
        console.log('yes ' + dis.toFixed(2));
    }
}