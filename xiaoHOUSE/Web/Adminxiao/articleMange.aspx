<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="articleMange.aspx.cs" Inherits="xiaoHOUSE.Web.Adminxiao.articleMange" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>文章管理</title>
    <link href="image/admStyle.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="rootdiv">
        <div class="searchdiv">
            <table>
                <tr>
                    <td>
                    </td>
                    <td>
                        文章标题：<asp:TextBox ID="tbTitleKey" runat="server"></asp:TextBox>
                    </td>
                    <td>
                    </td>
                    <td>
                        <asp:Button ID="btnSearch" runat="server" Text="Button" />
                    </td>
                </tr>
            </table>
        </div>
        <div class="contentdiv">
            <asp:Repeater ID="rpArticle" runat="server" OnItemDataBound="rpArticle_ItemDataBound">
                <HeaderTemplate>
                    <table cellpadding="0" cellspacing="0" border="1" class="admtable">
                        <thead>
                            <tr>
                                <th style="width: 5%">
                                    编号
                                </th>
                                <th style="width: 30%">
                                    标题
                                </th>
                                <th style="width: 10%">
                                    类别
                                </th>
                                <th style="width: 15%">
                                    作者
                                </th>
                                <th style="width: 15%">
                                    时间
                                </th>
                                <th style="width: 10%">
                                    浏览次数
                                </th>
                                <th style="width: 15%">
                                    操作
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td id="artID" runat="server" style="text-align: center;">
                            <%#Eval("ID") %>
                        </td>
                        <td>
                            <%#Eval("title") %>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlType" AutoPostBack="true"  OnSelectedIndexChanged="ddlType_change"  
                                runat="server">
                            </asp:DropDownList>
                            <asp:HiddenField ID="hdfType" Value='<%#Eval("artType") %>' runat="server" />
                        </td>
                        <td style="text-align: center;">
                            <%#Eval("temp1") %>
                        </td>
                        <td style="text-align: center;">
                            <%#Eval("artDatetime") %>
                        </td>
                        <td style="text-align: center;">
                            <%#Eval("counts") %>
                        </td>
                        <td>
                            <asp:LinkButton ID="lbUpdate" runat="server">修改</asp:LinkButton>|<asp:LinkButton
                                ID="lbDelete" CommandArgument='<%#Eval("ID") %>' OnClick="lbDelete_click" OnClientClick="javascript:return confirm('确认删除吗')" runat="server">删除</asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    <tr  runat="server" visible='<%#rpArticle.Items.Count==0 %>'>
                        <td colspan="7" style="text-align: center;">
                            当前没有数据显示
                        </td>
                    </tr>
                    </tbody> </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </div>
    </form>
</body>
</html>
