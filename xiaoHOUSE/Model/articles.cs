/**  版本信息模板在安装目录下，可自行修改。
* articles.cs
*
* 功 能： N/A
* 类 名： articles
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/3/30 17:10:29   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace xiaoHOUSE.Model
{
	/// <summary>
	/// articles
	/// </summary>
	[Serializable]
	public partial class articles
	{
		public articles()
		{}
		#region Model
		private int _id;
		private string _title;
		private string _contents;
		private int? _isdiscuss=1;
		private int? _counts=0;
		private int _arttype;
		private string _temp1;
		private DateTime _artdatetime= DateTime.Now;
		/// <summary>
		/// 编号
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 标题
		/// </summary>
		public string title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 内容
		/// </summary>
		public string contents
		{
			set{ _contents=value;}
			get{return _contents;}
		}
		/// <summary>
		/// 允许评论
		/// </summary>
		public int? isDiscuss
		{
			set{ _isdiscuss=value;}
			get{return _isdiscuss;}
		}
		/// <summary>
		/// 访问次数
		/// </summary>
		public int? counts
		{
			set{ _counts=value;}
			get{return _counts;}
		}
		/// <summary>
		/// 类型
		/// </summary>
		public int artType
		{
			set{ _arttype=value;}
			get{return _arttype;}
		}
		/// <summary>
		/// temp1
		/// </summary>
		public string temp1
		{
			set{ _temp1=value;}
			get{return _temp1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime artDatetime
		{
			set{ _artdatetime=value;}
			get{return _artdatetime;}
		}
		#endregion Model

	}
}

