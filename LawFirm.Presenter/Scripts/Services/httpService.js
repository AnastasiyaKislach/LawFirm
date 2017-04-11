(function () {

    if (!window.lawfirm) {
        window.lawfirm = {};
    }

    window.lawfirm.httpService = new HttpService();

    function HttpService() {
        this.redirect = function (url) {
            window.location = url;
        }
    }
})();