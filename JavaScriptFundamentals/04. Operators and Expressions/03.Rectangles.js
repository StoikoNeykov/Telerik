function solve(args) {
    var w = +args[0];
    var h = +args[1];
    var p = (2*w)+(2*h);
    var a = (w*h);
    console.log(a.toFixed(2)+' '+ p.toFixed(2));
}