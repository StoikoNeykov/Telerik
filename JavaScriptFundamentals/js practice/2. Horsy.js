function solve(args) {
    var moves = [[-2, 1], [-1, 2], [1, 2], [2, 1],
        [2, -1], [1, -2], [1, -2], [-2, -1]];

    var splited = args[0].split(' ').map(Number),
        rows = splited[0],
        cols = splited[1];

    var matrix = [];
    var isVisisted = makeMatrix();

    for (var i = 0; i < rows; i += 1) {
        matrix.push(args[i + 1]);
    }

    var curentRow = rows - 1,
        curentCol = cols - 1;

    var result = 0,
        jumps = 0;

    for (i = 0; ; i += 1) {
        if (0 <= curentRow && curentRow < rows && 0 <= curentCol && curentCol < cols) {
            if (isVisisted[curentRow][curentCol]) {
                result = 'Sadly the horse is doomed in ' + i + ' jumps';
                return result;
            } else {
                result += getValue();
                isVisisted[curentRow][curentCol] = true;
            }
        } else {
            result = 'Go go Horsy! Collected ' + result + ' weeds';
            return result;
        }

        var move = +matrix[curentRow][curentCol];
        curentRow += moves[move - 1][0];
        curentCol += moves[move - 1][1];
    }

    function getValue() {
        return Math.pow(2, curentRow) - curentCol;
    }

    function makeMatrix() {
        var isVisisted = new Array(rows);
        for (i = 0; i < rows; i += 1) {
            isVisisted[i] = new Array(cols);
        }

        return isVisisted;
    }
}

test = [
    '3 5',
    '54561',
    '43328',
    '52388',
];
console.log(solve(test));