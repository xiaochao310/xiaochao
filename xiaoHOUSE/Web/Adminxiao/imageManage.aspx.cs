using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace xiaoHOUSE.Web.Adminxiao
{
    public partial class imageManage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                displayData();
        }

        void displayData()
        {
            BLL.images imagebll = new BLL.images();
            Repeater1.DataSource = imagebll.GetAllList().Tables[0];
            Repeater1.DataBind();
        }

        public string imageUrl(string url) {
            string realUrl = string.Empty;
            if (url.Length > 0) {
                realUrl = "../" + url;
            }
            return realUrl;
        }

    }
}