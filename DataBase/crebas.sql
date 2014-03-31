/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2008                    */
/* Created on:     2014/3/18 22:08:26                           */
/*==============================================================*/


if exists (select 1
            from  sysobjects
           where  id = object_id('articles')
            and   type = 'U')
   drop table articles
go

if exists (select 1
            from  sysobjects
           where  id = object_id('discuss')
            and   type = 'U')
   drop table discuss
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('userInfo')
            and   name  = 'uq_name'
            and   indid > 0
            and   indid < 255)
   drop index userInfo.uq_name
go

if exists (select 1
            from  sysobjects
           where  id = object_id('userInfo')
            and   type = 'U')
   drop table userInfo
go

/*==============================================================*/
/* Table: articles                                              */
/*==============================================================*/
create table articles (
   ID                   int                  identity(1,1),
   title                varchar(200)         not null,
   contents             text                 not null,
   isDiscuss            int                  null default 1,
   counts               int                  null default 0,
   artType              int                  not null,
   temp1                varchar(50)          null,
   constraint PK_ARTICLES primary key (ID)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'articles',
   'user', @CurrentUser, 'table', 'articles'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���',
   'user', @CurrentUser, 'table', 'articles', 'column', 'ID'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', @CurrentUser, 'table', 'articles', 'column', 'title'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', @CurrentUser, 'table', 'articles', 'column', 'contents'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��������',
   'user', @CurrentUser, 'table', 'articles', 'column', 'isDiscuss'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���ʴ���',
   'user', @CurrentUser, 'table', 'articles', 'column', 'counts'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', @CurrentUser, 'table', 'articles', 'column', 'artType'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'temp1',
   'user', @CurrentUser, 'table', 'articles', 'column', 'temp1'
go

/*==============================================================*/
/* Table: discuss                                               */
/*==============================================================*/
create table discuss (
   ID                   int                  identity(1,1),
   artID                int                  not null,
   userID               int                  null,
   userName             varchar(50)          null,
   disDate              datetime             null default getdate(),
   Contents             varchar(500)         not null,
   rootID               int                  null,
   constraint PK_DISCUSS primary key (ID)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'discuss',
   'user', @CurrentUser, 'table', 'discuss'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���',
   'user', @CurrentUser, 'table', 'discuss', 'column', 'ID'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���±��',
   'user', @CurrentUser, 'table', 'discuss', 'column', 'artID'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '������',
   'user', @CurrentUser, 'table', 'discuss', 'column', 'userID'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����������',
   'user', @CurrentUser, 'table', 'discuss', 'column', 'userName'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ʱ��',
   'user', @CurrentUser, 'table', 'discuss', 'column', 'disDate'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', @CurrentUser, 'table', 'discuss', 'column', 'Contents'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���۸����',
   'user', @CurrentUser, 'table', 'discuss', 'column', 'rootID'
go

/*==============================================================*/
/* Table: userInfo                                              */
/*==============================================================*/
create table userInfo (
   ID                   int                  identity(10001,1),
   userName             varchar(50)          not null,
   nickName             varchar(50)          null,
   userRoles            int                  null,
   registerDate         datetime             not null default getdate(),
   registerIP           varchar(15)          null,
   lastLoginDate        datetime             not null default getdate(),
   lastLoginIP          varchar(15)          null,
   sex                  char(2)              null,
   Email                varchar(50)          null,
   age                  int                  null,
   constraint PK_USERINFO primary key (ID)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'userInfo',
   'user', @CurrentUser, 'table', 'userInfo'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���',
   'user', @CurrentUser, 'table', 'userInfo', 'column', 'ID'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�û���',
   'user', @CurrentUser, 'table', 'userInfo', 'column', 'userName'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�ǳ�',
   'user', @CurrentUser, 'table', 'userInfo', 'column', 'nickName'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��ɫ',
   'user', @CurrentUser, 'table', 'userInfo', 'column', 'userRoles'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ע��ʱ��',
   'user', @CurrentUser, 'table', 'userInfo', 'column', 'registerDate'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ע��IP',
   'user', @CurrentUser, 'table', 'userInfo', 'column', 'registerIP'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����¼ʱ��',
   'user', @CurrentUser, 'table', 'userInfo', 'column', 'lastLoginDate'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����¼IP',
   'user', @CurrentUser, 'table', 'userInfo', 'column', 'lastLoginIP'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�Ա�',
   'user', @CurrentUser, 'table', 'userInfo', 'column', 'sex'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', @CurrentUser, 'table', 'userInfo', 'column', 'Email'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', @CurrentUser, 'table', 'userInfo', 'column', 'age'
go

/*==============================================================*/
/* Index: uq_name                                               */
/*==============================================================*/
create unique index uq_name on userInfo (
userName ASC
)
go


GO

/****** Object:  Table [dbo].[artType]    Script Date: 03/29/2014 21:22:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[artType](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[typeName] [varchar](50) NOT NULL,
	[typeFather] [int] NOT NULL,
	[description] [varchar](150) NULL,
 CONSTRAINT [PK_artType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UQ_typeName] UNIQUE NONCLUSTERED 
(
	[typeName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO