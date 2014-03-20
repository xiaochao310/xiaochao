using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace xiaoHOUSE.DAL
{
	/// <summary>
	/// 数据访问类:userInfo
	/// </summary>
	public partial class userInfo
	{
		public userInfo()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "userInfo"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string userName,int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from userInfo");
			strSql.Append(" where userName=@userName and ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@userName", SqlDbType.VarChar,50),
					new SqlParameter("@ID", SqlDbType.Int,4)			};
			parameters[0].Value = userName;
			parameters[1].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(xiaoHOUSE.Model.userInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into userInfo(");
			strSql.Append("userName,nickName,userRoles,registerDate,registerIP,lastLoginDate,lastLoginIP,sex,Email,age)");
			strSql.Append(" values (");
			strSql.Append("@userName,@nickName,@userRoles,@registerDate,@registerIP,@lastLoginDate,@lastLoginIP,@sex,@Email,@age)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@userName", SqlDbType.VarChar,50),
					new SqlParameter("@nickName", SqlDbType.VarChar,50),
					new SqlParameter("@userRoles", SqlDbType.Int,4),
					new SqlParameter("@registerDate", SqlDbType.DateTime),
					new SqlParameter("@registerIP", SqlDbType.VarChar,15),
					new SqlParameter("@lastLoginDate", SqlDbType.DateTime),
					new SqlParameter("@lastLoginIP", SqlDbType.VarChar,15),
					new SqlParameter("@sex", SqlDbType.Char,2),
					new SqlParameter("@Email", SqlDbType.VarChar,50),
					new SqlParameter("@age", SqlDbType.Int,4)};
			parameters[0].Value = model.userName;
			parameters[1].Value = model.nickName;
			parameters[2].Value = model.userRoles;
			parameters[3].Value = model.registerDate;
			parameters[4].Value = model.registerIP;
			parameters[5].Value = model.lastLoginDate;
			parameters[6].Value = model.lastLoginIP;
			parameters[7].Value = model.sex;
			parameters[8].Value = model.Email;
			parameters[9].Value = model.age;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(xiaoHOUSE.Model.userInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update userInfo set ");
			strSql.Append("nickName=@nickName,");
			strSql.Append("userRoles=@userRoles,");
			strSql.Append("registerDate=@registerDate,");
			strSql.Append("registerIP=@registerIP,");
			strSql.Append("lastLoginDate=@lastLoginDate,");
			strSql.Append("lastLoginIP=@lastLoginIP,");
			strSql.Append("sex=@sex,");
			strSql.Append("Email=@Email,");
			strSql.Append("age=@age");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@nickName", SqlDbType.VarChar,50),
					new SqlParameter("@userRoles", SqlDbType.Int,4),
					new SqlParameter("@registerDate", SqlDbType.DateTime),
					new SqlParameter("@registerIP", SqlDbType.VarChar,15),
					new SqlParameter("@lastLoginDate", SqlDbType.DateTime),
					new SqlParameter("@lastLoginIP", SqlDbType.VarChar,15),
					new SqlParameter("@sex", SqlDbType.Char,2),
					new SqlParameter("@Email", SqlDbType.VarChar,50),
					new SqlParameter("@age", SqlDbType.Int,4),
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@userName", SqlDbType.VarChar,50)};
			parameters[0].Value = model.nickName;
			parameters[1].Value = model.userRoles;
			parameters[2].Value = model.registerDate;
			parameters[3].Value = model.registerIP;
			parameters[4].Value = model.lastLoginDate;
			parameters[5].Value = model.lastLoginIP;
			parameters[6].Value = model.sex;
			parameters[7].Value = model.Email;
			parameters[8].Value = model.age;
			parameters[9].Value = model.ID;
			parameters[10].Value = model.userName;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from userInfo ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string userName,int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from userInfo ");
			strSql.Append(" where userName=@userName and ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@userName", SqlDbType.VarChar,50),
					new SqlParameter("@ID", SqlDbType.Int,4)			};
			parameters[0].Value = userName;
			parameters[1].Value = ID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from userInfo ");
			strSql.Append(" where ID in ("+IDlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public xiaoHOUSE.Model.userInfo GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,userName,nickName,userRoles,registerDate,registerIP,lastLoginDate,lastLoginIP,sex,Email,age from userInfo ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			xiaoHOUSE.Model.userInfo model=new xiaoHOUSE.Model.userInfo();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public xiaoHOUSE.Model.userInfo DataRowToModel(DataRow row)
		{
			xiaoHOUSE.Model.userInfo model=new xiaoHOUSE.Model.userInfo();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["userName"]!=null)
				{
					model.userName=row["userName"].ToString();
				}
				if(row["nickName"]!=null)
				{
					model.nickName=row["nickName"].ToString();
				}
				if(row["userRoles"]!=null && row["userRoles"].ToString()!="")
				{
					model.userRoles=int.Parse(row["userRoles"].ToString());
				}
				if(row["registerDate"]!=null && row["registerDate"].ToString()!="")
				{
					model.registerDate=DateTime.Parse(row["registerDate"].ToString());
				}
				if(row["registerIP"]!=null)
				{
					model.registerIP=row["registerIP"].ToString();
				}
				if(row["lastLoginDate"]!=null && row["lastLoginDate"].ToString()!="")
				{
					model.lastLoginDate=DateTime.Parse(row["lastLoginDate"].ToString());
				}
				if(row["lastLoginIP"]!=null)
				{
					model.lastLoginIP=row["lastLoginIP"].ToString();
				}
				if(row["sex"]!=null)
				{
					model.sex=row["sex"].ToString();
				}
				if(row["Email"]!=null)
				{
					model.Email=row["Email"].ToString();
				}
				if(row["age"]!=null && row["age"].ToString()!="")
				{
					model.age=int.Parse(row["age"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,userName,nickName,userRoles,registerDate,registerIP,lastLoginDate,lastLoginIP,sex,Email,age ");
			strSql.Append(" FROM userInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" ID,userName,nickName,userRoles,registerDate,registerIP,lastLoginDate,lastLoginIP,sex,Email,age ");
			strSql.Append(" FROM userInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM userInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.ID desc");
			}
			strSql.Append(")AS Row, T.*  from userInfo T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "userInfo";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

