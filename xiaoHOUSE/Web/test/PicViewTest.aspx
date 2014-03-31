<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PicViewTest.aspx.cs" Inherits="xiaoHOUSE.Web.test.PicViewTest" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>图片轮播效果测试</title>
    <script src="../js/jquery-1.4.1.min.js" type="text/javascript"></script>
    <style type="text/css">
        #picViewBox
        {
            width: 750px;
            height: 340px;
            margin: 0 auto;
            border: 1px red solid;
            position: relative;
        }
        .picture img
        {
            width: 750px;
            height: 340px;
            display: none;
            position: absolute;
        }
        .boxTitle
        {
            height: 25px;
            width: 100%;
            position: absolute;
            bottom: 0;
            filter: alpha(opacity=50);
            background: #FFF;
            opacity: 0.5;
        }
        img
        {
            width: 750px;
            height: 340px;
        }
        #title
        {
            position: relative;
            float: left;
            width: 500px;
        }
        .pageList div
        {
            float: right;
            color: #FFF;
            font-size: 13px;
            display: block;
            border: 2px solid #e5eaff;
            width: 20px;
            height: 20px;
            margin-right: 4px;
            margin-top: 0px;
            text-align: center;
            line-height: 18px;
            background-color: #6f4f67;
            cursor: pointer;
            opacity: 1;
        }
        #title a
        {
            text-decoration: none;
        }
        #title a:link
        {
            color: Black;
        }
        #title a:visited
        {
            color: Black;
        }
        #title a:hover
        {
            color: red;
        }
    </style>
    <script type="text/javascript" language="javascript">
        var n = 0, time = 4000;
        $(document).ready(function () {
            $("#pageList div").click(function () {
                var i = $(this).text() - 1;
                n = i;
                $("#pageList div").css("background-color", "#6f4f67");
                $(this).css("background-color", "#FF70Ad");
                $(".picture img").hide().parent().children().eq(i).show();
                $("#title").html("<a href='" + $(".picture img").eq(i).attr("alt") + "' target='_blank'>" + $(".picture img").eq(i).attr("title") + "</a>");
            });
            var time1 = setInterval("showAuto()", time);
            $("#pageList div").mouseover(function () {
                clearInterval(time1);
            });
            $("#pageList div").mouseout(function () {
                time1 = setInterval("showAuto()", time);
            });
        });
        function showAuto() {
            n = n >= ($(".picture img").length - 1) ? 0 : ++n;
            $("#pageList div").css("background-color", "#6f4f67");
            $("#pageList div:contains('" + (n + 1) + "')").css("background-color", "#FF70Ad");
            $(".picture img").hide().parent().children().eq(n).show();
            $("#title").html("<a href='" + $(".picture img").eq(n).attr("alt") + "' target='_blank'>" + $(".picture img").eq(n).attr("title") + "</a>");
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="picViewBox">
        <div class="picture">
            <img src="images/imageTest1.jpg" title="imagetest1" alt="imagetest11111" />
            <img src="images/imageTest2.jpg" title="imagetest2" alt="imagetest21111" />
            <img src="images/imageTest3.jpg" title="imagetest3" alt="imagetest31111" />
            <img src="images/imageTest4.jpg" title="imagetest4" alt="imagetest41111" />
        </div>
        <div class="boxTitle">
            <div id="title">
            </div>
            <div id="pageList" class="pageList">
                <div>
                    4</div>
                <div>
                    3</div>
                <div>
                    2</div>
                <div style="background: #FF70Ad;">
                    1</div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
