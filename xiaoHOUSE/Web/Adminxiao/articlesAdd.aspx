<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeBehind="articlesAdd.aspx.cs"
    Inherits="xiaoHOUSE.Web.Adminxiao.articlesAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Style.css" rel="stylesheet" type="text/css" />
    <link href="kindeditor-4.1.10/themes/default/default.css" rel="stylesheet" type="text/css" />
    <link href="kindeditor-4.1.10/plugins/code/prettify.css" rel="stylesheet" type="text/css" />
    <script src="kindeditor-4.1.10/kindeditor.js" type="text/javascript"></script>
    <script src="kindeditor-4.1.10/lang/zh_CN.js" type="text/javascript"></script>
    <script src="kindeditor-4.1.10/plugins/code/prettify.js" type="text/javascript"></script>
    <script>
        KindEditor.ready(function (K) {
            var editor1 = K.create('#content1', {
                cssPath: 'kindeditor-4.1.10/plugins/code/prettify.css',
                uploadJson: 'ajaxAshx/upload_json.ashx',
                fileManagerJson: 'ajaxAshx/file_manager_json.ashx',
                allowFileManager: true,
                afterCreate: function () {
                    var self = this;
                    K.ctrl(document, 13, function () {
                        self.sync();
                        K('form[name=example]')[0].submit();
                    });
                    K.ctrl(self.edit.doc, 13, function () {
                        self.sync();
                        K('form[name=example]')[0].submit();
                    });
                }
            });
            prettyPrint();
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="admtopdiv">
            新增文章</div>
        <div class="contents">
            <div style="width: 100%; height: 100%;">
                <table class="addTable" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td class="left">
                            标&nbsp; 题：
                        </td>
                        <td class="right">
                            &nbsp;&nbsp;<asp:TextBox ID="TextBox1" Width="600px" Height="25px" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="left">
                            类&nbsp; 别：
                        </td>
                        <td class="right">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    &nbsp;&nbsp;
                                    <asp:DropDownList ID="DDL_type" runat="server" Height="24px" Width="150px" AutoPostBack="True">
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td class="left">
                            内&nbsp; 容：
                        </td>
                        <td class="right">
                            &nbsp;&nbsp;&nbsp;
                            <textarea id="content1" cols="100" rows="8" style="width: 800px; height: 400px; visibility: hidden;
                                margin-top: 0px;" runat="server"></textarea>
                        </td>
                    </tr>
                    <tr>
                        <td class="left">
                            允许评论：
                        </td>
                        <td class="right">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    &nbsp;&nbsp;<asp:CheckBox ID="CB_isDiscuss" runat="server" Text="允许评论？" AutoPostBack="True" />
                                    <span class="spanTip">默认不允许评论</span></ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td class="left">
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="Button1" runat="server" Text="保 存" OnClick="Button1_Click" />
                            &nbsp;&nbsp;&nbsp;
                            <asp:Button ID="Button2" runat="server" Text="取 消" OnClick="Button2_Click" />
                        </td>
                    </tr>
                </table>
                <div>
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
