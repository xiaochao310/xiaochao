<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="contents.aspx.cs" Inherits="xiaoHOUSE.Web.contents" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>文章内容</title>
    <link href="Style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="contentdiv">
        <div style="width: 85%; height: 80px; margin: 0 auto; border-bottom: solid 1px black">
            <div style="width: 100%; height: 60px; font-size: 32px; vertical-align: middle; text-align: center;">
                <asp:Label ID="lbl_title" runat="server" Text="标题"></asp:Label>
            </div>
            <div style="width: 100%; height: 20px;">
                <span id="counts" runat="server" style="float: right; position: relative; margin-right: 10px;
                    right: 10px;">111</span>&nbsp;
                <%-- <span  id="type" runat="server" style=" float:right; position:relative;  margin-right:10px; right:10px;">222</span>--%>
                <span id="datetime" runat="server" style="float: right; position: relative; margin-right: 10px;
                    right: 10px;">333</span> &nbsp;<span id="temp" runat="server" style="float: right; position: relative;
                        margin-right: 10px; right: 10px;  ">444</span>
            </div>
        </div>
        <div style="width: 85%; margin: 0 auto;">
            <asp:Literal ID="Literal1" runat="server"></asp:Literal>
        </div>
    </div>
    </form>
</body>
</html>
