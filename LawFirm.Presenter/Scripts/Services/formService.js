
(function () {

    if (!lawfirm) {
        window.lawfirm = {};
    }
    window.lawfirm.formService = new FormService();

    function FormService() {

        this.clear = function (options) {
            var defaultControlSelectors = 'input:text, textarea';
            var $form = $(options.selector);
            var $controls = $form.find(options.controlSelectors || defaultControlSelectors, options.controlSelectors);
            $controls.val("");
        }

        this.remove = function (selector) {
            var elem = $(selector);
            elem.remove();
        }

    }

})();
