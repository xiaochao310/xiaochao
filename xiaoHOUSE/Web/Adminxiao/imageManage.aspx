<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="imageManage.aspx.cs" Inherits="xiaoHOUSE.Web.Adminxiao.imageManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="image/admStyle.css" rel="stylesheet" type="text/css" />
    <script src="Script/admJs.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Repeater ID="Repeater1" runat="server">
            <HeaderTemplate>
                <table id="myTab" class="admtable" cellpadding="0" cellspacing="0" border="1" style="width: 100%;">
                    <thead>
                        <tr>
                            <th style="width: 5%;">
                                编号
                            </th>
                            <th style="width: 25%;">
                                链接
                            </th>
                            <th style="width: 25%;">
                                图片
                            </th>
                            <th style="width: 10%;">
                                类型
                            </th>
                            <th style="width: 25%;">
                                标题
                            </th>
                            <th style="width: 10%;">
                                操作
                            </th>
                        </tr>
                    </thead>
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td style="text-align: center;">
                        <%#Eval("ID") %>
                    </td>
                    <td class="TIP" title='<%#Eval("imageUrl") %>' style="text-align: center;">
                        <%#Eval("imageUrl") %>
                    </td>
                    <td style="text-align: center;">
                        <img src='<%#imageUrl(Eval("imageSrc").ToString()) %>' style=" width:100%; height:100px;" />
                        
                    </td>
                    <td style="text-align: center;">
                        <%#Eval("type") %>
                    </td>
                    <td>
                        <%#Eval("title") %>
                    </td>
                    <td>
                        <a href="#">修改图片</a>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                <%--<tr>
                    <td colspan="6" style="text-align:center;" >
                        没有数据
                    </td>
                </tr>--%>
                </tbody></table>

            </FooterTemplate>
        </asp:Repeater>
      
    </div>
    </form>
</body>
</html>
