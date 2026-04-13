(function($) {
  'use strict';
  if ($("#fileuploader").length) {
    $("#fileuploader").uploadFile({
      url: "../../../~/PurpleAdmin-Free-Admin-Template-1.0.0/assets/images/",
      fileName: "myfile"
    });
  }
})(jQuery);