using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace xiaoHOUSE.Web
{
    public partial class contents : System.Web.UI.Page
    {
        BLL.articles articlebll = new BLL.articles();
        Model.articles articlemodel = new Model.articles();

        protected void Page_Load(object sender, EventArgs e)
        {
            showArticle();
        }

        protected void showArticle()
        {
            string id = Request.QueryString["id"];
            int idint = 0;
            try
            {
                idint = int.Parse(id);
            }
            catch
            {
                Common.JavaScriptHelper.Alert("参数错误", this.Page);
                return;
            }
            articlemodel = articlebll.GetModel(idint);
            if (articlemodel != null)
            {
                articlemodel.counts = articlemodel.counts + 1;
                articlebll.Update(articlemodel);
                lbl_title.Text = articlemodel.title;
                this.Title = articlemodel.title;
                this.Literal1.Text = articlemodel.contents;
                datetime.InnerText = "发表时间：" + articlemodel.artDatetime.ToString();
                counts.InnerText = "浏览总量："+articlemodel.counts.ToString();
                temp.InnerText = "作者：" + (articlemodel.temp1.Length>0?articlemodel.temp1:"本人");
            }
            else
            {
                Literal1.Text = "此文章不存在或文章已被删除！";
            }
        }


    }
}