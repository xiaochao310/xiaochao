﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="xiaoHOUSE.Web.index" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>xiaoHOUSE</title>
    <link href="Style.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery-1.4.1.js" type="text/javascript"></script>
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
    <div class="rootdiv">
        <div class="middlediv">
            <div class="headerdiv">
                <div id="picViewBox">
                    <div class="picture">
                      <%--  <img src="images/indexImages/imageTest1.jpg" title="imagetest1" alt="imagetest11111" />
                        <img src="images/indexImages/imageTest2.jpg" title="imagetest2" alt="imagetest21111" />
                        <img src="images/indexImages/imageTest3.jpg" title="imagetest3" alt="imagetest31111" />
                        <img src="images/indexImages/imageTest4.jpg" title="imagetest4" alt="imagetest41111" />--%>
                        <asp:Repeater ID="rptImage" runat="server">
                        <ItemTemplate>
                             <img src='<%#Eval("imageSrc") %>' title='<%#Eval("title") %>' alt='<%#Eval("imageUrl") %>' />
                        </ItemTemplate>
                        </asp:Repeater>
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
            </div>
            <div class="contentdiv">
                <div>
                </div>
                <asp:Repeater ID="rpt_articles" runat="server">
                    <HeaderTemplate>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <div>
                            <div style="border-bottom: 1px solid gray; height: 24px;">
                                <span style="float: left; position: relative; left: 5px;"><a href='<%# "contents-"+Eval("ID")+".html" %>' target="_blank">
                                    <%#Eval("title") %></a></span> <span style="float: right; position: relative; right: 10px;">
                                        <%#Eval("artDatetime") %></span>
                            </div>
                            <div style="border-bottom: 1px dashed gray; height: 80px;">
                                <%# getComments( Eval("contents").ToString())  %>
                            </div>
                            <div style="border-bottom: 1px solid black; height: 24px;">
                            </div>
                        </div>
                    </ItemTemplate>
                    <FooterTemplate>
                        <div>
                            <webdiyer:AspNetPager ID="AspNetPager1" PageSize="8" PrevPageText="上一页" NextPageText="下一页"
                                runat="server" NumericButtonCount="5">
                            </webdiyer:AspNetPager>
                        </div>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
            <div class="bottomdiv">
            </div>
        </div>
    </div>
    </form>
</body>
</html>
