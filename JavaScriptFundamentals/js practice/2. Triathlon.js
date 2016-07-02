function solve(args) {
    var text = args[0],
        shifter = +args[1],
        last = text[0],
        i, len,
        count = 1,
        result = '',
        code,
        eCode;

    //Compresion
    // last iteration will bewith undefined and just will append last letter(s)
    for (i = 1, len = text.length; i <= len; i += 1) {
        if (text[i] === last) {
            count += 1;
        } else if (count < 2) {
            result += last;
            last = text[i];
        } else if (count === 2) {
            result += last;
            result += last;
            last = text[i];
            count = 1;
        } else {
            result += count;
            result += last;
            last = text[i];
            count = 1;
        }
    }

    //Encryption
    //using text as free variable to keep curent result
    text = '';
    for (i = 0, len = result.length; i < len; i += 1) {
        code = result[i].charCodeAt(0);
        if (code < 97) {
            text += result[i];
        } else {
            eCode = (code + 26 - shifter);
            if (eCode > 122) {
                eCode -= 26;
            }
            text += (code ^ eCode);
        }
    }
    //Transformation
    //now result is free for use again 
    result = [];
    result[0] = 0;
    result[1] = 1;
    for (i = 0, len = text.length; i < len; i += 1) {
        if (+text[i] % 2) {
            result[1] *= +text[i];
        } else {
            result[0] += +text[i];
        }
    }

    console.log(result.join('\n'));
}