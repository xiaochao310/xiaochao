using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace xiaoHOUSE.Web.Controls
{
    public partial class PicViews : System.Web.UI.UserControl
    {
        private static int picHeight = 715;

        public static int PicHeight
        {
            get { return PicViews.picHeight; }
            set { PicViews.picHeight = value; }
        }

        private static int picWidth = 310;

        public static int PicWidth
        {
            get { return PicViews.picWidth; }
            set { PicViews.picWidth = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            rptHomePhoto.DataSource = Common.SqlHelper.ExecuteDataset("server=.;database=xiaoHOUSE;uid=sa;pwd=123", System.Data.CommandType.Text, "select * from images where type=1").Tables[0];
            rptHomePhoto.DataBind();
        }
    }
}