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
namespace xiaoHOUSE.Web.discuss
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
		xiaoHOUSE.BLL.discuss bll=new xiaoHOUSE.BLL.discuss();
		xiaoHOUSE.Model.discuss model=bll.GetModel(ID);
		this.lblID.Text=model.ID.ToString();
		this.lblartID.Text=model.artID.ToString();
		this.lbluserID.Text=model.userID.ToString();
		this.lbluserName.Text=model.userName;
		this.lbldisDate.Text=model.disDate.ToString();
		this.lblContents.Text=model.Contents;
		this.lblrootID.Text=model.rootID.ToString();

	}


    }
}
