function solve(args) {
    var data = JSON.parse(args[0]),
        result;

    String.prototype.bind = function (data) {
        var texts = (this + '').split('><'),
            splited = texts[0].split(' '),
            i, len,
            prop, result = '',
            content, keyword,
            arr = [],
            regex = /data-bind-\w+=/;

        for (i = 0, len = splited.length; i < len; i += 1) {
            result += splited[i] + ' ';

            if (splited[i].match(regex)) {
                keyword = String(splited[i].match(regex))
                keyword = keyword.slice(10, keyword.length - 1);
                prop = splited[i].split('="');
                prop = prop[1].slice(0, prop[1].length - 1);

                if (keyword === 'content') {
                    content = data[prop];
                } else if (data[prop]) {
                    arr.push(keyword);
                    arr.push(data[prop]);
                }
            }
        }

        result = result.trim();

        while (arr.length) {
            result += ' ' + arr.shift();
            result += '="' + arr.shift() + '"';
        }

        result += '>';

        if (content) {
            result += content;
        }
        
        if (texts[1]) {
            result += '<' + texts[1];
        }

        return result;
    };

    result = args[1].bind(data);
    console.log(result);
}