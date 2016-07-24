function solve(){
  return function (selector) {
  	if(typeof(selector) !== 'string' && !(selector instanceof HTMLElement)){
  		throw 'Neither a string nor an element';
  	}

  	if(document.getElementById(selector) === null){
  		throw 'selects nothing';
  	}

  	var buttons = document.getElementsByClassName('button'),
  		content = document.getElementsByClassName('content'),
  		i, len;

	for(i = 0, len = buttons.length; i < len; i+=1){
		buttons[i].innerHTML = 'hide';
		buttons[i].addEventListener('click', function(ev){
			var clickedButton = ev.target;
			var nextSibling = clickedButton.nextElementSibling;
			var firstContent,
				validFirstContent = false;

			while(nextSibling){
				if(nextSibling.className === 'content'){
					firstContent = nextSibling;
					nextSibling = nextSibling.nextSibling;
					while(nextSibling){
						if(nextSibling.className === 'button'){
							validFirstContent = true;
							break;
						}
						nextSibling = nextSibling.nextElementSibling;
					}
					break;
				} else {
					nextSibling = nextSibling.nextElementSibling;
				}
			}

			if (validFirstContent) {
				if (firstContent.style.display === 'none') {
					firstContent.style.display = '';
					clickedButton.innerHTML = 'hide';
				} else {
					firstContent.style.display = 'none';
					clickedButton.innerHTML = 'show';
				}
			}

		});
	}

  };
};