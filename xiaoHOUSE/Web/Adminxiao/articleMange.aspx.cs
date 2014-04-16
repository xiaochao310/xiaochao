using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace xiaoHOUSE.Web.Adminxiao
{
    public partial class articleMange : System.Web.UI.Page
    {
        BLL.articles artbll = new BLL.articles();
        BLL.artType typebll = new BLL.artType();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                displayData(1, 12, getWhere());
            }
        }

        void displayData(int pageIndex, int pageSize, string where)
        {
            int totalcount = 0;
            rpArticle.DataSource = artbll.GetListByPage(where, "order by ID desc", pageSize, pageIndex, out totalcount).Tables[0];
            rpArticle.DataBind();
        }

        string getWhere()
        {
            string strWhere = string.Empty;
            if (tbTitleKey.Text.Trim().Length > 0)
            {
                strWhere += "title like '%" + tbTitleKey.Text.Trim() + "%'";
            }
            return strWhere;
        }

        protected void ddlType_change(object sender, EventArgs e)
        {

        }

        protected void lbDelete_click(object sender, EventArgs e)
        {
            LinkButton lbdelete = sender as LinkButton;
            int artid = int.Parse(lbdelete.CommandArgument);

            if (artbll.Delete(artid))
            {
                Common.JavaScriptHelper.Alert("删除成功！", this.Page);
            }

        }

        protected void rpArticle_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            DropDownList ddlType = e.Item.FindControl("ddlType") as DropDownList;
            if (ddlType != null)
            {
                HiddenField hfType = e.Item.FindControl("hdfType") as HiddenField;
                DataSet ds = typebll.GetAllList();
                ddlType.Items.Clear();
                ddlType.Items.Add(new ListItem("请选择", "0"));
                InitList(ddlType, 0, ds, "");
                ddlType.SelectedValue = hfType.Value;
            }
        }

        /// <summary>
        /// 填充下拉列表（递归方法）
        /// </summary>
        /// <param name="dropd"></param>
        /// <param name="parentID"></param>
        /// <param name="ds"></param>
        /// <param name="pre"></param>
        public static void InitList(DropDownList dropd, int parentID, DataSet ds, string pre)
        {
            System.Data.DataRow[] dRow = ds.Tables[0].Select("typeFather=" + parentID, "ID desc");
            int count = dRow.Length;
            DataRow dr;
            for (int i = 0; i < count; i++)
            {
                dr = dRow[i];
                System.Web.UI.WebControls.ListItem item = new System.Web.UI.WebControls.ListItem(pre + "┣" + dr["typeName"].ToString(), dr["ID"].ToString());
                dropd.Items.Add(item);
                InitList(dropd, Int32.Parse(dr["ID"].ToString()), ds, pre + "　");
            }
        }

    }
}