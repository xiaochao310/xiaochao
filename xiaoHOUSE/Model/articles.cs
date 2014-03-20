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
		#endregion Model

	}
}

