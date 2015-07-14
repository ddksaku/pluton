(function (jQuery) {
    $.pluton = $.pluton || {};
    $.pluton.DateTime = function () {

        var options = {};

        this.init = function (opts) {
            $.extend(options, opts);
            initDatetime();
        };

        var initDatetime = function () {

            $('input[data-type = datetime]').each(function () {
                $(this).datepicker({
                    showOn: 'button',
                    buttonImage: options.calendarimg,
                    buttonImageOnly: true,
                    dateFormat: ' mm/dd/yy'

                });
            });

        };

    };

    $.extend($.pluton,
           {
               datetime: new $.pluton.DateTime()
           }
   );


})($);