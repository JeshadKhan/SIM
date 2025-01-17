USE [master]
GO
/****** Object:  Database [SIMDB]    Script Date: 24-Jan-17 11:51:19 AM ******/
CREATE DATABASE [SIMDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SIMDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS2012\MSSQL\DATA\SIMDB.mdf' , SIZE = 51200KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'SIMDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS2012\MSSQL\DATA\SIMDB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [SIMDB] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SIMDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SIMDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SIMDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SIMDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SIMDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SIMDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [SIMDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SIMDB] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [SIMDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SIMDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SIMDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SIMDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SIMDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SIMDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SIMDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SIMDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SIMDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SIMDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SIMDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SIMDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SIMDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SIMDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SIMDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SIMDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SIMDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [SIMDB] SET  MULTI_USER 
GO
ALTER DATABASE [SIMDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SIMDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SIMDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SIMDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [SIMDB]
GO
/****** Object:  StoredProcedure [dbo].[INSERT_COURSE]    Script Date: 24-Jan-17 11:51:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


/*
 * Author               : Quaint Park
 * Copyright            : © 2017 Quaint Park.
 * Official Website     : www.quaintpark.com
 * ------------------------------------------------------------------------------
 * Developed By         : Jeshad Khan
 * Profile              : www.jeshadkhan.com
 * ------------------------------------------------------------------------------
 * Title                : Simple Institute Management (SIM)
 * Version              : 1.0
 * License              : Licensed under MIT <http://opensource.org/licenses/MIT>
*/


CREATE PROC [dbo].[INSERT_COURSE]
(
	@Code nvarchar(10)
	,@Name nvarchar(100)
	,@Credit float
	,@Description nvarchar(MAX)
	,@DepartmentId int
	,@SemesterId int
)
AS
INSERT INTO Courses(Code, Name, Credit, Description, DepartmentId, SemesterId) VALUES(@Code, @Name, @Credit, @Description, @DepartmentId, @SemesterId)


GO
/****** Object:  StoredProcedure [dbo].[REPORT_STUDENT_RESULT]    Script Date: 24-Jan-17 11:51:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


/*
 * Author               : Quaint Park
 * Copyright            : © 2017 Quaint Park.
 * Official Website     : www.quaintpark.com
 * ------------------------------------------------------------------------------
 * Developed By         : Jeshad Khan
 * Profile              : www.jeshadkhan.com
 * ------------------------------------------------------------------------------
 * Title                : Simple Institute Management (SIM)
 * Version              : 1.0
 * License              : Licensed under MIT <http://opensource.org/licenses/MIT>
*/


CREATE PROC [dbo].[REPORT_STUDENT_RESULT]
(
	@ID int
)
AS
SELECT
	*
FROM
	StudentCourseView
WHERE
	Id = @ID


GO
/****** Object:  Table [dbo].[AllocateClassrooms]    Script Date: 24-Jan-17 11:51:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AllocateClassrooms](
	[DepartmentId] [int] NOT NULL,
	[CourseId] [int] NOT NULL,
	[RoomNo] [nvarchar](50) NOT NULL,
	[Day] [nvarchar](20) NOT NULL,
	[FromTime] [nvarchar](20) NOT NULL,
	[ToTime] [nvarchar](20) NOT NULL,
	[StartTime] [time](7) NULL,
	[EndTime] [time](7) NULL,
	[Duration] [time](7) NULL,
	[AllocationDate] [datetime] NULL,
	[Status] [bit] NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Courses]    Script Date: 24-Jan-17 11:51:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Courses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](10) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Credit] [float] NOT NULL,
	[Description] [nvarchar](max) NULL,
	[DepartmentId] [int] NOT NULL,
	[SemesterId] [int] NOT NULL,
 CONSTRAINT [PK_Courses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CourseTeacher]    Script Date: 24-Jan-17 11:51:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CourseTeacher](
	[DepartmentId] [int] NOT NULL,
	[TeacherId] [int] NOT NULL,
	[CourseId] [int] NOT NULL,
	[Status] [bit] NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Departments]    Script Date: 24-Jan-17 11:51:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Departments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](20) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Departments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Designations]    Script Date: 24-Jan-17 11:51:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Designations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Designations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[GradePoint]    Script Date: 24-Jan-17 11:51:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GradePoint](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Grade] [nvarchar](3) NOT NULL,
	[Point] [float] NOT NULL,
 CONSTRAINT [PK_GradePoint] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RoomNo]    Script Date: 24-Jan-17 11:51:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RoomNo](
	[RoomNo] [varchar](20) NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Semesters]    Script Date: 24-Jan-17 11:51:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Semesters](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Semesters] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Settings]    Script Date: 24-Jan-17 11:51:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Settings](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[InstituteFullName] [nvarchar](50) NOT NULL,
	[InstituteShortName] [nvarchar](10) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[MobileNumber] [nvarchar](20) NULL,
	[PhoneNumber] [nvarchar](20) NULL,
	[Website] [nvarchar](50) NULL,
	[GoogleMap] [nvarchar](500) NULL,
	[BrandLogo] [nvarchar](50) NULL,
	[BrandFavicon] [nvarchar](50) NULL,
	[FacebookLink] [nvarchar](100) NULL,
	[GooglePlusLink] [nvarchar](100) NULL,
	[TwitterLink] [nvarchar](100) NULL,
	[YoutTubeLink] [nvarchar](100) NULL,
	[LinkedInLink] [nvarchar](100) NULL,
	[GitHubLink] [nvarchar](100) NULL,
	[AboutUs] [nvarchar](max) NULL,
	[Location] [nvarchar](200) NULL,
	[BrandDescription] [nvarchar](max) NULL,
 CONSTRAINT [PK_Settings] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SliderImages]    Script Date: 24-Jan-17 11:51:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SliderImages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[Images] [nvarchar](200) NOT NULL,
	[Title] [nvarchar](100) NULL,
	[Description] [nvarchar](150) NULL,
 CONSTRAINT [PK_SliderImages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StudentEnrollCourse]    Script Date: 24-Jan-17 11:51:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentEnrollCourse](
	[StudentId] [int] NOT NULL,
	[CourseId] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
	[Status] [bit] NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_StudentEnrollCourse] PRIMARY KEY CLUSTERED 
(
	[StudentId] ASC,
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StudentResults]    Script Date: 24-Jan-17 11:51:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[StudentResults](
	[StudentId] [int] NOT NULL,
	[CourseId] [int] NOT NULL,
	[Grade] [varchar](5) NOT NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_StudentResults] PRIMARY KEY CLUSTERED 
(
	[StudentId] ASC,
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Students]    Script Date: 24-Jan-17 11:51:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Students](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RegNo] [varchar](15) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[ContactNo] [varchar](15) NOT NULL,
	[Date] [datetime] NOT NULL,
	[Address] [varchar](200) NULL,
	[DepartmentId] [int] NOT NULL,
 CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Teachers]    Script Date: 24-Jan-17 11:51:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Teachers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Address] [varchar](max) NULL,
	[Email] [varchar](50) NOT NULL,
	[ContactNo] [varchar](15) NOT NULL,
	[DesignationId] [int] NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[CreditToBeTaken] [int] NOT NULL,
	[RemainingCredit] [int] NULL,
 CONSTRAINT [PK_Teachers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Users]    Script Date: 24-Jan-17 11:51:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](300) NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  View [dbo].[AllocateClassroomAndCourseView]    Script Date: 24-Jan-17 11:51:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


/*
 * Author               : Quaint Park
 * Copyright            : © 2017 Quaint Park.
 * Official Website     : www.quaintpark.com
 * ------------------------------------------------------------------------------
 * Developed By         : Jeshad Khan
 * Profile              : www.jeshadkhan.com
 * ------------------------------------------------------------------------------
 * Title                : Simple Institute Management (SIM)
 * Version              : 1.0
 * License              : Licensed under MIT <http://opensource.org/licenses/MIT>
*/


CREATE VIEW [dbo].[AllocateClassroomAndCourseView]
AS
SELECT
	c.DepartmentId
	,c.Code AS CourseCode
	,c.Name AS CourseName
	,ac.RoomNo
	,ac.Day
	,ac.FromTime
	,ac.ToTime
	,ac.Status as ACStatus
FROM
	AllocateClassrooms AS ac
	RIGHT JOIN Courses AS c
	ON ac.CourseId = c.Id







GO
/****** Object:  View [dbo].[AllocateClassroomListView]    Script Date: 24-Jan-17 11:51:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


/*
 * Author               : Quaint Park
 * Copyright            : © 2017 Quaint Park.
 * Official Website     : www.quaintpark.com
 * ------------------------------------------------------------------------------
 * Developed By         : Jeshad Khan
 * Profile              : www.jeshadkhan.com
 * ------------------------------------------------------------------------------
 * Title                : Simple Institute Management (SIM)
 * Version              : 1.0
 * License              : Licensed under MIT <http://opensource.org/licenses/MIT>
*/


CREATE VIEW [dbo].[AllocateClassroomListView]
AS
SELECT
	ac.Id
	,ac.RoomNo
	,ac.Day
	,ac.FromTime
	,ac.ToTime
	,ac.Duration
	,ac.Status
	,ac.AllocationDate
	,ac.CourseId
	,c.Code AS CourseCode
	,c.Name AS CourseName
	,ac.DepartmentId
	,d.Name AS DepartmentName
FROM
	AllocateClassrooms AS ac
	LEFT JOIN Departments AS d
	ON ac.DepartmentId = d.Id
	LEFT JOIN Courses AS c
	ON ac.CourseId = c.Id




GO
/****** Object:  View [dbo].[CourseTeacherDepartmentView]    Script Date: 24-Jan-17 11:51:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


/*
 * Author               : Quaint Park
 * Copyright            : © 2017 Quaint Park.
 * Official Website     : www.quaintpark.com
 * ------------------------------------------------------------------------------
 * Developed By         : Jeshad Khan
 * Profile              : www.jeshadkhan.com
 * ------------------------------------------------------------------------------
 * Title                : Simple Institute Management (SIM)
 * Version              : 1.0
 * License              : Licensed under MIT <http://opensource.org/licenses/MIT>
*/


CREATE VIEW [dbo].[CourseTeacherDepartmentView]
AS
SELECT
	ct.Id
	,ct.CourseId
	,c.Code AS CourseCode
	,c.Name AS CourseName
	,c.Credit AS CourseCredit
	,ct.TeacherId
	,t.Name AS TeacherName
	,t.CreditToBeTaken AS TeacherCreditToBeTaken
	,t.RemainingCredit AS TeacherRemainingCredit
	,d.Name AS TeacherDesignation
	,dept.Id AS DepartmentId
	,dept.Name AS DepartmentName
	,ct.Status
FROM
	CourseTeacher AS ct
	LEFT JOIN Courses AS c
	ON ct.CourseId = c.Id

	LEFT JOIN Teachers AS t
	ON ct.TeacherId = t.Id

	LEFT JOIN Designations AS d
	ON t.DesignationId = d.Id

	LEFT JOIN Departments AS dept
	ON ct.DepartmentId = dept.Id








GO
/****** Object:  View [dbo].[CourseTeacherSemestersView]    Script Date: 24-Jan-17 11:51:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


/*
 * Author               : Quaint Park
 * Copyright            : © 2017 Quaint Park.
 * Official Website     : www.quaintpark.com
 * ------------------------------------------------------------------------------
 * Developed By         : Jeshad Khan
 * Profile              : www.jeshadkhan.com
 * ------------------------------------------------------------------------------
 * Title                : Simple Institute Management (SIM)
 * Version              : 1.0
 * License              : Licensed under MIT <http://opensource.org/licenses/MIT>
*/


CREATE VIEW [dbo].[CourseTeacherSemestersView]
AS
SELECT
	c.Code
	,c.Name
	,s.Name AS SemesterName
	,t.Name AS AssignTeacherName
	,c.DepartmentId
	,ct.Status
FROM
	CourseTeacher AS ct
	RIGHT JOIN Courses AS c
	ON ct.CourseId = c.Id
	LEFT JOIN Semesters AS s
	ON c.SemesterId = s.Id
	LEFT JOIN Teachers AS t
	ON ct.TeacherId = t.Id



GO
/****** Object:  View [dbo].[StudentCourseView]    Script Date: 24-Jan-17 11:51:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


/*
 * Author               : Quaint Park
 * Copyright            : © 2017 Quaint Park.
 * Official Website     : www.quaintpark.com
 * ------------------------------------------------------------------------------
 * Developed By         : Jeshad Khan
 * Profile              : www.jeshadkhan.com
 * ------------------------------------------------------------------------------
 * Title                : Simple Institute Management (SIM)
 * Version              : 1.0
 * License              : Licensed under MIT <http://opensource.org/licenses/MIT>
*/


CREATE VIEW [dbo].[StudentCourseView]
AS
SELECT
	s.Id
	,s.RegNo
	,s.Name
	,s.Email
	,d.Name AS DepartmentName
	,c.Id AS CourseId
	,c.Name AS CourseName
	,c.Code AS CourseCode
	,sr.Grade
	,gp.Point
	,sec.Status
FROM
	StudentEnrollCourse AS sec
	RIGHT JOIN Students AS s
	ON sec.StudentId = s.Id
	LEFT JOIN Departments AS d
	ON s.DepartmentId = d.Id
	
	LEFT JOIN Courses AS c
	ON sec.CourseId = c.Id
	LEFT JOIN StudentResults AS sr
	ON sr.StudentId = sec.StudentId
	
	LEFT JOIN GradePoint AS gp
	ON gp.Grade = sr.Grade




GO
/****** Object:  View [dbo].[StudentDepartmentCourseResultView]    Script Date: 24-Jan-17 11:51:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


/*
 * Author               : Quaint Park
 * Copyright            : © 2017 Quaint Park.
 * Official Website     : www.quaintpark.com
 * ------------------------------------------------------------------------------
 * Developed By         : Jeshad Khan
 * Profile              : www.jeshadkhan.com
 * ------------------------------------------------------------------------------
 * Title                : Simple Institute Management (SIM)
 * Version              : 1.0
 * License              : Licensed under MIT <http://opensource.org/licenses/MIT>
*/


CREATE VIEW [dbo].[StudentDepartmentCourseResultView]
AS
SELECT
	sr.Id
	,sr.StudentId
	,s.RegNo
	,s.Name
	,s.Email
	,dept.Id AS DepartmentId
	,dept.Name AS DepartmentName
	,sr.CourseId
	,c.Code AS CourseCode
	,c.Name AS CourseName
	,sr.Grade
FROM
	Students AS s
	LEFT JOIN Departments AS dept
	ON s.DepartmentId = dept.Id
	
	RIGHT JOIN StudentResults AS sr
	ON s.Id = sr.StudentId
	
	LEFT JOIN Courses AS c
	ON sr.CourseId = c.Id






GO
/****** Object:  View [dbo].[StudentDepartmentView]    Script Date: 24-Jan-17 11:51:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


/*
 * Author               : Quaint Park
 * Copyright            : © 2017 Quaint Park.
 * Official Website     : www.quaintpark.com
 * ------------------------------------------------------------------------------
 * Developed By         : Jeshad Khan
 * Profile              : www.jeshadkhan.com
 * ------------------------------------------------------------------------------
 * Title                : Simple Institute Management (SIM)
 * Version              : 1.0
 * License              : Licensed under MIT <http://opensource.org/licenses/MIT>
*/


CREATE VIEW [dbo].[StudentDepartmentView]
AS
SELECT
	s.Id
	,s.RegNo
	,s.Name
	,s.Email
	,dept.Id AS DepartmentId
	,dept.Name AS DepartmentName
FROM
	Students AS s
	LEFT JOIN Departments AS dept
	ON s.DepartmentId = dept.Id




GO
/****** Object:  View [dbo].[StudentEnrollCourseView]    Script Date: 24-Jan-17 11:51:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


/*
 * Author               : Quaint Park
 * Copyright            : © 2017 Quaint Park.
 * Official Website     : www.quaintpark.com
 * ------------------------------------------------------------------------------
 * Developed By         : Jeshad Khan
 * Profile              : www.jeshadkhan.com
 * ------------------------------------------------------------------------------
 * Title                : Simple Institute Management (SIM)
 * Version              : 1.0
 * License              : Licensed under MIT <http://opensource.org/licenses/MIT>
*/


CREATE VIEW [dbo].[StudentEnrollCourseView]
AS
SELECT
	sec.Id
	,s.Id AS StudentId
	,s.RegNo
	,s.Name
	,s.Email
	,d.Id AS DepartmentId
	,d.Name AS DepartmentName
	,c.Id AS CourseId
	,c.Name AS CourseName
	,c.Code AS CourseCode
	,sec.Date
	,sec.Status
FROM
	StudentEnrollCourse AS sec
	LEFT JOIN Students AS s
	ON sec.StudentId = s.Id
	LEFT JOIN Departments AS d
	ON s.DepartmentId = d.Id
	
	LEFT JOIN Courses AS c
	ON sec.CourseId = c.Id









GO
/****** Object:  View [dbo].[TeacherDesignationDepartmentView]    Script Date: 24-Jan-17 11:51:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


/*
 * Author               : Quaint Park
 * Copyright            : © 2017 Quaint Park.
 * Official Website     : www.quaintpark.com
 * ------------------------------------------------------------------------------
 * Developed By         : Jeshad Khan
 * Profile              : www.jeshadkhan.com
 * ------------------------------------------------------------------------------
 * Title                : Simple Institute Management (SIM)
 * Version              : 1.0
 * License              : Licensed under MIT <http://opensource.org/licenses/MIT>
*/


CREATE VIEW [dbo].[TeacherDesignationDepartmentView]
AS
SELECT
	t.Id
	,t.Name
	,t.Address
	,t.Email
	,t.ContactNo
	,d.Id AS DesignationId
	,d.Name AS DesignationName
	,dept.Id AS DepartmentId
	,dept.Name AS DepartmentName
	,t.CreditToBeTaken
	,t.RemainingCredit
FROM
	Teachers AS t
	LEFT JOIN Designations AS d
	ON t.DesignationId = d.Id
	LEFT JOIN Departments AS dept
	ON t.DepartmentId = dept.Id






GO
/****** Object:  Index [IX_Courses]    Script Date: 24-Jan-17 11:51:19 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Courses] ON [dbo].[Courses]
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = ON, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Courses_1]    Script Date: 24-Jan-17 11:51:19 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Courses_1] ON [dbo].[Courses]
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = ON, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Departments]    Script Date: 24-Jan-17 11:51:19 AM ******/
CREATE NONCLUSTERED INDEX [IX_Departments] ON [dbo].[Departments]
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_RoomNo]    Script Date: 24-Jan-17 11:51:19 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_RoomNo] ON [dbo].[RoomNo]
(
	[RoomNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = ON, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Students]    Script Date: 24-Jan-17 11:51:19 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Students] ON [dbo].[Students]
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = ON, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Students_1]    Script Date: 24-Jan-17 11:51:19 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Students_1] ON [dbo].[Students]
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = ON, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Teachers]    Script Date: 24-Jan-17 11:51:19 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Teachers] ON [dbo].[Teachers]
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = ON, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AllocateClassrooms]  WITH CHECK ADD  CONSTRAINT [FK_AllocateClassrooms_Courses] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Courses] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AllocateClassrooms] CHECK CONSTRAINT [FK_AllocateClassrooms_Courses]
GO
ALTER TABLE [dbo].[AllocateClassrooms]  WITH CHECK ADD  CONSTRAINT [FK_AllocateClassrooms_Departments] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Departments] ([Id])
GO
ALTER TABLE [dbo].[AllocateClassrooms] CHECK CONSTRAINT [FK_AllocateClassrooms_Departments]
GO
ALTER TABLE [dbo].[Courses]  WITH CHECK ADD  CONSTRAINT [FK_Courses_Departments] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Departments] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Courses] CHECK CONSTRAINT [FK_Courses_Departments]
GO
ALTER TABLE [dbo].[Courses]  WITH CHECK ADD  CONSTRAINT [FK_Courses_Semesters] FOREIGN KEY([SemesterId])
REFERENCES [dbo].[Semesters] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Courses] CHECK CONSTRAINT [FK_Courses_Semesters]
GO
ALTER TABLE [dbo].[CourseTeacher]  WITH CHECK ADD  CONSTRAINT [FK_CourseTeacher_Departments] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Departments] ([Id])
GO
ALTER TABLE [dbo].[CourseTeacher] CHECK CONSTRAINT [FK_CourseTeacher_Departments]
GO
ALTER TABLE [dbo].[CourseTeacher]  WITH CHECK ADD  CONSTRAINT [FK_CourseTeacher_Teachers] FOREIGN KEY([TeacherId])
REFERENCES [dbo].[Teachers] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CourseTeacher] CHECK CONSTRAINT [FK_CourseTeacher_Teachers]
GO
ALTER TABLE [dbo].[Settings]  WITH CHECK ADD  CONSTRAINT [FK_Settings_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Settings] CHECK CONSTRAINT [FK_Settings_Users]
GO
ALTER TABLE [dbo].[SliderImages]  WITH CHECK ADD  CONSTRAINT [FK_SliderImages_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SliderImages] CHECK CONSTRAINT [FK_SliderImages_Users]
GO
ALTER TABLE [dbo].[StudentEnrollCourse]  WITH CHECK ADD  CONSTRAINT [FK_StudentEnrollCourse_Students] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Students] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[StudentEnrollCourse] CHECK CONSTRAINT [FK_StudentEnrollCourse_Students]
GO
ALTER TABLE [dbo].[StudentResults]  WITH CHECK ADD  CONSTRAINT [FK_StudentResults_Students] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Students] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[StudentResults] CHECK CONSTRAINT [FK_StudentResults_Students]
GO
ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_Students_Departments] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Departments] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_Students_Departments]
GO
ALTER TABLE [dbo].[Teachers]  WITH CHECK ADD  CONSTRAINT [FK_Teachers_Departments] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Departments] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Teachers] CHECK CONSTRAINT [FK_Teachers_Departments]
GO
ALTER TABLE [dbo].[Teachers]  WITH CHECK ADD  CONSTRAINT [FK_Teachers_Designations] FOREIGN KEY([DesignationId])
REFERENCES [dbo].[Designations] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Teachers] CHECK CONSTRAINT [FK_Teachers_Designations]
GO
USE [master]
GO
ALTER DATABASE [SIMDB] SET  READ_WRITE 
GO
