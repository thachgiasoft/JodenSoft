// JScript 文件
/// <reference path="jquery-1.8.1.min.js" />

//收缩
function headline() {
    //debugger;
    $(".h_line a").bind("click", function () {
        $(this).toggleClass("h_s"); //识别代码  
        var x = $(this).attr("id");
        $("#d" + x).toggle();
    });
}

//背景
function listhover() {

    $(".cus_t tbody tr").unbind("hover");
    $(".cus_t tbody tr").hover(function () {
        $(this).addClass("hover");
    },
          function () {
              $(this).removeClass("hover");
          });
}

//打开窗口链接（不指定大小）
function openWinLink(strUrl, strTitle) {
    var strRef = "toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=yes, copyhistory=no,borderSize=thin";

    window.open(strUrl, strTitle, strRef, false);
}

//打开窗口链接（指定大小,指定窗口名）
function openWinLinkExp(strUrl, strTitle, intWidth, intHeight) {
    var pWidth = intWidth;
    var pHeight = intHeight;
    var strRef = "";
    strRef = strRef + "width=" + pWidth + ",height=" + pHeight + ",";
    strRef = strRef + "left=" + (screen.availWidth / 2 - pWidth / 2) + "px,top=" + (screen.availHeight / 2 - pHeight / 2) + "px,";
    strRef = strRef + "toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=yes, copyhistory=no,borderSize=thin";

    window.open(strUrl, strTitle, strRef, false);
}

//限制文本长度
var textMaxLength = 100;
function CheckTextLength(textareaID, msgareaID, maxLength) {

    $('#' + msgareaID).html("<span style='color:darkblue;'>可输入 <em style='color:red;font-weight:bolder;'>" + maxLength + "</em> 个字</span>");

    $('textarea#' + textareaID).bind('keyup keydown', function () {
        var _val = $(this).val();
        var _cur = _val.length;

        if (_cur == 0) {
            $('#' + msgareaID).html("<span style='color:darkblue;'>可输入 <em style='color:blue;font-weight:bolder;'>" + maxLength + "</em> 个字</span>");
        }
        else if (_cur <= maxLength) {
            var len = maxLength - _cur;
            $('#' + msgareaID).html("<span style='color:darkblue;'>还可输入 <em style='color:blue;font-weight:bolder;'>" + len + "</em> 个字</span>");
        }
        else {
            var out = _cur - maxLength;
            $('#' + msgareaID).html("<span style='color:darkblue;'>已超出 <em style='color:#e56c0a;font-weight:bolder;'>" + out + "</em> 个字</span>");
        }
    });
}

function goto_url(url) {
    //  debugger;
    location.href = url;
    return false;
}

//JS键值对数组
//使用 例子
//var bb = new Dictionary();
function Dictionary() {
    this.Keys = new Array(); //键数组
    this.Values = new Array(); //值数组
    /*添加 key,value*/
    this.Add = function (key, value) {
        var keyCount = this.Keys.length;
        if (keyCount > 0) {
            var flag = true;
            for (var i = 0; i < keyCount; i++) {
                if (this.Keys[i] == key) {
                    flag = false;
                    break; //如果存在则不添加
                }
            }
            if (flag) {
                this.Keys.push(key)
                this.Values.push(value);
            }
        }
        else {
            this.Keys.push(key)
            this.Values.push(value);
        }
    };
    /*更改key,value*/
    this.Update = function (key, value) {
        var keyCount = this.Keys.length;
        if (keyCount > 0) {
            var flag = -1;
            for (var i = 0; i < keyCount; i++) {
                if (this.Keys[i] == key) {
                    flag = i;
                    break; //查找相应的index
                }
            }
            if (flag > -1) {
                this.Keys[flag] = key;
                this.Values[flag] = value;
            }
            else {
                this.Keys.push(key)
                this.Values.push(value);
            }
        }
        else {
            this.Keys.push(key)
            this.Values.push(value);
        }
    };
    /*移除key value*/
    this.Delete = function (key) {
        var keyCount = this.Keys.length;
        if (keyCount > 0) {
            var flag = -1;
            for (var i = 0; i < keyCount; i++) {
                if (this.Keys[i] == key) {
                    flag = i;
                    break; //查找相应的index
                }
            }
            if (flag > -1) {
                this.Keys.splice(flag, 1); //移除
                this.Values.splice(flag, 1); //移除
            }
        }
    };
    this.Get = function (key) {
        var keyCount = this.Keys.length;
        if (keyCount > 0) {
            var flag = -1;
            for (var i = 0; i < keyCount; i++) {
                if (this.Keys[i] == key) {
                    flag = i;
                    break; //查找相应的index
                }
            }
            if (flag > -1) {
                return this.Values[flag];
            }
            else {
                return null;
            }
        }
        else {
            return null;
        }
    };
}