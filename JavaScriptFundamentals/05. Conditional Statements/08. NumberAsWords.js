function solve(args) {
    var num = +args[0];
    var str = '';
    if (!num) {
        console.log("Zero");
        return;
    }
    if (num > 99) {
        var call = (num / 100) | 0;
        str += numberWord(call) + ' hundred';
        num %= 100;
        if (num !== 0) {
            str += ' and ';
        }
    }

    if (num > 19) {
        var dec = num / 10 | 0;
        str += otherWord(dec);
        num %= 10;
    } else if (num > 9) {
        str += tent(num);
        num = 0;
    }

    if (num !== 0) {
        str += numberWord(num);
    }

    console.log(capitalizeFirstLetter(str));

    function numberWord(call) {
        switch (call) {
            case 1:
                return 'one';
            case 2:
                return 'two';
            case 3:
                return 'three';
            case 4:
                return 'four';
            case 5:
                return 'five';
            case 6:
                return 'six';
            case 7:
                return 'seven';
            case 8:
                return 'eight';
            case 9:
                return 'nine';
        }
    }
    function otherWord(dec) {
        switch (dec) {
            case 2:
                return 'twenty ';
            case 3:
                return 'thirty ';
            case 4:
                return 'fourty ';
            case 5:
                return 'fifty ';
            case 6:
                return 'sixty ';
            case 7:
                return 'seventy ';
            case 8:
                return 'eighty ';
            case 9:
                return 'ninety ';
        }
    }

    function tent(ten) {
        switch (ten) {
            case 10:
                return 'ten';
            case 11:
                return 'eleven';
            case 12:
                return 'twelve';
            case 13:
                return 'thirteen';
            case 14:
                return 'fourteen';
            case 15:
                return 'fifteen';
            case 16:
                return 'sixteen';
            case 17:
                return 'seventeen';
            case 18:
                return 'eighteen';
            case 19:
                return 'nineteen';
        }
    }

    function capitalizeFirstLetter(str) {
        return str.charAt(0).toUpperCase() + str.slice(1);
    }
}