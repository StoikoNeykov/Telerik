function onBtnClick(ev, args) {
    var thisWindow = window,
        browserName = thisWindow.navigator.appCodeName,
        isMozilla = browserName == "Mozilla";
    if (isMozilla) {
        alert("Yes");
    } else {
        alert("No");
    }
}