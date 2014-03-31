<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="kindeditorTest.aspx.cs"
    Inherits="xiaoHOUSE.Web.test.kindeditorTest" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>富文本编辑器kindeditor测试</title>
    <link href="kindeditor-4.1.10/themes/default/default.css" rel="stylesheet" type="text/css" />
    <link href="kindeditor-4.1.10/plugins/code/prettify.css" rel="stylesheet" type="text/css" />
    <script src="kindeditor-4.1.10/kindeditor.js" type="text/javascript"></script>
    <script src="kindeditor-4.1.10/lang/zh_CN.js" type="text/javascript"></script>
    <script src="kindeditor-4.1.10/plugins/code/prettify.js" type="text/javascript"></script>
    <script>
        KindEditor.ready(function (K) {
            var editor1 = K.create('#content1', {
                cssPath: '../plugins/code/prettify.css',
                uploadJson: '../asp.net/upload_json.ashx',
                fileManagerJson: '../asp.net/file_manager_json.ashx',
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
        <textarea id="content1" cols="100" rows="8" style="width: 700px; height: 200px; visibility: hidden;"
            runat="server"></textarea>
        <br />
        <asp:Button ID="Button1" runat="server" Text="显示内容" onclick="Button1_Click" />
    </div>
    </form>
</body>
</html>
