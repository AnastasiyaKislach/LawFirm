(function () {

    if (!lawfirm) {
        window.lawfirm = {};
    }
    if (!lawfirm.pages) {
        window.lawfirm.pages = {};
    }

    lawfirm.pages.blog = new Blog();

    function Blog() {

        this.commentCreateHandler = function (response) {

            if (response.statusCode == 302) {
                lawfirm.httpService.redirect(response.redirectUrl);
                return;
            }

            lawfirm.commentService.commentCountInc('#commentsCount');

            lawfirm.formService.clear({
                selector: '#forma'
            });
        }

        this.replyCreateHandler = function (response) {

            if (response.statusCode == 302) {
                lawfirm.httpService.redirect(response.redirectUrl);
                return;
            }

            lawfirm.commentService.commentCountInc('#commentsCount');

            lawfirm.formService.remove('#replyForm');
        }
    }
})();