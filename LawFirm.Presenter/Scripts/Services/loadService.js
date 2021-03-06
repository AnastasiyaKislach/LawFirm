﻿(function () {

    if (!window.lawfirm) {
        window.lawfirm = {};
    }
    window.lawfirm.loadService = new LoadService();

    function LoadService() {

        this.readURL = function (evt) {
            var files = evt.files; // FileList object
            var src = ['.resourse1', '.resourse2', '.resourse3'];
            var length = files.length;
            src.length = length;
            // Loop through the FileList and render image files as thumbnails.
            for (var i = 0, k = 0; i < length; i++) {
                var f = files[i];

                // Only process image files.
                if (!f.type.match('image.*')) {
                    continue;
                }

                var reader = new FileReader();

                // Closure to capture the file information.
                reader.onload = (
                    function (e) {
                        // Render thumbnail.

                        $(src[k]).attr('src', e.target.result);
                        k++;
                    });

                // Read in the image file as a data URL.
                reader.readAsDataURL(f);
            }
        }

    }

})();

