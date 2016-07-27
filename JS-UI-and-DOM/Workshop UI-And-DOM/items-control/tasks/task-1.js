/* globals module, document, HTMLElement, console */

function solve() {
    return function (selector, isCaseSensitive) {
        isCaseSensitive = !!isCaseSensitive;
        var element = selector;

        if (typeof element === "string") {
            element = document.querySelector(element);
        }
        if (!element || !(element instanceof HTMLElement)) {
            throw new Error("Invalid HTML element or selector");
        }

        element.className = 'items-control';

        // Adding

        var addDiv = document.createElement('div');
        addDiv.className = 'add-controls';

        var AddLabel = document.createElement('label');
        AddLabel.innerHTML = 'Enter text';

        var AddInput = document.createElement('input');
        AddInput.id = 'addInput';
        AddLabel.htmlFor = 'addInput';

        var addBtn = document.createElement('button');
        addBtn.className = 'button';
        addBtn.innerText = 'Add';
        addBtn.addEventListener('click', addButtonClicked, false);

        addDiv.appendChild(AddLabel);
        addDiv.appendChild(AddInput);
        addDiv.appendChild(addBtn);

        element.appendChild(addDiv);

        // Searching
        var searchDiv = document.createElement('div');
        searchDiv.className = 'search-controls';

        var searchLabel = document.createElement('label');
        searchLabel.innerHTML = 'Search:';

        var searchInput = document.createElement('input');
        searchInput.id = 'searchInput';

        searchLabel.htmlFor = 'searchInput';

        searchInput.addEventListener('keyup', someoneTypeInSearch, false);
        searchDiv.appendChild(searchLabel);
        searchDiv.appendChild(searchInput);

        element.appendChild(searchDiv);

        // Adding UL where have to add things
        // Removing added on that Ul

        var resultDiv = document.createElement('div');
        resultDiv.className = 'result-controls';

        var ul = document.createElement('ul');
        ul.setAttribute('id', 'list');
        ul.style.listStyleType = 'none';
        ul.addEventListener('click', removeBtnClicked, false);

        var li = document.createElement('li');
        li.className = 'list-item';

        var removeBtn = document.createElement('button');
        removeBtn.className = 'button';
        removeBtn.innerText = 'X';

        li.appendChild(removeBtn);

        resultDiv.appendChild(ul);
        element.appendChild(resultDiv);

        function addButtonClicked() {
            var text = AddInput.value;
            AddInput.value = '';
            ///  if (text) {
            var newLi = li.cloneNode(true);
            newLi.innerHTML += text;
            ul.appendChild(newLi);
            // }
        }

        function removeBtnClicked(ev) {
            var target = ev.target;
            var parent = target.parentNode;

            if (target.className === 'button') {
                parent.parentNode.removeChild(parent);
            }
        }

        function someoneTypeInSearch(ev) {
            var text = ev.target.value;
            var regex = new RegExp(text, 'g');

            for (var i = 0, len = ul.childNodes.length; i < len; i += 1) {
                var curent = ul.childNodes[i].innerText;
                if (!isCaseSensitive) {
                    text = text.toLowerCase();
                    curent = curent.toLowerCase();
                }
                if (curent.match(regex)) {
                    ul.childNodes[i].style.display = 'block';
                } else {
                    ul.childNodes[i].style.display = 'none';
                }
            }
        }
    };
}

module.exports = solve;