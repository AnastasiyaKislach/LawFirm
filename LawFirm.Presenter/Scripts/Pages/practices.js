(function () {

    if (!lawfirm) {
        window.lawfirm = {};
    }
    if (!lawfirm.pages) {
        window.lawfirm.pages = {};
    }

    lawfirm.pages.practices = new Practices();

    function Practices() {

        this.removePracticeBlock = function (selector) {

            lawfirm.formService.remove(selector);
        }
    }
})();