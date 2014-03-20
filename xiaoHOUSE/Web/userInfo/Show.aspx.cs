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
namespace xiaoHOUSE.Web.userInfo
{
    public partial class Show : Page
    {        
        		public string strid=""; 
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					strid = Request.Params["id"];
					int ID=(Convert.ToInt32(strid));
					ShowInfo(ID);
				}
			}
		}
		
	private void ShowInfo(int ID)
	{
		xiaoHOUSE.BLL.userInfo bll=new xiaoHOUSE.BLL.userInfo();
		xiaoHOUSE.Model.userInfo model=bll.GetModel(ID);
		this.lblID.Text=model.ID.ToString();
		this.lbluserName.Text=model.userName;
		this.lblnickName.Text=model.nickName;
		this.lbluserRoles.Text=model.userRoles.ToString();
		this.lblregisterDate.Text=model.registerDate.ToString();
		this.lblregisterIP.Text=model.registerIP;
		this.lbllastLoginDate.Text=model.lastLoginDate.ToString();
		this.lbllastLoginIP.Text=model.lastLoginIP;
		this.lblsex.Text=model.sex;
		this.lblEmail.Text=model.Email;
		this.lblage.Text=model.age.ToString();

	}


    }
}
