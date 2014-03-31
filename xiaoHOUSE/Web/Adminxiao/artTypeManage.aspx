<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="artTypeManage.aspx.cs"
    Inherits="xiaoHOUSE.Web.Adminxiao.artTypeManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="admtopdiv">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            类别管理</div>
        <div class="contents">
            <table style="width: 100%;">
                <tr>
                    <td rowspan="3">
                        
                                <asp:ListBox ID="ListBox1" runat="server" Height="273px" Width="276px" AutoPostBack="True"
                                    OnSelectedIndexChanged="ListBox1_SelectedIndexChanged"></asp:ListBox>
                         
                    </td>
                    <td colspan="2" style="font-size: xx-large; border-bottom: 1px dashed black">
                        选中的项：<asp:Label ID="Label1" runat="server" Text="未选中"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="border-left: 1px dashed gray; width: 35%;">
                        <table class="addTable">
                            <tr>
                                <td colspan="2" class="right">
                                    修改类别
                                </td>
                            </tr>
                            <tr>
                                <td class="left">
                                    编 号：
                                </td>
                                <td class="right">
                                    <asp:TextBox ID="txtb_u_ID" Height="24px" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="left">
                                    名 称：
                                </td>
                                <td class="right">
                                    <asp:TextBox ID="txtb_u_Name" Height="24px" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="left">
                                    父节点:
                                </td>
                                <td class="right">
                                    <asp:TextBox ID="txtb_u_father" Height="24px" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="left">
                                    描 述：
                                </td>
                                <td class="right">
                                    <asp:TextBox ID="txtb_u_discribt" Height="63px" runat="server" TextMode="MultiLine"
                                        Width="180px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" style="text-align: center;" class="right">
                                    <asp:Button ID="btn_u_sure" runat="server" Text="确  定" 
                                        onclick="btn_u_sure_Click" Enabled="False" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btn_u_cancel" runat="server" 
                                        Text="取  消" onclick="btn_u_cancel_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td style="border-left: 1px dashed gray;">
                        <table class="addTable">
                            <tr>
                                <td colspan="2" class="right">
                                    新增类别<span class="spanTip">未选择是新增父节点为0的类别</span>
                                </td>
                            </tr>
                            <tr>
                                <td class="left">
                                    名 称：
                                </td>
                                <td class="right">
                                    <asp:TextBox ID="txtb_n_name" Height="24px" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="left">
                                    描 述：
                                </td>
                                <td class="right">
                                    <asp:TextBox ID="txtb_n_discribt" Height="63px" runat="server" TextMode="MultiLine"
                                        Width="180px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" class="right" style="text-align: center;">
                                    <asp:Button ID="btn_n_sure" runat="server" Text="确  定" 
                                        onclick="btn_n_sure_Click" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btn_n_cancel" runat="server" 
                                        Text="取  消" onclick="btn_n_cancel_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" class="left">
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" class="left">
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" style="text-align: right;">
                        <asp:Button ID="Button5" runat="server" Text="取消编辑" onclick="Button5_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    </form>
</body>
</html>
