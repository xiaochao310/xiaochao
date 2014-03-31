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
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace xiaoHOUSE.DAL
{
	/// <summary>
	/// 数据访问类:articles
	/// </summary>
	public partial class articles
	{
		public articles()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "articles"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from articles");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(xiaoHOUSE.Model.articles model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into articles(");
			strSql.Append("title,contents,isDiscuss,counts,artType,temp1,artDatetime)");
			strSql.Append(" values (");
			strSql.Append("@title,@contents,@isDiscuss,@counts,@artType,@temp1,@artDatetime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.VarChar,200),
					new SqlParameter("@contents", SqlDbType.Text),
					new SqlParameter("@isDiscuss", SqlDbType.Int,4),
					new SqlParameter("@counts", SqlDbType.Int,4),
					new SqlParameter("@artType", SqlDbType.Int,4),
					new SqlParameter("@temp1", SqlDbType.VarChar,50),
					new SqlParameter("@artDatetime", SqlDbType.DateTime)};
			parameters[0].Value = model.title;
			parameters[1].Value = model.contents;
			parameters[2].Value = model.isDiscuss;
			parameters[3].Value = model.counts;
			parameters[4].Value = model.artType;
			parameters[5].Value = model.temp1;
			parameters[6].Value = model.artDatetime;

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
		public bool Update(xiaoHOUSE.Model.articles model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update articles set ");
			strSql.Append("title=@title,");
			strSql.Append("contents=@contents,");
			strSql.Append("isDiscuss=@isDiscuss,");
			strSql.Append("counts=@counts,");
			strSql.Append("artType=@artType,");
			strSql.Append("temp1=@temp1,");
			strSql.Append("artDatetime=@artDatetime");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.VarChar,200),
					new SqlParameter("@contents", SqlDbType.Text),
					new SqlParameter("@isDiscuss", SqlDbType.Int,4),
					new SqlParameter("@counts", SqlDbType.Int,4),
					new SqlParameter("@artType", SqlDbType.Int,4),
					new SqlParameter("@temp1", SqlDbType.VarChar,50),
					new SqlParameter("@artDatetime", SqlDbType.DateTime),
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = model.title;
			parameters[1].Value = model.contents;
			parameters[2].Value = model.isDiscuss;
			parameters[3].Value = model.counts;
			parameters[4].Value = model.artType;
			parameters[5].Value = model.temp1;
			parameters[6].Value = model.artDatetime;
			parameters[7].Value = model.ID;

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
			strSql.Append("delete from articles ");
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
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from articles ");
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
		public xiaoHOUSE.Model.articles GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,title,contents,isDiscuss,counts,artType,temp1,artDatetime from articles ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			xiaoHOUSE.Model.articles model=new xiaoHOUSE.Model.articles();
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
		public xiaoHOUSE.Model.articles DataRowToModel(DataRow row)
		{
			xiaoHOUSE.Model.articles model=new xiaoHOUSE.Model.articles();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["title"]!=null)
				{
					model.title=row["title"].ToString();
				}
				if(row["contents"]!=null)
				{
					model.contents=row["contents"].ToString();
				}
				if(row["isDiscuss"]!=null && row["isDiscuss"].ToString()!="")
				{
					model.isDiscuss=int.Parse(row["isDiscuss"].ToString());
				}
				if(row["counts"]!=null && row["counts"].ToString()!="")
				{
					model.counts=int.Parse(row["counts"].ToString());
				}
				if(row["artType"]!=null && row["artType"].ToString()!="")
				{
					model.artType=int.Parse(row["artType"].ToString());
				}
				if(row["temp1"]!=null)
				{
					model.temp1=row["temp1"].ToString();
				}
				if(row["artDatetime"]!=null && row["artDatetime"].ToString()!="")
				{
					model.artDatetime=DateTime.Parse(row["artDatetime"].ToString());
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
			strSql.Append("select ID,title,contents,isDiscuss,counts,artType,temp1,artDatetime ");
			strSql.Append(" FROM articles ");
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
			strSql.Append(" ID,title,contents,isDiscuss,counts,artType,temp1,artDatetime ");
			strSql.Append(" FROM articles ");
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
			strSql.Append("select count(1) FROM articles ");
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
			strSql.Append(")AS Row, T.*  from articles T ");
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
			parameters[0].Value = "articles";
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

