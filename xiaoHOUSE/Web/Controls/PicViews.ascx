<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PicViews.ascx.cs" Inherits="xiaoHOUSE.Web.Controls.PicViews" %>
<div>
    <div id="fade_focus" class="d1" style="background-image: none; background-position: initial initial;
        background-repeat: initial initial;">
        <ul>
            <asp:Repeater ID="rptHomePhoto" runat="server">
                <ItemTemplate>
                    <li><a href="<%# Eval("imageUrl") %>" target="_blank">
                        <img src="<%# Eval("imageSrc") %>" border="0" width="715" height="310" /></a></li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
        <div class="button">
            <a href="#" rel="1" style="display: block; float: left; padding: 0px; width: 20px;
                text-align: center; height: 20px; color: #ffffff; line-height: 20px; margin-right: 6px;
                background: #E1DFE0; cursor: pointer; font-weight: normal; text-decoration: none;
                overflow: hidden;">1</a> <a href="#" rel="2" style="display: block; float: left;
                    padding: 0px; width: 20px; text-align: center; height: 20px; color: #ffffff;
                    line-height: 20px; margin-right: 6px; background: #E1DFE0; cursor: pointer; font-weight: normal;
                    text-decoration: none; overflow: hidden;">2</a> <a href="#" rel="3" style="display: block;
                        float: left; padding: 0px; width: 20px; text-align: center; height: 20px; color: #ffffff;
                        line-height: 20px; margin-right: 6px; background: #E1DFE0; cursor: pointer; font-weight: normal;
                        text-decoration: none; overflow: hidden;">3</a> <a href="#" rel="4" style="display: block;
                            float: left; padding: 0px; width: 20px; text-align: center; height: 20px; color: #ffffff;
                            line-height: 20px; margin-right: 6px; background: #E1DFE0; cursor: pointer; font-weight: normal;
                            text-decoration: none; overflow: hidden;">4</a>
        </div>
    </div>
    <script language="javascript" type="text/javascript">
        var s = function () { var interv = 3000; var interv2 = 20; var opac1 = 80; var source = "fade_focus"; function getTag(tag, obj) { if (obj == null) { return document.getElementsByTagName(tag) } else { return obj.getElementsByTagName(tag) } } function getid(id) { return document.getElementById(id) }; var opac = 0, j = 0, t = 63, num, scton = 0, timer, timer2, timer3; var id = getid(source); id.removeChild(getTag("div", id)[0]); var li = getTag("li", id); var div = document.createElement("div"); var title = document.createElement("div"); var span = document.createElement("span"); var button = document.createElement("div"); button.className = "button"; for (var i = 0; i < li.length; i++) { var a = document.createElement("a"); a.innerHTML = i + 1/*getTag("img",li[i])[0].alt*/; a.href = getTag("a", li[i])[0].href; a.target = '_blank'; a.rel = i + 1; a.onclick = function () { clearTimeout(timer); clearTimeout(timer2); clearTimeout(timer3); j = parseInt(this.rel) - 1; scton = 0; t = 63; opac = 0; fadeon() }; a.className = "b1"; a.onmouseover = function () { this.className = "b2"; clearTimeout(timer); clearTimeout(timer2); clearTimeout(timer3); j = parseInt(this.rel) - 1; scton = 0; t = 63; opac = 0; fadeon() }; a.onmouseout = function () { this.className = "b1"; sc(j) }; button.appendChild(a) } function alpha(obj, n) { if (document.all) { obj.style.filter = "alpha(opacity=" + n + ")" } else { obj.style.opacity = (n / 100) } } function sc(n) { for (var i = 0; i < li.length; i++) { button.childNodes[i].className = "b1" }; button.childNodes[n].className = "b2" } title.className = "num_list"; title.appendChild(span); alpha(title, opac1); id.className = "d1"; div.className = "d2"; id.appendChild(div); id.appendChild(title); id.appendChild(button); var fadeon = function () { opac += 5; div.innerHTML = li[j].innerHTML; span.innerHTML = getTag("img", li[j])[0].alt; alpha(div, opac); if (scton == 0) { sc(j); num = -2; scrolltxt(); scton = 1 }; if (opac < 100) { timer = setTimeout(fadeon, interv2) } else { timer2 = setTimeout(fadeout, interv) } }; var fadeout = function () { opac -= 5; div.innerHTML = li[j].innerHTML; alpha(div, opac); if (scton == 0) { num = 2; scrolltxt(); scton = 1 }; if (opac > 0) { timer = setTimeout(fadeout, interv2) } else { if (j < li.length - 1) { j++ } else { j = 0 }; fadeon() } }; var scrolltxt = function () { t += num; span.style.marginTop = t + "px"; if (num < 0 && t > 3) { timer3 = setTimeout(scrolltxt, interv2) } else if (num > 0 && t < 62) { getid(source).style.background = 'none'; timer3 = setTimeout(scrolltxt, interv2) } else { scton = 0 } }; fadeon() }; s();
    </script>
</div>
