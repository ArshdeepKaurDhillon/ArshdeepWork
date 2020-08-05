$(function () {
    $(document).keyup(function (e) {
        var key = (e.keyCode ? e.keyCode : e.charCode);
        if (e.altKey) {
            switch (key) {
                case 112:   // F1
                    navigateUrl($("a[id$=btnAddItem]"));
                    break;
                case 113:   // F2
                    navigateUrl($("a[id$=btnReset]"));
                    break;
                case 114:   // F3
                    navigateUrl($("a[id$=btnEditItem]"));
                    break;
                case 116:   // F5
                    navigateUrl($("a[id$=btnContinueItem]"));
                    break;
                case 117:   // F6
                    navigateUrl($("a[id$=btnDiscontinueItem]"));
                    break;
                case 118:   // F7
                    //navigateUrl($("a[id$=btn]"));
                    break;
                case 119:   // F8
                    //navigateUrl($("a[id$=btn]"));
                    break;
                case 120:   // F9
                    //navigateUrl($("a[id$=btn]"));
                    break;
                case 121:   // F10
                    //navigateUrl($("a[id$=btn]"));
                    break;
                case 122:   // F11
                    //navigateUrl($("a[id$=btn]"));
                    break;
                case 123:   // F12
                    //navigateUrl($("a[id$=btn]"));
                    break;
            }
        }
    });
    function navigateUrl(jObj) {
        window.location.href = $(jObj).attr("href");
    }
});