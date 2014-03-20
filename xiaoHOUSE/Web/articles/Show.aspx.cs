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
namespace xiaoHOUSE.Web.articles
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
		xiaoHOUSE.BLL.articles bll=new xiaoHOUSE.BLL.articles();
		xiaoHOUSE.Model.articles model=bll.GetModel(ID);
		this.lblID.Text=model.ID.ToString();
		this.lbltitle.Text=model.title;
		this.lblcontents.Text=model.contents;
		this.lblisDiscuss.Text=model.isDiscuss.ToString();
		this.lblcounts.Text=model.counts.ToString();
		this.lblartType.Text=model.artType.ToString();
		this.lbltemp1.Text=model.temp1;

	}


    }
}
