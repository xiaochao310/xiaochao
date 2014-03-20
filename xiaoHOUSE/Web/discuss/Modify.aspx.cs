using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using Maticsoft.Common;
using LTP.Accounts.Bus;
namespace xiaoHOUSE.Web.discuss
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int ID=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(ID);
				}
			}
		}
			
	private void ShowInfo(int ID)
	{
		xiaoHOUSE.BLL.discuss bll=new xiaoHOUSE.BLL.discuss();
		xiaoHOUSE.Model.discuss model=bll.GetModel(ID);
		this.lblID.Text=model.ID.ToString();
		this.txtartID.Text=model.artID.ToString();
		this.txtuserID.Text=model.userID.ToString();
		this.txtuserName.Text=model.userName;
		this.txtdisDate.Text=model.disDate.ToString();
		this.txtContents.Text=model.Contents;
		this.txtrootID.Text=model.rootID.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtartID.Text))
			{
				strErr+="文章编号格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtuserID.Text))
			{
				strErr+="评论人格式错误！\\n";	
			}
			if(this.txtuserName.Text.Trim().Length==0)
			{
				strErr+="评论人名称不能为空！\\n";	
			}
			if(!PageValidate.IsDateTime(txtdisDate.Text))
			{
				strErr+="评论时间格式错误！\\n";	
			}
			if(this.txtContents.Text.Trim().Length==0)
			{
				strErr+="内容不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtrootID.Text))
			{
				strErr+="评论父编号格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int ID=int.Parse(this.lblID.Text);
			int artID=int.Parse(this.txtartID.Text);
			int userID=int.Parse(this.txtuserID.Text);
			string userName=this.txtuserName.Text;
			DateTime disDate=DateTime.Parse(this.txtdisDate.Text);
			string Contents=this.txtContents.Text;
			int rootID=int.Parse(this.txtrootID.Text);


			xiaoHOUSE.Model.discuss model=new xiaoHOUSE.Model.discuss();
			model.ID=ID;
			model.artID=artID;
			model.userID=userID;
			model.userName=userName;
			model.disDate=disDate;
			model.Contents=Contents;
			model.rootID=rootID;

			xiaoHOUSE.BLL.discuss bll=new xiaoHOUSE.BLL.discuss();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
