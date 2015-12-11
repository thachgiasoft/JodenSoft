// JScript 文件
/// <reference path="jquery-1.8.1.min.js" />
/// <reference path="jquery-ui-1.8.23.custom.min.js" />
/// <reference path="../Css/redmond/jquery-ui-1.8.23.custom.css" />


jQuery.fn.ShowDatePicker = function () {
    $(this).attr("readonly", true);
    $(this).datepicker({
        changeYear: true,
        changeMonth: true,
        gotoCurrent: true,
        showAnim: 'fadeIn',
        dateFormat: 'yy-mm-dd',
        dayNamesMin: ['日', '一', '二', '三', '四', '五', '六'],
        monthNames: ['一', '二', '三', '四', '五', '六', '七', '八', '九', '十', '十一', '十二'],
        monthNamesShort: ['一', '二', '三', '四', '五', '六', '七', '八', '九', '十', '十一', '十二']
    });
}

jQuery.fn.ShowConfirm = function (fnConfirm) {
    $(this).dialog({
        autoOpen: false,
        resizable: false,
        modal: true,
        buttons: {
            "确定": function () {
                //                if (fnConfirm!=null) fnConfirm;
                $(this).dialog("close");
            },
            "取消": function () {
                $(this).dialog("close");
            }
        }
    });

}

jQuery.fn.selectAll = function () {
    return $(this).each(function () { this.checked = true; });
}

jQuery.fn.reverseAll = function () {
    return $(this).each(function () { this.checked = !this.checked; });
}

jQuery.fn.AddTimeOption = function (selectedIndex) {
    $(this).html("");
    for (var i = 0; i < 24; i++) {
        var option = new Option(i, i);
        this[0].options.add(option, i);
    }

    this[0].selectedIndex = selectedIndex;
}


jQuery.fn.AddOption = function (text, value, index, selectedindex) {
    var option = new Option(text, value);
    this[0].options.add(option, index);
    this[0].selectedIndex = selectedIndex;
}

//自动换行
jQuery.fn.WordWrap = function () {
    if ($.browser.msie) {
        $(this).css('word-wrap', 'break-word');
        $(this).css('word-break', 'break-all');
    }
    else {
        $(this).each(function () {
            var text = $(this).text().split('').join(String.fromCharCode(8203));
            $(this).html($.trim(text));
        });
    }
}

//字符串格式化函数
String.prototype.format = function (args) {
    var result = this;
    if (arguments.length > 0) {
        if (arguments.length == 1 && typeof (args) == "object") {
            for (var key in args) {
                if (args[key] != undefined) {
                    var reg = new RegExp("({" + key + "})", "g");
                    result = result.replace(reg, args[key]);
                }
            }
        }
        else {
            for (var i = 0; i < arguments.length; i++) {
                if (arguments[i] != undefined) {
                    var reg = new RegExp("({[" + i + "]})", "g");
                    result = result.replace(reg, arguments[i]);
                }
            }
        }
    }
    return result;
}