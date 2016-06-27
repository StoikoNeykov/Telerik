function solve(args) {
var result = args.filter(rem);
console.log(result.join('\n'));

    function rem(item, index, args) {
        return item !== args[0];
    }
}