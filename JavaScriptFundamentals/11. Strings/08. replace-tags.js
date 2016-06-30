function solve(args) {
    var StartsWith = /^<a href="/,
        regexBegin = /<a href="/g,
        matchExtractLable = /(.*?)">(.*?)<\/a>(.*)/,
        result,
        splited,
        part = '';

    splited = args[0].split(regexBegin);

    if (!args[0].match(StartsWith)) {
        part += splited.shift();
    }

    result = splited.map(m => {
        var match = m.match(matchExtractLable);
        return '[' + match[2] + '](' + match[1] + ')' + match[3];
    });

    part += result.join('');

    console.log(part);
}

text = ['<p>Please visit <a href="http://academy.telerik.com">our site</a> to choose a training course. Also visit <a href="www.devbg.org">our forum</a> to discuss the courses.</p>'];

solve(text);