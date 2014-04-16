/// <reference path="Jquery.doc.js" />
$(function () {
    $("td.TIP").mouseover(function (e) {
        this.myTitle = this.title;
        this.title = "";
        var toolTip = "<div id='tooltip'>" + this.myTitle + "</div>";
        $("body").append(toolTip);
        $("#tooltip").css({
            "position": "absolute",
            "padding": "5px",
            "background": "#F0F0E8",
            "border": "1px gray solid",
            "top": (e.pageY + y) + "px",
            "left": (e.pageX + x) + "px"
        }).show(200);
    }).mouseout(function () {
        this.title = this.myTitle;
        $("#tooltip").remove();
    }).mousemove(function (e) {
        $("#tooltip").css({
            "background": "#F0F0E8",
            "padding": "5px",
            "border": "1px gray solid",
            "top": (e.pageY + y) + "px",
            "left": (e.pageX + x) + "px"
        })
    })
    $("#btnAlldel").click(function () {
        if (confirm("你确定删除所有选中的信息？")) {
            var checkValue = "";
            $("[name=selected]:checkbox:checked").each(function () {
                if ($.trim($(this).val()).length > 0) {
                    checkValue += "," + $.trim($(this).val());
                }
            })
            if (checkValue.length == 0) {
                alert("你没有选择任何信息，请先选中要删除的信息！");
                return false;
            }
            else {
                $("#hidCheckList").val(checkValue.substr(1));
            }
            return true;
        }
        else {
            return false;
        }
    })
    $("#BtnAllSelect").click(function () {
        if ($("#BtnAllSelect").val() == "全 选") {
            $("#BtnAllSelect").val("反 选");
            $("[name=selected]:checkbox").attr("checked", true);
        }
        else {
            $("#BtnAllSelect").val("全 选");
            $("[name=selected]:checkbox").each(function () {
                //$(this).attr("checked", !$(this).attr("checked"));
                this.checked = !this.checked;
            })
        }
    })
    $("#lb_delete").click(function () {
        if (confirm("确定删除该信息？该信息下的所有相关信息都将删除！")) {
            return true;
        }
        return false;
    })

    $("#myTab tbody>tr:even").css("background", "#F0F0E8");
    $("#myTab tbody>tr").mouseover(function () {
        $(this).css("background", "#DAE9FB");
    });
    $("#myTab tbody>tr").mouseout(function () {
        $("#myTab tbody>tr:even").css("background", "#F0F0E8");
        $("#myTab tbody>tr:odd").css("background", "#FFFFFF");
    });
     
});
 