using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;

namespace xiaoHOUSE.Web
{
    public partial class index : System.Web.UI.Page
    {
        BLL.articles articlebll = new BLL.articles();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { bindData(); }
        }

        protected void bindData()
        {
            rpt_articles.DataSource = articlebll.GetAllList();
            rpt_articles.DataBind();
        }

        public string getComments(string htmlTxt)
        {
            string txt = Common.StringHelper.HtmlToTxt(htmlTxt);
            if (txt.Length > 200)
            {
                txt = txt.Substring(1, 200);
            }
            return "&nbsp;&nbsp;&nbsp;&nbsp;"+txt+"...";
        }

    }
}