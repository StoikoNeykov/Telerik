function solve(args) {
    var s = args[0],
        c1 = args[1],
        c2 = args[2],
        c3 = args[3],
        result = 0,
        price;

    for (var i = 0; i * c1 <= s; i += 1) {
        for (var j = 0; j * c2 <= s; j += 1) {
            for (var k = 0; k * c3 <= s; k += 1) {
                price = i * c1 + j * c2 + k * c3;
                if (price <= s) {
                    result = Math.max(price, result);
                } else {
                    break;
                }
            }
        }
    }

    console.log(result);
}

test = [110, 13, 15, 17];
solve(test);