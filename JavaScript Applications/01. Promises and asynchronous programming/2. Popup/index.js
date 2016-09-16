(function () {
    let div = document.getElementById('victim'),
        btn = document.getElementById('btn');

    function showDiv() {
        btn.style.display = 'none';
        div.style.display = 'block';
    }

    function redirecting() {
        window.location = 'https://telerikacademy.com/';
    }

    let promise = new Promise(function (resolve, reject) {
        setTimeout(function () {
            resolve();
        }, 2000);
    })

    // not sure is that even posible with simple Timeout
    function onError() {
        div.innerText = 'Totally unexpected error handled! Refresh page and try again please!';
    }

    function onClick() {
        showDiv();

        promise
            .then(redirecting)
            .catch(onError)
    }

    window.onload = btn.addEventListener('click', onClick, false);
} ())