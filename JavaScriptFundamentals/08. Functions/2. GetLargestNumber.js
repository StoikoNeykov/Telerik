function solve(args) {
    args = args[0].split(' ');
    var one = +args[0];
    var two = +args[1];
    var three = +args[2];
    one = GetMax(one, two);
    one = GetMax(one, three);
    console.log(one);

    function GetMax(one, two) {
        return one > two ? one : two;
    }
}