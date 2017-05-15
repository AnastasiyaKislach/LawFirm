
(function () {

    if (!window.lawfirm) {
        window.lawfirm = {};
    }
    window.lawfirm.pages.testimonials = new Testimonials();

    function Testimonials() {

        this.confirmation = function (selector) {
            var defaultSelectors = ['glyphicon-thumbs-up', 'glyphicon-thumbs-down'];
            var elem = $(selector);
            if (elem.hasClass(defaultSelectors[0])) {
                elem.removeClass(defaultSelectors[0]);
                elem.addClass(defaultSelectors[1]);
            } else {
                elem.removeClass(defaultSelectors[1]);
                elem.addClass(defaultSelectors[0]);
            }
        }


        this.removeTestimonial = function (selector) {
            lawfirm.formService.remove(selector);
        }

    }

})();
