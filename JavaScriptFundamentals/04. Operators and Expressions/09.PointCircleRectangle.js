function solve(args) {
    var x = +args[0];
    var y = +args[1];
    var dis = Math.sqrt((x-1)*(x-1) + (y-1)*(y-1));
    var inC =dis<=1.5 ? true:false;
    var inR = (-1<=y) && (y<=1) && (-1<=y) && (x<=5) ? true:false;
    inC = inC ? 'inside circle':'outside circle';
    inR = inR ? 'inside rectangle':'outside rectangle';
    console.log(inC + ' ' + inR);
}