using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace xiaoHOUSE.Web.Adminxiao
{
    public partial class articlesAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                defaultfun();
            }
        }

        protected void defaultfun()
        {
            BindDropDownList(DDL_type);
            TextBox1.Text = "";
            content1.Value = "";
            CB_isDiscuss.Checked = false;
        }

        /// <summary>
        /// 页面错误判断
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();
            if (ex is HttpRequestValidationException)
            {
                Response.Write("请您输入合法字符串。");
                Server.ClearError(); // 如果不ClearError()这个异常会继续传到Application_Error()。
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string contents = content1.Value;
            string title = TextBox1.Text.Trim();
            string type = DDL_type.SelectedValue;
            int isDiscuss = CB_isDiscuss.Checked ? 1 : 0;
            string errMsg = string.Empty;
            if (contents.Length <= 0) { errMsg += "内容不能为空啊！\\n"; }
            if (title.Length <= 0) { errMsg += "标题不能为空啊！\\n"; }
            if (type == "0") { errMsg += "请选择一个类别吧！\\n"; }
            if (errMsg.Length > 0) { Common.JavaScriptHelper.Alert(errMsg, this.Page); return; }
            BLL.articles articlesbll = new BLL.articles();
            Model.articles articlesmodel = new Model.articles();
            articlesmodel.contents = contents;
            articlesmodel.title = title;
            articlesmodel.artType = Convert.ToInt32(type);
            articlesmodel.isDiscuss = isDiscuss;
            int artid = articlesbll.Add(articlesmodel);
            if (artid > 0) { Common.JavaScriptHelper.Alert("添加文章成功，文章ID为" + artid, this.Page); defaultfun(); }
            else { Common.JavaScriptHelper.Alert("添加文章失败，请重试！", this.Page); }
        }

        #region 绑定下拉列表的值
        /// <summary>
        /// 绑定下拉列表
        /// </summary>
        /// <param name="drop"></param>
        public static void BindDropDownList(DropDownList drop)
        {
            BLL.artType typeBll = new BLL.artType();
            Model.artType typeModel = new Model.artType();
            DataSet ds = typeBll.GetAllList();
            drop.Items.Clear();
            drop.Items.Add(new ListItem("---------请选择目录--------", "0"));
            InitList(drop, 0, ds, "");
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
        #endregion

        protected void Button2_Click(object sender, EventArgs e)
        {
            defaultfun();
        }


    }
}