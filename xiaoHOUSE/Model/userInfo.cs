using System;
namespace xiaoHOUSE.Model
{
	/// <summary>
	/// userInfo
	/// </summary>
	[Serializable]
	public partial class userInfo
	{
		public userInfo()
		{}
		#region Model
		private int _id;
		private string _username;
		private string _nickname;
		private int? _userroles;
		private DateTime _registerdate= DateTime.Now;
		private string _registerip;
		private DateTime _lastlogindate= DateTime.Now;
		private string _lastloginip;
		private string _sex;
		private string _email;
		private int? _age;
		/// <summary>
		/// 编号
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 用户名
		/// </summary>
		public string userName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 昵称
		/// </summary>
		public string nickName
		{
			set{ _nickname=value;}
			get{return _nickname;}
		}
		/// <summary>
		/// 角色
		/// </summary>
		public int? userRoles
		{
			set{ _userroles=value;}
			get{return _userroles;}
		}
		/// <summary>
		/// 注册时间
		/// </summary>
		public DateTime registerDate
		{
			set{ _registerdate=value;}
			get{return _registerdate;}
		}
		/// <summary>
		/// 注册IP
		/// </summary>
		public string registerIP
		{
			set{ _registerip=value;}
			get{return _registerip;}
		}
		/// <summary>
		/// 最后登录时间
		/// </summary>
		public DateTime lastLoginDate
		{
			set{ _lastlogindate=value;}
			get{return _lastlogindate;}
		}
		/// <summary>
		/// 最后登录IP
		/// </summary>
		public string lastLoginIP
		{
			set{ _lastloginip=value;}
			get{return _lastloginip;}
		}
		/// <summary>
		/// 性别
		/// </summary>
		public string sex
		{
			set{ _sex=value;}
			get{return _sex;}
		}
		/// <summary>
		/// 邮箱
		/// </summary>
		public string Email
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
		/// 年龄
		/// </summary>
		public int? age
		{
			set{ _age=value;}
			get{return _age;}
		}
		#endregion Model

	}
}

