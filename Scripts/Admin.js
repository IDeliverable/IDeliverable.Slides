/*
** NOTE: This file is generated by Gulp and should not be edited directly!
** Any changes made directly to this file will be overwritten next time its asset group is processed by Gulp.
*/

(function ($)
{
    // Slides preview.
    var applyCssScale = function (element, scale, translate)
    {
        var browserPrefixes = ["", "-ms-", "-moz-", "-webkit-", "-o-"],
            offset = ((1 - scale) * 50) + "%",
            scaleString = (translate !== false ? "translate(-" + offset + ", -" + offset + ") " : "") + "scale(" + scale + "," + scale + ")";
        $(browserPrefixes).each(function ()
        {
            element
                .css(this + "transform", scaleString);
        });
        element
            .data({ scale: scale })
            .addClass("scaled");
    };

    var scaleSlides = function ()
    {
        $(".slides")
            .css("display", "block")
            .each(function ()
            {
                var slideshow = $(this),
                    slide = slideshow.find(".slide-preview"),
                    parent = slide.parent(),
                    width = 150,
                    height = 150,
                    boundingDimension = 150,
                    slideStyle = slide.attr("style");

                if ((slideStyle != null && slideStyle.indexOf("width:") == -1)) width = 1024;
                if ((slideStyle != null && slideStyle.indexOf("height:") == -1)) height = 768;

                slide.css({
                    width: width + "px",
                    height: height + "px",
                    position: "absolute"
                });
                var scaledForWidth = width > height,
                    largestDimension = (scaledForWidth ? width : height),
                    scale = boundingDimension / largestDimension;

                parent.css({
                    width: Math.floor(width * scale) + "px",
                    height: Math.floor(height * scale) + "px",
                    position: "relative",
                    overflow: "hidden"
                });

                applyCssScale(slide, scale);
                slideshow.parent(".slides-wrapper").css("overflow", "visible");
            });
    };

    $(window).load(function ()
    {
        scaleSlides();
    });

    // Sortable slides.
    $(function ()
    {
        $(".slides-wrapper.interactive").each(function ()
        {
            var wrapper = $(this);

            var showChangedMessage = function ()
            {
                wrapper.find(".dirty-message").show();
            };

            var onSlideIndexChanged = function (e, ui)
            {
                showChangedMessage();
            };

            var slidesList = wrapper.find("ul.slides");
            slidesList.sortable({
                placeholder: "sortable-placeholder",
                stop: onSlideIndexChanged
            });
            slidesList.disableSelection();
        });
    });
})(jQuery);
(function ($)
{
    $(function ()
    {
        $(".engine-picker").on("change", function (e)
        {
            var engine = $(this).val();

            $(".engine-settings-editor").hide();
            $("[data-engine='" + engine + "']").show();
        }).trigger("change");
    });
})(jQuery);
//# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbIkFkbWluLmpzIiwiYWRtaW4tc2xpZGVzLXBhcnQuanMiLCJhZG1pbi1zbGlkZXNob3ctcGFydC5qcyJdLCJuYW1lcyI6W10sIm1hcHBpbmdzIjoiQUFBQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0EsQUNMQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUN0RkE7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0EiLCJmaWxlIjoiQWRtaW4uanMiLCJzb3VyY2VzQ29udGVudCI6W251bGwsIihmdW5jdGlvbiAoJClcclxue1xyXG4gICAgLy8gU2xpZGVzIHByZXZpZXcuXHJcbiAgICB2YXIgYXBwbHlDc3NTY2FsZSA9IGZ1bmN0aW9uIChlbGVtZW50LCBzY2FsZSwgdHJhbnNsYXRlKVxyXG4gICAge1xyXG4gICAgICAgIHZhciBicm93c2VyUHJlZml4ZXMgPSBbXCJcIiwgXCItbXMtXCIsIFwiLW1vei1cIiwgXCItd2Via2l0LVwiLCBcIi1vLVwiXSxcclxuICAgICAgICAgICAgb2Zmc2V0ID0gKCgxIC0gc2NhbGUpICogNTApICsgXCIlXCIsXHJcbiAgICAgICAgICAgIHNjYWxlU3RyaW5nID0gKHRyYW5zbGF0ZSAhPT0gZmFsc2UgPyBcInRyYW5zbGF0ZSgtXCIgKyBvZmZzZXQgKyBcIiwgLVwiICsgb2Zmc2V0ICsgXCIpIFwiIDogXCJcIikgKyBcInNjYWxlKFwiICsgc2NhbGUgKyBcIixcIiArIHNjYWxlICsgXCIpXCI7XHJcbiAgICAgICAgJChicm93c2VyUHJlZml4ZXMpLmVhY2goZnVuY3Rpb24gKClcclxuICAgICAgICB7XHJcbiAgICAgICAgICAgIGVsZW1lbnRcclxuICAgICAgICAgICAgICAgIC5jc3ModGhpcyArIFwidHJhbnNmb3JtXCIsIHNjYWxlU3RyaW5nKTtcclxuICAgICAgICB9KTtcclxuICAgICAgICBlbGVtZW50XHJcbiAgICAgICAgICAgIC5kYXRhKHsgc2NhbGU6IHNjYWxlIH0pXHJcbiAgICAgICAgICAgIC5hZGRDbGFzcyhcInNjYWxlZFwiKTtcclxuICAgIH07XHJcblxyXG4gICAgdmFyIHNjYWxlU2xpZGVzID0gZnVuY3Rpb24gKClcclxuICAgIHtcclxuICAgICAgICAkKFwiLnNsaWRlc1wiKVxyXG4gICAgICAgICAgICAuY3NzKFwiZGlzcGxheVwiLCBcImJsb2NrXCIpXHJcbiAgICAgICAgICAgIC5lYWNoKGZ1bmN0aW9uICgpXHJcbiAgICAgICAgICAgIHtcclxuICAgICAgICAgICAgICAgIHZhciBzbGlkZXNob3cgPSAkKHRoaXMpLFxyXG4gICAgICAgICAgICAgICAgICAgIHNsaWRlID0gc2xpZGVzaG93LmZpbmQoXCIuc2xpZGUtcHJldmlld1wiKSxcclxuICAgICAgICAgICAgICAgICAgICBwYXJlbnQgPSBzbGlkZS5wYXJlbnQoKSxcclxuICAgICAgICAgICAgICAgICAgICB3aWR0aCA9IDE1MCxcclxuICAgICAgICAgICAgICAgICAgICBoZWlnaHQgPSAxNTAsXHJcbiAgICAgICAgICAgICAgICAgICAgYm91bmRpbmdEaW1lbnNpb24gPSAxNTAsXHJcbiAgICAgICAgICAgICAgICAgICAgc2xpZGVTdHlsZSA9IHNsaWRlLmF0dHIoXCJzdHlsZVwiKTtcclxuXHJcbiAgICAgICAgICAgICAgICBpZiAoKHNsaWRlU3R5bGUgIT0gbnVsbCAmJiBzbGlkZVN0eWxlLmluZGV4T2YoXCJ3aWR0aDpcIikgPT0gLTEpKSB3aWR0aCA9IDEwMjQ7XHJcbiAgICAgICAgICAgICAgICBpZiAoKHNsaWRlU3R5bGUgIT0gbnVsbCAmJiBzbGlkZVN0eWxlLmluZGV4T2YoXCJoZWlnaHQ6XCIpID09IC0xKSkgaGVpZ2h0ID0gNzY4O1xyXG5cclxuICAgICAgICAgICAgICAgIHNsaWRlLmNzcyh7XHJcbiAgICAgICAgICAgICAgICAgICAgd2lkdGg6IHdpZHRoICsgXCJweFwiLFxyXG4gICAgICAgICAgICAgICAgICAgIGhlaWdodDogaGVpZ2h0ICsgXCJweFwiLFxyXG4gICAgICAgICAgICAgICAgICAgIHBvc2l0aW9uOiBcImFic29sdXRlXCJcclxuICAgICAgICAgICAgICAgIH0pO1xyXG4gICAgICAgICAgICAgICAgdmFyIHNjYWxlZEZvcldpZHRoID0gd2lkdGggPiBoZWlnaHQsXHJcbiAgICAgICAgICAgICAgICAgICAgbGFyZ2VzdERpbWVuc2lvbiA9IChzY2FsZWRGb3JXaWR0aCA/IHdpZHRoIDogaGVpZ2h0KSxcclxuICAgICAgICAgICAgICAgICAgICBzY2FsZSA9IGJvdW5kaW5nRGltZW5zaW9uIC8gbGFyZ2VzdERpbWVuc2lvbjtcclxuXHJcbiAgICAgICAgICAgICAgICBwYXJlbnQuY3NzKHtcclxuICAgICAgICAgICAgICAgICAgICB3aWR0aDogTWF0aC5mbG9vcih3aWR0aCAqIHNjYWxlKSArIFwicHhcIixcclxuICAgICAgICAgICAgICAgICAgICBoZWlnaHQ6IE1hdGguZmxvb3IoaGVpZ2h0ICogc2NhbGUpICsgXCJweFwiLFxyXG4gICAgICAgICAgICAgICAgICAgIHBvc2l0aW9uOiBcInJlbGF0aXZlXCIsXHJcbiAgICAgICAgICAgICAgICAgICAgb3ZlcmZsb3c6IFwiaGlkZGVuXCJcclxuICAgICAgICAgICAgICAgIH0pO1xyXG5cclxuICAgICAgICAgICAgICAgIGFwcGx5Q3NzU2NhbGUoc2xpZGUsIHNjYWxlKTtcclxuICAgICAgICAgICAgICAgIHNsaWRlc2hvdy5wYXJlbnQoXCIuc2xpZGVzLXdyYXBwZXJcIikuY3NzKFwib3ZlcmZsb3dcIiwgXCJ2aXNpYmxlXCIpO1xyXG4gICAgICAgICAgICB9KTtcclxuICAgIH07XHJcblxyXG4gICAgJCh3aW5kb3cpLmxvYWQoZnVuY3Rpb24gKClcclxuICAgIHtcclxuICAgICAgICBzY2FsZVNsaWRlcygpO1xyXG4gICAgfSk7XHJcblxyXG4gICAgLy8gU29ydGFibGUgc2xpZGVzLlxyXG4gICAgJChmdW5jdGlvbiAoKVxyXG4gICAge1xyXG4gICAgICAgICQoXCIuc2xpZGVzLXdyYXBwZXIuaW50ZXJhY3RpdmVcIikuZWFjaChmdW5jdGlvbiAoKVxyXG4gICAgICAgIHtcclxuICAgICAgICAgICAgdmFyIHdyYXBwZXIgPSAkKHRoaXMpO1xyXG5cclxuICAgICAgICAgICAgdmFyIHNob3dDaGFuZ2VkTWVzc2FnZSA9IGZ1bmN0aW9uICgpXHJcbiAgICAgICAgICAgIHtcclxuICAgICAgICAgICAgICAgIHdyYXBwZXIuZmluZChcIi5kaXJ0eS1tZXNzYWdlXCIpLnNob3coKTtcclxuICAgICAgICAgICAgfTtcclxuXHJcbiAgICAgICAgICAgIHZhciBvblNsaWRlSW5kZXhDaGFuZ2VkID0gZnVuY3Rpb24gKGUsIHVpKVxyXG4gICAgICAgICAgICB7XHJcbiAgICAgICAgICAgICAgICBzaG93Q2hhbmdlZE1lc3NhZ2UoKTtcclxuICAgICAgICAgICAgfTtcclxuXHJcbiAgICAgICAgICAgIHZhciBzbGlkZXNMaXN0ID0gd3JhcHBlci5maW5kKFwidWwuc2xpZGVzXCIpO1xyXG4gICAgICAgICAgICBzbGlkZXNMaXN0LnNvcnRhYmxlKHtcclxuICAgICAgICAgICAgICAgIHBsYWNlaG9sZGVyOiBcInNvcnRhYmxlLXBsYWNlaG9sZGVyXCIsXHJcbiAgICAgICAgICAgICAgICBzdG9wOiBvblNsaWRlSW5kZXhDaGFuZ2VkXHJcbiAgICAgICAgICAgIH0pO1xyXG4gICAgICAgICAgICBzbGlkZXNMaXN0LmRpc2FibGVTZWxlY3Rpb24oKTtcclxuICAgICAgICB9KTtcclxuICAgIH0pO1xyXG59KShqUXVlcnkpOyIsIihmdW5jdGlvbiAoJClcclxue1xyXG4gICAgJChmdW5jdGlvbiAoKVxyXG4gICAge1xyXG4gICAgICAgICQoXCIuZW5naW5lLXBpY2tlclwiKS5vbihcImNoYW5nZVwiLCBmdW5jdGlvbiAoZSlcclxuICAgICAgICB7XHJcbiAgICAgICAgICAgIHZhciBlbmdpbmUgPSAkKHRoaXMpLnZhbCgpO1xyXG5cclxuICAgICAgICAgICAgJChcIi5lbmdpbmUtc2V0dGluZ3MtZWRpdG9yXCIpLmhpZGUoKTtcclxuICAgICAgICAgICAgJChcIltkYXRhLWVuZ2luZT0nXCIgKyBlbmdpbmUgKyBcIiddXCIpLnNob3coKTtcclxuICAgICAgICB9KS50cmlnZ2VyKFwiY2hhbmdlXCIpO1xyXG4gICAgfSk7XHJcbn0pKGpRdWVyeSk7Il0sInNvdXJjZVJvb3QiOiIvc291cmNlLyJ9
