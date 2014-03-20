using System;
namespace xiaoHOUSE.Model
{
	/// <summary>
	/// discuss
	/// </summary>
	[Serializable]
	public partial class discuss
	{
		public discuss()
		{}
		#region Model
		private int _id;
		private int _artid;
		private int? _userid;
		private string _username;
		private DateTime? _disdate= DateTime.Now;
		private string _contents;
		private int? _rootid;
		/// <summary>
		/// 编号
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 文章编号
		/// </summary>
		public int artID
		{
			set{ _artid=value;}
			get{return _artid;}
		}
		/// <summary>
		/// 评论人
		/// </summary>
		public int? userID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 评论人名称
		/// </summary>
		public string userName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 评论时间
		/// </summary>
		public DateTime? disDate
		{
			set{ _disdate=value;}
			get{return _disdate;}
		}
		/// <summary>
		/// 内容
		/// </summary>
		public string Contents
		{
			set{ _contents=value;}
			get{return _contents;}
		}
		/// <summary>
		/// 评论父编号
		/// </summary>
		public int? rootID
		{
			set{ _rootid=value;}
			get{return _rootid;}
		}
		#endregion Model

	}
}

