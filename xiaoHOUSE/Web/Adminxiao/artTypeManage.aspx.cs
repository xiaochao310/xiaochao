using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace xiaoHOUSE.Web.Adminxiao
{
    public partial class artTypeManage : System.Web.UI.Page
    {
        BLL.artType typeBll = new BLL.artType();
        Model.artType typeModel = new Model.artType();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                defaultfun();
            }
        }

        protected void defaultfun()
        {
            BindListBox(ListBox1);
            txtb_u_Name.Text = "";
            txtb_u_ID.Text = "";
            txtb_u_father.Text = "";
            txtb_u_discribt.Text = "";
            txtb_n_name.Text = "";
            txtb_n_discribt.Text = "";
            Label1.Text = "未选中";
            btn_u_sure.Enabled = false;
        }

        #region 绑定
        /// <summary>
        /// 绑定
        /// </summary>
        /// <param name="drop"></param>
        public static void BindListBox(ListBox Lbox)
        {
            BLL.artType typeBll = new BLL.artType();
            System.Data.DataSet ds = typeBll.GetAllList();
            Lbox.Items.Clear();
            //drop.Items.Add(new ListItem("---------请选择目录--------", "0"));
            InitList(Lbox, 0, ds, "");
        }

        /// <summary>
        /// 填充数据（递归方法）
        /// </summary>
        /// <param name="dropd"></param>
        /// <param name="parentID"></param>
        /// <param name="ds"></param>
        /// <param name="pre"></param>
        public static void InitList(ListBox Lbox, int parentID, System.Data.DataSet ds, string pre)
        {
            System.Data.DataRow[] dRow = ds.Tables[0].Select("typeFather=" + parentID, "ID asc");
            int count = dRow.Length;
            System.Data.DataRow dr;
            for (int i = 0; i < count; i++)
            {
                dr = dRow[i];
                System.Web.UI.WebControls.ListItem item = new System.Web.UI.WebControls.ListItem(pre + dr["ID"].ToString() + "┣" + dr["typeName"].ToString(), dr["ID"].ToString());
                Lbox.Items.Add(item);
                InitList(Lbox, Int32.Parse(dr["ID"].ToString()), ds, pre + "　");
            }
        }
        #endregion

        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label1.Text =  ListBox1.SelectedItem.Text;
            typeModel = typeBll.GetModel(int.Parse(ListBox1.SelectedItem.Value));
            txtb_u_ID.Text = typeModel.ID.ToString();
            txtb_u_Name.Text = typeModel.typeName;
            txtb_u_father.Text = typeModel.typeFather.ToString();
            txtb_u_discribt.Text = typeModel.description;
            txtb_u_ID.Enabled = false;
            txtb_n_discribt.Text = "";
            txtb_n_name.Text = "";
            btn_u_sure.Enabled = true;
        }

        protected void btn_n_sure_Click(object sender, EventArgs e)
        {
            string typeName = txtb_n_name.Text.Trim();
            string description = txtb_n_discribt.Text.Trim();
            string errMsg = string.Empty;
            if (typeName.Length <= 0) { errMsg += "类型名称不能为空！//n"; }
            if (errMsg.Length > 0) { Common.JavaScriptHelper.Alert(errMsg, this.Page); return; }
            typeModel.typeName = typeName;
            typeModel.description = description;
            if (Label1.Text == "未选中")
            {
                typeModel.typeFather = 0;
            }
            else
            {
                typeModel.typeFather = int.Parse(ListBox1.SelectedItem.Value);
            }
            if (typeBll.Add(typeModel) > 0) { Common.JavaScriptHelper.Alert("添加成功", this.Page); defaultfun(); }
            else { Common.JavaScriptHelper.Alert("添加失败，请重试", this.Page); }
        }

        protected void btn_u_sure_Click(object sender, EventArgs e)
        {
            string errMsg = string.Empty;
            string typeName = txtb_u_Name.Text.Trim();
            string typeFather = txtb_u_father.Text.Trim();
            string description = txtb_u_discribt.Text.Trim();
            if (typeName.Length <= 0) { errMsg += "类型名称不能为空！//n"; }
            if (typeFather.Length <= 0) { errMsg += "父节点不能为空！可为0//n"; }
            if (errMsg.Length > 0) { Common.JavaScriptHelper.Alert(errMsg, this.Page); return; }
            typeModel.typeName = typeName;
            typeModel.description = description;
            typeModel.ID = int.Parse(ListBox1.SelectedItem.Value);
            typeModel.typeFather = int.Parse(typeFather);
            if (typeBll.Update(typeModel)) { Common.JavaScriptHelper.Alert("修改成功", this.Page); defaultfun(); }
            else { Common.JavaScriptHelper.Alert("修改失败，请重试", this.Page); }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            defaultfun();
        }

        protected void btn_n_cancel_Click(object sender, EventArgs e)
        {
            txtb_n_discribt.Text = "";
            txtb_n_name.Text = "";
        }

        protected void btn_u_cancel_Click(object sender, EventArgs e)
        {
            txtb_u_discribt.Text = "";
            txtb_u_father.Text = "";
            txtb_u_ID.Text = "";
            txtb_u_Name.Text = "";
        }


    }
}