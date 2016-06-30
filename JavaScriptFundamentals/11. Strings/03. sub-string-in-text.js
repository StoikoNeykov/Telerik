function solve(args) {
    var needed = args[0].toLowerCase(),
        text = args[1].toLowerCase();
    reg = new RegExp(needed, 'g');
    console.log(text.match(reg).length);
}