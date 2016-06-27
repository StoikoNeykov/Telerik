function solve(args) {
    args = args[0].split('\n');
    var n = +args[0],
        i,
        maxCounter = 0;
    currentCounter = 1;

    for (i = 0; i < n - 1; i += 1) {
        while (+args[i] === +args[i + 1]) {
            currentCounter += 1;
            i += 1;
        }
        if (currentCounter > maxCounter) {
            maxCounter = currentCounter;
        }
        currentCounter = 1;
    }
    console.log(maxCounter);
}