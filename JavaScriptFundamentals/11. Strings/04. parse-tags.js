function solve(args) {
    var i, len,
        inUpper,
        inLower,
        inOrigin,
        result = '',
        command;
    for (i = 0, len = args[0].length; i < len; i += 1) {
        if (args[0][i] === '<') {
            command = '<';
            while (args[0][i] !== '>') {
                i += 1;
                command += args[0][i];
            }

            debugger;
            switch (true) {
                // Isn`t clear do we have to remove wrong close-type tags or have to print it ... 
                // also remove irrelevant tags
                case command === '</upcase>' && !inUpper:
                case command === '</lowcase>' && !inLower:
                case command === '</orgcase>' && !inOrigin:

                case command === '<lowcase>' && inUpper:
                case command === '<lowcase>' && inLower:
                case command === '<lowcase>' && inOrigin:

                case command === '<upcase>' && inLower:
                case command === '<upcase>' && inUpper:
                case command === '<upcase>' && inOrigin:

                case command === '<orgcase>' && inLower:
                case command === '<orgcase>' && inUpper:
                case command === '<orgcase>' && inOrigin:
                    break;


                case command === '</upcase>' && inUpper:
                    inUpper = false;
                    break;
                case command === '</lowcase>' && inLower:
                    inLower = false;
                    break;
                case command === '</orgcase>' && inOrigin:
                    inOrigin = false;
                    break;
                case command === '<lowcase>':
                    inLower = true;
                    break;
                case command === '<upcase>':
                    inUpper = true;
                    break;
                case command === '<orgcase>':
                    inOrigin = true;
                    break;

                // all other tags 
                default:
                    result += command;
                    break;
            }

            // Isn`t clear what happens with not closed tags 
        } else if (inUpper) {
            result += args[0][i].toUpperCase();
        } else if (inLower) {
            result += args[0][i].toLowerCase();
        } else {
            result += args[0][i];
        }
    }

    console.log(result);
}


// other try 
function solve(args) {
    var i, len,
        command = '',
        commands = [],
        scope = 0,
        scopes = [];
    commands.push('');
    scopes[0] = '';
    for (i = 0, len = args[0].length; i < len; i += 1) {
        if (args[0][i] === '<') {
            command = '<';
            while (args[0][i] !== '>') {
                i += 1;
                command += args[0][i];
            }

            //WARNING bad code incoming ! 
            switch (true) {
                case command === '<upcase>':
                    commands.push(command);
                    scope += 1;
                    scopes[scope] = '';
                    break;
                case command === '<lowcase>':
                    commands.push(command);
                    scope += 1;
                    scopes[scope] = '';
                    break;
                case command === '<orgcase>':
                    commands.push(command);
                    scope++;
                    scopes[scope] = '';
                    break;
                // code below works ONLY if tags are right OR/AND havent wrong open-type tags! 
                case command === '</upcase>':
                    if (commands[scope] === '<upcase>') {
                        scopes[scope - 1] += scopes[scope].toUpperCase();
                        scope -= 1;
                        scopes.length = scope + 1;
                        commands.length -= 1;
                    } else {
                        scopes[scope] += command;
                    }
                    break;
                case command === '</lowcase>':
                    if (commands[scope] === '<lowcase>') {
                        scopes[scope - 1] += scopes[scope].toLowerCase();
                        scope -= 1;
                        scopes.length = scope + 1;
                        commands.length -= 1;
                    } else {
                        scopes[scope] += command;
                    }
                    break;
                case command === '</orgcase>':
                    if (commands[scope] === '<orgcase>') {
                        scopes[scope - 1] += scopes[scope];
                        scope -= 1;
                        scopes.length = scope + 1;
                        commands.length -= 1;
                    } else {
                        scopes[scope] += command;
                    }
                    break;
                //default for all other tags
                default:
                    scopes[scope] += command;
                    break;
            }
        } else {
            scopes[scope] += args[0][i];
        }
    }

    // very unhappy case - need more close-type tags
    if (scope) {
        while (scope) {
            commands[scope] += scopes[scope];
            scopes[scope - 1] += commands[scope];
            scope -= 1;
            scopes.length -= 1;
            commands.length -= 1;
        }

        // expected scopes.length = 1; scopes[0] = result; commands.length = 1; commands[0] = ''; 
    }

    console.log(scopes[0]);
}