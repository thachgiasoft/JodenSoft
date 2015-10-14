// JScript 文件



jQuery.fn.selectAll = function () {
    return $(this).each(function () { this.checked = true; });
}

jQuery.fn.reverseAll = function () {
    return $(this).each(function () { this.checked = !this.checked; });
}
