"use strict";
(function ($) {
    $.levshits = $.levshits || {};
    $.levshits.adb = $.levshits.adb || {};

    $.levshits.adb.Common = function () {

        var currentContext = $(document);

        function bindDatepickerControls() {
            console.log("hi");
            $(".js-datepicker", currentContext).datepicker();
        };

        this.init = function () {
            $(document).ready(function () {
                bindDatepickerControls();
            });
        };
    };
    $.extend($.levshits.adb, {
        common: new $.levshits.adb.Common()
    });
})(jQuery);