function solve(args) {
    var numbers = args[0].split('\n'),
        n = +numbers[0],
        i,
        currentCounter = 1,
        maxCounter = 0;
    for (i = 1; i < n - 1; i += 1) {
        while (+numbers[i] < +numbers[i + 1]) {
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