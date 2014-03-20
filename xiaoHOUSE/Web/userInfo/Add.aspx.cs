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
namespace xiaoHOUSE.Web.userInfo
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtuserName.Text.Trim().Length==0)
			{
				strErr+="用户名不能为空！\\n";	
			}
			if(this.txtnickName.Text.Trim().Length==0)
			{
				strErr+="昵称不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtuserRoles.Text))
			{
				strErr+="角色格式错误！\\n";	
			}
			if(!PageValidate.IsDateTime(txtregisterDate.Text))
			{
				strErr+="注册时间格式错误！\\n";	
			}
			if(this.txtregisterIP.Text.Trim().Length==0)
			{
				strErr+="注册IP不能为空！\\n";	
			}
			if(!PageValidate.IsDateTime(txtlastLoginDate.Text))
			{
				strErr+="最后登录时间格式错误！\\n";	
			}
			if(this.txtlastLoginIP.Text.Trim().Length==0)
			{
				strErr+="最后登录IP不能为空！\\n";	
			}
			if(this.txtsex.Text.Trim().Length==0)
			{
				strErr+="性别不能为空！\\n";	
			}
			if(this.txtEmail.Text.Trim().Length==0)
			{
				strErr+="邮箱不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtage.Text))
			{
				strErr+="年龄格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			string userName=this.txtuserName.Text;
			string nickName=this.txtnickName.Text;
			int userRoles=int.Parse(this.txtuserRoles.Text);
			DateTime registerDate=DateTime.Parse(this.txtregisterDate.Text);
			string registerIP=this.txtregisterIP.Text;
			DateTime lastLoginDate=DateTime.Parse(this.txtlastLoginDate.Text);
			string lastLoginIP=this.txtlastLoginIP.Text;
			string sex=this.txtsex.Text;
			string Email=this.txtEmail.Text;
			int age=int.Parse(this.txtage.Text);

			xiaoHOUSE.Model.userInfo model=new xiaoHOUSE.Model.userInfo();
			model.userName=userName;
			model.nickName=nickName;
			model.userRoles=userRoles;
			model.registerDate=registerDate;
			model.registerIP=registerIP;
			model.lastLoginDate=lastLoginDate;
			model.lastLoginIP=lastLoginIP;
			model.sex=sex;
			model.Email=Email;
			model.age=age;

			xiaoHOUSE.BLL.userInfo bll=new xiaoHOUSE.BLL.userInfo();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
