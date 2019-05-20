////////////////////////////////////////////////////////////////
//               Scripts by Mehdi Naseri                      //
////////////////////////////////////////////////////////////////

////////////////////////////////////////////////////////////////
/// <reference path="../jquery-1.10.2.min.js" />
////////////////////////////////////////////////////////////////



////////////////////////////////////////////////////////////////
//      (Script) Automatic Dropdown Menu                      //
//           باز شدن انوماتیک منوها                        //
////////////////////////////////////////////////////////////////
$(function () {
    $('ul.nav li.dropdown').hover(
        function () { $('.dropdown-menu',this).fadeIn();},
        function () { $('.dropdown-menu',this).fadeOut('fast');});
})

////////////////////////////////////////////////////////////////
//      (Script) Making picture larger and smaller            //
//      بزرگتر و کوچکتر کردن عکس با حرکت موس بر روی آن  //
////////////////////////////////////////////////////////////////
//this script make pictures size, 0.5 over time,2 percent in each step 
function image_mouseover_resize(object, PicWidth, PicHeight) {
    obj = object;
    PicResizedPercentage = 0;
    objWidth = PicWidth;
    objHeight = PicHeight;
    start_sizeplass = setInterval("add_sizeimage()", 12);
}
function add_sizeimage() {
    PicResizedPercentage += 2;
    obj.style["width"] = (((PicResizedPercentage / 100) * objWidth) + objWidth) + "px";
    obj.style["height"] = (((PicResizedPercentage / 100) * objHeight) + objHeight) + "px";
    if (PicResizedPercentage == 50) {
        PicResizedPercentage = 0;
        clearInterval(start_sizeplass);
    }
}

function image_mouseout_resize(object, PicWidth, PicHeight) {
    object.style["width"] = PicWidth + "px";
    object.style["height"] = PicHeight + "px";
    clearInterval(start_sizeplass);
}

////////////////////////////////////////////////////////////////
//                (Script) Strip Image                        //
////////////////////////////////////////////////////////////////
function imageStripsMaker(c) {
    function startStyle(url, width, height, time, delay, left, k) {
        return 'background: url(' + url + ') no-repeat; display: block; margin: 0px; padding: 0px; width:' + width + 'px; height:' + height + 'px; background-position: ' + ((left) ? '-' : '') + width + 'px ' + (-k * height) + 'px; -webkit-transition: background-position ' + time + 's ease ' + delay + 's; -moz-transition: background-position ' + time + 's ease ' + delay + 's; -ms-transition: background-position ' + time + 's ease ' + delay + 's; -o-transition: background-position ' + time + 's ease ' + delay + 's; transition: background-position ' + time + 's ease ' + delay + 's';
    }
    function setNodeStyle(n, data, height, i, left) {
        var dir;
        switch (left) {
            case "random":
                dir = (Math.floor((Math.random() * 100) + 1) >= 50);
                break;
            case "mixed":
                dir = (i % 2 == 0);
                break;
            case "right":
                dir = false;
                break;
            case "left":
            default:
                dir = true;
                break;
        }
        n.setAttribute("style", startStyle(data.img.url, data.img.width, height, data.time, data.delay * i, dir, i));
    }
    var ht = parseInt(c.img.height / c.strips),
    i,
    nds = [],
    left = c.direction || "left";
    for (i = 0; i < c.strips; i++) {
        nds.push(document.createElement("span"));
        setNodeStyle(nds[i], c, ht, i, left);
        c.addIn.appendChild(nds[i]);
    }
    window.setTimeout(function () {
        for (i = 0; i < c.strips; i++) {
            nds[i].style.backgroundPosition = '0px ' + (-i * ht) + 'px';
        }
    }, 20);
}


////////////////////////////////////////////////////////////////
//                (Script) Paging Next Previous Buttons       //
////////////////////////////////////////////////////////////////
$(function () {
    $("#btnNext").click(function () {
        $.ajax({
            url: 'Weblog/Paged',
            data: { currentPageIndex: document.getElementById('currentPageIndex').value },
            success: function (response) {
                $("PagedContent").html(response);
            }
        });
    });
    $("#btnPrevious").click(function () {
        $.ajax({
            url: 'Weblog/Paged',
            data: { currentPageIndex: document.getElementById('currentPageIndex').value },
            success: function (response) {
                $("PagedContent").html(response);
            }
        });
    });
});




////////////////////////////////////////////////////////////////
//                (Script)  Autocomplete                      //
////////////////////////////////////////////////////////////////

$(function () {

    var createAutocomplete = function () {
        var $input = $(this);
        var option = { source: $input.attr("data-Meh-autocomplete") };
        $input.autocomplete(option);
    };
    $("input[data-Meh-autocomplete]").each(createAutocomplete);
});
