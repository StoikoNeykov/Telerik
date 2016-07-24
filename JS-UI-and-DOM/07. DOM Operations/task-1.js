function solve() {
    function task1(el, content) {

        if (typeof el === 'string') {
            el = document.getElementById(el);

            if (el === null) {
                throw new Error();
            }

        } else if (el instanceof HTMLElement) {
        } else {
            throw new Error();
        }

        if (!Array.isArray(content)) {
            throw new Error();
        }

        var outputContent = '';
        for (var i = 0; i < content.length; i += 1) {

            if (typeof content[i] !== 'string' && typeof content[i] !== 'number') {
                throw new Error();
            }

            outputContent += '<div>' + content[i] + '</div>';
        }
        el.innerHTML = outputContent;
    }

    return task1;
}