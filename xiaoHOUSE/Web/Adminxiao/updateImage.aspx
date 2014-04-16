<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="updateImage.aspx.cs" Inherits="xiaoHOUSE.Web.Adminxiao.updateImage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table cellpadding="0" cellspacing="0" style="width: 423px; height: 279px;">
            <tr>
                <td style="width: 30%; text-align: right;">
                    编号：
                </td>
                <td style="width: 70%;">
                    <asp:Label ID="lblID" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align: right;">
                    链接：
                </td>
                <td>
                    <asp:TextBox ID="tbImageUrl" Width="200px" Height="50px" TextMode="MultiLine" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: right;">
                    图片：
                </td>
                <td>
                    <asp:FileUpload ID="FileUpload1" runat="server" />
            </tr>
            <tr>
                <td style="text-align: right;">
                    类型：
                </td>
                <td>
                    <asp:DropDownList ID="ddlType" runat="server">
                        <asp:ListItem Text="首页图片" Value="1"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="text-align: right;">
                    标题：
                </td>
                <td>
                    <asp:TextBox ID="tbtitle" Width="200px" Height="50px" TextMode="MultiLine" runat="server"></asp:TextBox>
                </td>
            </tr>
                <tr>
                    <td  style="text-align: right;">
                        <asp:Button ID="btnSure" runat="server" Text="提 交" /></td>
                    <td></td>
                </tr>
        </table>
    </div>
    </form>
</body>
</html>
