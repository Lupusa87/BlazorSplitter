window.BsJsFunctions = {
    alertmsg: function (m) {
        alert(m);
        return true;
    },
    setPCapture: function (el, p) {

        if (document.getElementById(el) !== null) {
            document.getElementById(el).setPointerCapture(p);
            return true;
        }
        else {
            return false;
        }
    },
    releasePCapture: function (el, p) {

        if (document.getElementById(el) !== null) {
            document.getElementById(el).releasePointerCapture(p);
            return true;
        }
        else {
            return false;
        }
    },
};