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
namespace xiaoHOUSE.Web.articles
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txttitle.Text.Trim().Length==0)
			{
				strErr+="标题不能为空！\\n";	
			}
			if(this.txtcontents.Text.Trim().Length==0)
			{
				strErr+="内容不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtisDiscuss.Text))
			{
				strErr+="允许评论格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtcounts.Text))
			{
				strErr+="访问次数格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtartType.Text))
			{
				strErr+="类型格式错误！\\n";	
			}
			if(this.txttemp1.Text.Trim().Length==0)
			{
				strErr+="temp1不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			string title=this.txttitle.Text;
			string contents=this.txtcontents.Text;
			int isDiscuss=int.Parse(this.txtisDiscuss.Text);
			int counts=int.Parse(this.txtcounts.Text);
			int artType=int.Parse(this.txtartType.Text);
			string temp1=this.txttemp1.Text;

			xiaoHOUSE.Model.articles model=new xiaoHOUSE.Model.articles();
			model.title=title;
			model.contents=contents;
			model.isDiscuss=isDiscuss;
			model.counts=counts;
			model.artType=artType;
			model.temp1=temp1;

			xiaoHOUSE.BLL.articles bll=new xiaoHOUSE.BLL.articles();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
