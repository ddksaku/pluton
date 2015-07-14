(function (jQuery) {
    $.pluton = $.pluton || {};
    $.pluton.Grid = function () {

        var updateGrid = function (link, context) {
            return $.get(link, function (data) {
                context.closest('.tableContainer').html(data);
                initAlphaFilter();
            }).fail(function () {
                //NOTE: Change it to appropriate error message when this mechanism will be implemented.
                alert('Error');
            });

        };

        var initAlphaFilter = function () {
            var currentLetter = $('.currentLetter').val();
            if (!currentLetter) {
                $('.filterButton[data-val="all"]').addClass('selectedFilterButton');
            } else {
                $('.filterButton[data-val="' + currentLetter + '"]').addClass('selectedFilterButton');
            }
        };

        $('.tableContainer').on('click', 'tr', function () {
            var $that = $(this);

            if ($that.data('index-url')) {
                document.location = $that.data('index-url');
            }

            return false;
        });


        $('.tableContainer').on('click', '.pager a', function () {
            var $that = $(this);

            if ($that.parent().hasClass('disabled')) {
                return false;
            }

            updateGrid($that.attr('href'), $that);
            return false;
        });

        $('.tableContainer').on('click', '.sort-anchor', function () {
            var $that = $(this);

            var link = $that.data('asc') === "True" ? $that.data('asc-link') : $that.data('desc-link');
            updateGrid(link, $that);
            return false;
        });

        $('.tableContainer').on('click', '.filterButton', function () {
            var $that = $(this);

            var link = $that.attr('href');
            updateGrid(link, $that);
            return false;
        });

        $('.tableContainer').on('change', '.propertySelector', function () {
            var $that = $(this);

            var link = $that.data('url').replace('_val_', $that.val());
            updateGrid(link, $that);
            return false;
        });

        $(document).ready(function () {
            initAlphaFilter();

            //            $('.filterButton')
        });
    };

    $.extend($.pluton,
           {
               grid: new $.pluton.Grid()
           }
   );


})($);