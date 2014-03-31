<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JQueryyZoom.aspx.cs" Inherits="xiaoHOUSE.Web.test.JQueryyZoom" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Jquery图片放大镜效果测试</title>
    <script src="../js/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">
        $(document).ready(function () {
            


        });
    
    </script>
    <style type="text/css">
        #small
        {
            background-image:url("images/imageTest1.jpg"); 
            width:320px;
            height:200px;
            }
        #big
        {
            width:160px;
            height:100px; 
            border:1px solid red;
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div >
        <img id="small" src="images/imageTest1.jpg" />
    </div>
    <br />
    <div id="big"></div>
    </form>
</body>
</html>
