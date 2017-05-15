(function () {

    if (!lawfirm) {
        window.lawfirm = {};
    }
    if (!lawfirm.pages) {
        window.lawfirm.pages = {};
    }

    lawfirm.pages.questions = new Questions();

    function Questions() {

        this.removeQuestionRow = function (selector) {
            lawfirm.formService.remove(selector);
        }
    }
})();