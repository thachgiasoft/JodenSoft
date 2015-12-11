/// <reference path="jquery.cookie.js" />

var tab;
var MaxPages = 8;
function Tabs(h, p) {
    this.hEle = h;
    this.pEle = p;
    this.tabPages = new Array();
    this.tabTemplate = '<li class="tabh"><em class="tabh_l"></em><span>&nbsp;&nbsp;#{label}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><em class="tabh_r"></em></li>';
    this.selected = function (id) { };
    this.currentId = 0;
    this.count = 0;
}

Tabs.prototype.AddTab = function (t, h, i) {
    var x = $(this.tabTemplate.replace(/#\{href\}/g, h).replace(/#\{label\}/g, t))
    x.attr("id", "tabh-" + i);
    x.bind("click", { id: i }, function (event) {
        var t = $("#tabh-" + event.data.id);
        if (!t.html()) return;
        var c = $("#tabh-" + tab.currentId);
        c.removeClass("tabh_s");
        t.addClass("tabh_s");
        $("#tabp-" + tab.currentId).removeClass("tabp_s");
        $("#tabp-" + event.data.id).addClass("tabp_s");
        $("#tabc").remove();

        if (tab.count > 1 && (event.data.id != "" || event.data.id > 0)) {
            $("#tabh-" + event.data.id).append(
	            '<a id="tabc" class="tabc" href="javascript://" onclick="Remove(' + "'" + event.data.id + "'" + ')">&nbsp;&nbsp;</a>');
        }
        tab.currentId = event.data.id;
    });
    this.hEle.append(x);
    this.pEle.append('<div id="tabp-' + i + '" class="tabp"><iframe name="tabw-' + i + '" id="tabw-' + i + '" src="' + h + '" frameborder="0" width="100%" height="100%" /></div>')
    tab.count++;
};
Tabs.prototype.RemoveTab = function (id) {
    var lastTabId = '';
    $("li.tabh").each(function () {
        var myid = this.id;
        if (myid == "tabh-" + id) {
            var doc = document.getElementById("tabw-" + id);
            doc.src = "";
            var wp = doc.parentNode;
            wp.removeChild(doc);

            var p = document.getElementById("tabp-" + id);
            pp = p.parentNode;
            pp.removeChild(p);
            var h = document.getElementById("tabh-" + id);
            hp = h.parentNode;
            hp.removeChild(h);
            tab.count--;
        }
        else {
            lastTabId = myid;
        }
    });

    if (lastTabId != '')
        $("#" + lastTabId).click();
}
Tabs.prototype.SelectTab = function (idx) {
    $("#tabh-" + idx).click();
}
Tabs.prototype.SetTab = function (t, src, idx) {
    $("#tabw-" + idx).attr("src", src);
    $("#tabh-" + idx + " span").html("&nbsp;&nbsp;" + t + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;");
    $("#tabh-" + idx).click();
}

function Remove(id) {
    if (tab) {
        tab.RemoveTab(id);
    }
}

function CloseTab() {
    Remove(tab.currentId);
}

function changeFrame(t, openMode, id, src) {
    var language = $.cookie("SERVICE_Language");

    if (openMode == 0) {
        var count = 0;
        $("li.tabh").each(function () {
            var myid = this.id;
            if (myid == "tabh-0") {
                count++;
            }
        });
        if (count <= 0) {
            tab.AddTab(t, src, 0);
        }
        tab.SetTab(t, src, 0);
    }
    else if (openMode == 1) {
        if (tab) {
            if (tab.count > MaxPages) {
                if (language == 0) {
                    alert("您打开了太多的页面，请关闭一些后重试!");
                }
                else {
                    alert("You open too many pages, please close some and try again!");
                }
                return;
            }

            var count = 0;
            $("li.tabh").each(function () {
                var myid = this.id;
                if (myid == "tabh-" + id) {
                    count++;
                }
            });
            if (count <= 0) {
                tab.AddTab(t, src, id);
            }
            tab.SelectTab(id);
        }
    }
    else {
        if (tab) {
            if (tab.count > MaxPages) {
                if (language == 0) {
                    alert("您打开了太多的页面，请关闭一些后重试!");
                }
                else {
                    alert("You open too many pages, please close some and try again!");
                }
                return;
            }
            tab.AddTab(t, src, 'tabh_' + (tab.count + 1));
            tab.SelectTab('tabh_' + tab.count);
        }
    }
}
