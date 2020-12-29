var width = 100,
    perfData = window.performance.timing, // The PerformanceTiming interface represents timing-related performance information for the given page.
    EstimatedTime = -(perfData.loadEventEnd - perfData.navigationStart),
    time = parseInt((EstimatedTime/1000)%60)*100;
var PercentageID = $("#precent"),
        start = 0,
        end = 100,
        durataion = time;
        animateValue(PercentageID, start, end, durataion);
function animateValue(id, start, end, duration) {

    var range = end - start,
      current = start,
      increment = end > start? 1 : -1,
      stepTime = Math.abs(Math.floor(duration / range)),
      obj = $(id);
    
    var timer = setInterval(function() {
        current += increment;
        // $(obj).text(current + "%");
        $(".LoadingSvgCircle").find('path.mainline').attr("stroke-dasharray", current +" "+ parseInt((100 - current)));
        $(".LoadingSvgCircle").find(".ldBar-label").html(current);
      //obj.innerHTML = current;
        if (current == end) {
            clearInterval(timer);
            $(".LoadingSvgCircle").addClass("hide");
        }
    }, stepTime);
}