
(function () {

    if (!window.lawfirm) {
        window.lawfirm = {};
    }
    window.lawfirm.commentService = new CommentService();

    function CommentService() {

        this.commentCountInc = function (selector) {
            var elem = $(selector);
            var text = elem.text();
            var countInc = parseInt(text) + 1;

            elem.text(countInc);
        }
        
    }

})();
