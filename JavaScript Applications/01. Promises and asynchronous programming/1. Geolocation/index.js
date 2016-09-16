(function () {
    let map = document.getElementById('map');

    let promise = new Promise(function (resolve, reject) {
        navigator.geolocation.getCurrentPosition(
            (pos) => { resolve(pos) },
            (error) => { reject(error) }
        );
    })

    function extractCoords(data) {
        return {
            lat: data.coords.latitude,
            long: data.coords.longitude
        }
    }

    function showMap(coords) {
        imgSrc = "http://maps.googleapis.com/maps/api/staticmap?center=" +
            coords.lat +
            "," +
            coords.long +
            "&zoom=13&size=500x500&sensor=false";

        map.setAttribute('src', imgSrc);
    }

    function notFound(error) {
        map.innerText = error.message;
    }

    promise
        .then(extractCoords)
        .then(showMap)
        .catch(notFound)

} ())