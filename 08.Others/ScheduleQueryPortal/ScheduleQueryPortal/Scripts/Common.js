// JScript 文件

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
