<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="xiaoHOUSE.Web.Adminxiao.index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>xiaoHOUSE后台管理</title>
    <script src="Script/jquery-1.4.1.min.js" type="text/javascript"></script>
    <link href="Script/ui/skins/Aqua/css/ligerui-all.css" rel="stylesheet" type="text/css" />
    <script src="Script/ui/js/ligerBuild.min.js" type="text/javascript"></script>
    <link href="Style/admstyle.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        var tab = null;
        var accordion = null;
        var tree = null;
        $(function () {

            //页面布局
            $("#global_layout").ligerLayout({ leftWidth: 180, height: '100%', topHeight: 65, bottomHeight: 24, allowTopResize: false, allowBottomResize: false, allowLeftCollapse: true, onHeightChanged: f_heightChanged });

            var height = $(".l-layout-center").height();

            //Tab
            $("#framecenter").ligerTab({ height: height });

            //左边导航面板
            $("#global_left_nav").ligerAccordion({ height: height - 25, speed: null });

            $(".l-link").hover(function () {
                $(this).addClass("l-link-over");
            }, function () {
                $(this).removeClass("l-link-over");
            });

            //设置频道菜单
            $("#global_channel_tree").ligerTree({
                url: '../tools/admin_ajax.ashx?action=sys_channel_load',
                checkbox: false,
                nodeWidth: 112,
                //attribute: ['nodename', 'url'],
                onSelect: function (node) {
                    if (!node.data.url) return;
                    var tabid = $(node.target).attr("tabid");
                    if (!tabid) {
                        tabid = new Date().getTime();
                        $(node.target).attr("tabid", tabid)
                    }
                    f_addTab(tabid, node.data.text, node.data.url);
                }
            });

            //快捷菜单
            var menu = $.ligerMenu({ width: 120, items:
		[
			{ text: '管理首页', click: itemclick },
			{ text: '修改密码', click: itemclick },
			{ line: true },
			{ text: '关闭菜单', click: itemclick }
		]
            });
            $("#tab-tools-nav").bind("click", function () {
                var offset = $(this).offset(); //取得事件对象的位置
                menu.show({ top: offset.top + 27, left: offset.left - 120 });
                return false;
            });

            tab = $("#framecenter").ligerGetTabManager();
            $("#pageloading_bg,#pageloading").hide();
        });

        //快捷菜单回调函数
        function itemclick(item) {
            switch (item.text) {
                case "管理首页":
                    f_addTab('home', '管理中心', 'center.aspx');
                    break;
                case "快捷导航":
                    //调用函数
                    break;
                case "修改密码":
                    f_addTab('manager_pwd', '修改密码', 'manager/manager_pwd.aspx');
                    break;
                default:
                    //关闭窗口
                    break;
            }
        }
        function f_heightChanged(options) {
            if (tab)
                tab.addHeight(options.diff);
            if (accordion && options.middleHeight - 24 > 0)
                accordion.setHeight(options.middleHeight - 24);
        }
        //添加Tab，可传3个参数
        function f_addTab(tabid, text, url, iconcss) {
            if (arguments.length == 4) {
                tab.addTabItem({ tabid: tabid, text: text, url: url, iconcss: iconcss });
            } else {
                tab.addTabItem({ tabid: tabid, text: text, url: url });
            }
        }
        //提示Dialog并关闭Tab
        function f_errorTab(tit, msg) {
            $.ligerDialog.open({
                isDrag: false,
                allowClose: false,
                type: 'error',
                title: tit,
                content: msg,
                buttons: [{
                    text: '确定',
                    onclick: function (item, dialog, index) {
                        //查找当前iframe名称
                        var itemiframe = "#framecenter .l-tab-content .l-tab-content-item";
                        var curriframe = "";
                        $(itemiframe).each(function () {
                            if ($(this).css("display") != "none") {
                                curriframe = $(this).attr("tabid");
                                return false;
                            }
                        });
                        if (curriframe != "") {
                            tab.removeTabItem(curriframe);
                            dialog.close();
                        }
                    }
                }]
            });
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="pageloading_bg" id="pageloading_bg">
    </div>
    <div id="pageloading">
        数据加载中，请稍等...</div>
    <div id="global_layout" class="layout" style="width: 100%">
        <!--头部-->
        <div position="top" class="header">
            <div class="header_box">
                <div class="header_right">
                    <span><b></b>您好，欢迎光临</span>
                    <br />
                    <a href="javascript:f_addTab('home','管理中心','default.aspx')">管理中心</a> | <a target="_blank"
                        href="../">预览网站</a> |
                    <asp:LinkButton ID="lbtnExit" runat="server">安全退出</asp:LinkButton>
                </div>
                <img src="Images/logo.png" align="absmiddle" style="cursor: pointer" />
            </div>
        </div>
        <!--左边-->
        <div position="left" title="管理菜单" id="global_left_nav">
            
            <%--文章 --%>
            <div title="文章管理" iconcss="menu-icon-model">
                <ul class="nlist">
                    <li><a href="javascript:f_addTab('art_manage','文章管理',' articleMange.aspx')">文章管理</a></li>
                    <li><a href="javascript:f_addTab('art_new','新增文章','articlesAdd.aspx')">新增文章</a></li>
                    <li><a href="javascript:f_addTab('art_type','文章类别管理','artTypeManage.aspx')">文章类别管理</a></li>
                </ul>
            </div>
             <div title="图片管理" iconcss="menu-icon-model">
                <ul class="nlist">
                    <li><a href="javascript:f_addTab('imageManage','图片管理','imageManage.aspx')">图片管理</a></li>
                    <li><a href="javascript:f_addTab('art_new','新增文章','articlesAdd.aspx')">新增文章</a></li>
                    <li><a href="javascript:f_addTab('art_type','文章类别管理','artTypeManage.aspx')">文章类别管理</a></li>
                </ul>
            </div>
          <%--  
            <div title="会员管理" iconcss="menu-icon-member">
                <ul class="nlist">
                    <li><a href="javascript:f_addTab('user_manage','用户管理','calendar1Test.aspx')">用户管理</a></li>
                    <li><a href="javascript:f_addTab('user_cheek','用户信息查询','DivDropdown.aspx')">用户信息查询</a></li>
                    <li><a href="javascript:f_addTab('user_account','用户账户查看','users/message_list.aspx')">
                        用户账户查看</a></li>
                    <li><a href="javascript:f_addTab('user_new','新增用户','yonghu/AddUser.aspx')">新增用户</a></li>
                    <li><a href="javascript:f_addTab('user_password','修改密码','users/point_log.aspx')">修改密码</a></li>
                    <li><a href="javascript:f_addTab('user_fee','会员消费信息','users/mail_template_list.aspx')">
                        会员消费信息</a></li>
                    <li><a class="l-link" href="javascript:f_addTab('user_message','会员站内信管理','users/user_config.aspx')">
                        会员站内信管理</a></li>
                </ul>
            </div>--%>
          
        </div>
        <div position="center" id="framecenter" toolsid="tab-tools-nav">
            <div tabid="home" title="管理中心" iconcss="tab-icon-home" style="height: 300px">
                <iframe frameborder="0" name="sysMain" src="default.aspx"></iframe>
            </div>
        </div>
        <div position="bottom" class="footer">
            <div class="copyright">
                Copyright &copy; 2014. <span style="color: Red;">xiaoHOUSE</span> All Rights Reserved.</div>
        </div>
    </div>
    </form>
</body>
</html>
