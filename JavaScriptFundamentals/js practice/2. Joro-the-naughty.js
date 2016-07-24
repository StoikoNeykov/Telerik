function solve(args) {
    var splited = args.shift().split(' ').map(Number),
        rows = splited[0],
        cols = splited[1],
        listedJumps = splited[2],
        matrix = makeMatrix();

    splited = args.shift().split(' ').map(Number);
    var curentRow = splited[0],
        curentCol = splited[1],
        result = 0,
        jump = 0,
        index = 0,
        curent,
        jumps = [],
        i = 0;

    while (i !== listedJumps) {
        splited = args.shift().split(' ').map(Number);
        jumps.push(splited[0]);
        jumps.push(splited[1]);
        i += 1;
    }

    while (true) {
        curent = getValue();

        if (curent === 'escaped') {
            console.log('escaped ' + result);
            return;
        }

        if (matrix[curentRow][curentCol]) {
            console.log('caught ' + jump);
            return;
        }


        result += curent;
        matrix[curentRow][curentCol] = true;

        curentRow += jumps[index];
        curentCol += jumps[index + 1];
        index += 2;

        if (index === jumps.length) {
            index = 0;
        }
    }


    // params are visible coz getValue is inner
    function makeMatrix() {
        var matrix = new Array(rows);
        for (i = 0; i < rows; i += 1) {
            matrix[i] = new Array(cols);
            /* for (var j = 0; j < cols; j += 1) {
                 matrix[i][j] = false;
             }*/
        }

        return matrix;
    }

    function getValue() {
        if (curentRow < 0 || rows <= curentRow || curentCol < 0 || cols <= curentCol) {
            return 'escaped';
        } else {
            return (curentRow) * cols + curentCol + 1;
        }
    }
}

test = ['6 7 3', '0 0', '2 2', '-2 2', '3 -1'];

solve(test);
