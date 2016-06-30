function solve(args) {
    var regex = / /g;
    args[0] = args[0].replace(regex, '&nbsp;');
    console.log(args[0]);
}