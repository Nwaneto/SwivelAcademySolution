CREATE DATABASE [SwivelAcademyDB]
GO
USE [SwivelAcademyDB]
GO
/****** Object:  Table [dbo].[Courses]    Script Date: 30/06/2021 08:17:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Courses](
	[CourseID] [int] IDENTITY(1,1) NOT NULL,
	[CourseTitle] [nvarchar](100) NOT NULL,
	[CourseSyllable] [nvarchar](100) NULL,
 CONSTRAINT [PK_Courses] PRIMARY KEY CLUSTERED 
(
	[CourseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Students]    Script Date: 30/06/2021 08:17:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[StudentID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](50) NULL,
	[Gender] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED 
(
	[StudentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Student_Teacher_Course]    Script Date: 30/06/2021 08:17:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Student_Teacher_Course](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[StudentID] [int] NOT NULL,
	[Teacher_CourseID] [int] NOT NULL,
 CONSTRAINT [PK_tbl_Student_Teacher_Course] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Teacher_Course]    Script Date: 30/06/2021 08:17:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Teacher_Course](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TeacherID] [int] NOT NULL,
	[CourseID] [int] NOT NULL,
 CONSTRAINT [PK_tbl_Teacher_Course] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teachers]    Script Date: 30/06/2021 08:17:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teachers](
	[TeacherID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](50) NULL,
	[Gender] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Teachers] PRIMARY KEY CLUSTERED 
(
	[TeacherID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Courses] ON 
GO
INSERT [dbo].[Courses] ([CourseID], [CourseTitle], [CourseSyllable]) VALUES (1, N'Biology', N'Something new in biology')
GO
INSERT [dbo].[Courses] ([CourseID], [CourseTitle], [CourseSyllable]) VALUES (2, N'Physics', N'Something New')
GO
INSERT [dbo].[Courses] ([CourseID], [CourseTitle], [CourseSyllable]) VALUES (3, N'Mathematics', N'Something New in Mathematics')
GO
SET IDENTITY_INSERT [dbo].[Courses] OFF
GO
SET IDENTITY_INSERT [dbo].[Students] ON 
GO
INSERT [dbo].[Students] ([StudentID], [FirstName], [LastName], [Address], [Gender]) VALUES (1, N'Chidiebere', N'Nwaneto', N'Ajah, Lagos', N'Male')
GO
INSERT [dbo].[Students] ([StudentID], [FirstName], [LastName], [Address], [Gender]) VALUES (1002, N'werwtrt', N'rtretwert', N'sdgdfg', N'Female')
GO
INSERT [dbo].[Students] ([StudentID], [FirstName], [LastName], [Address], [Gender]) VALUES (1003, N'string', N'string', N'string', N'string')
GO
SET IDENTITY_INSERT [dbo].[Students] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_Student_Teacher_Course] ON 
GO
INSERT [dbo].[tbl_Student_Teacher_Course] ([ID], [StudentID], [Teacher_CourseID]) VALUES (1, 1, 1)
GO
INSERT [dbo].[tbl_Student_Teacher_Course] ([ID], [StudentID], [Teacher_CourseID]) VALUES (2, 1, 2)
GO
INSERT [dbo].[tbl_Student_Teacher_Course] ([ID], [StudentID], [Teacher_CourseID]) VALUES (3, 1, 3)
GO
INSERT [dbo].[tbl_Student_Teacher_Course] ([ID], [StudentID], [Teacher_CourseID]) VALUES (1002, 1003, 1)
GO
SET IDENTITY_INSERT [dbo].[tbl_Student_Teacher_Course] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_Teacher_Course] ON 
GO
INSERT [dbo].[tbl_Teacher_Course] ([ID], [TeacherID], [CourseID]) VALUES (1, 1, 1)
GO
INSERT [dbo].[tbl_Teacher_Course] ([ID], [TeacherID], [CourseID]) VALUES (2, 1, 2)
GO
INSERT [dbo].[tbl_Teacher_Course] ([ID], [TeacherID], [CourseID]) VALUES (3, 1, 3)
GO
INSERT [dbo].[tbl_Teacher_Course] ([ID], [TeacherID], [CourseID]) VALUES (4, 2, 1)
GO
INSERT [dbo].[tbl_Teacher_Course] ([ID], [TeacherID], [CourseID]) VALUES (5, 2, 2)
GO
INSERT [dbo].[tbl_Teacher_Course] ([ID], [TeacherID], [CourseID]) VALUES (6, 2, 3)
GO
INSERT [dbo].[tbl_Teacher_Course] ([ID], [TeacherID], [CourseID]) VALUES (1008, 2, 1)
GO
SET IDENTITY_INSERT [dbo].[tbl_Teacher_Course] OFF
GO
SET IDENTITY_INSERT [dbo].[Teachers] ON 
GO
INSERT [dbo].[Teachers] ([TeacherID], [FirstName], [LastName], [Address], [Gender]) VALUES (1, N'Lydia', N'Ikoba', N'Lagos, Nigeria', N'Female')
GO
INSERT [dbo].[Teachers] ([TeacherID], [FirstName], [LastName], [Address], [Gender]) VALUES (2, N'John', N'Deen', N'Abuja, Nigeria', N'Male')
GO
SET IDENTITY_INSERT [dbo].[Teachers] OFF
GO
ALTER TABLE [dbo].[tbl_Student_Teacher_Course]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Student_Teacher_Course_Students] FOREIGN KEY([StudentID])
REFERENCES [dbo].[Students] ([StudentID])
GO
ALTER TABLE [dbo].[tbl_Student_Teacher_Course] CHECK CONSTRAINT [FK_tbl_Student_Teacher_Course_Students]
GO
ALTER TABLE [dbo].[tbl_Student_Teacher_Course]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Student_Teacher_Course_tbl_Teacher_Course] FOREIGN KEY([Teacher_CourseID])
REFERENCES [dbo].[tbl_Teacher_Course] ([ID])
GO
ALTER TABLE [dbo].[tbl_Student_Teacher_Course] CHECK CONSTRAINT [FK_tbl_Student_Teacher_Course_tbl_Teacher_Course]
GO
ALTER TABLE [dbo].[tbl_Teacher_Course]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Teacher_Course_Courses] FOREIGN KEY([CourseID])
REFERENCES [dbo].[Courses] ([CourseID])
GO
ALTER TABLE [dbo].[tbl_Teacher_Course] CHECK CONSTRAINT [FK_tbl_Teacher_Course_Courses]
GO
ALTER TABLE [dbo].[tbl_Teacher_Course]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Teacher_Course_Teachers] FOREIGN KEY([TeacherID])
REFERENCES [dbo].[Teachers] ([TeacherID])
GO
ALTER TABLE [dbo].[tbl_Teacher_Course] CHECK CONSTRAINT [FK_tbl_Teacher_Course_Teachers]
GO
/****** Object:  StoredProcedure [dbo].[STP_AssignTeacherToCourse]    Script Date: 30/06/2021 08:17:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Chidiebere Nwaneto>
-- Create date: <24th June, 2021>
-- Description:	<Stored Procedure to assign a teacher to a course>
-- =============================================
CREATE PROCEDURE [dbo].[STP_AssignTeacherToCourse]
	@TeacherID INT,
	@CourseID INT
AS
BEGIN
	DECLARE @result VARCHAR(100) =''
	INSERT INTO tbl_Teacher_Course
	VALUES   
        (   
			@TeacherID,
			@CourseID
        )
		IF  @@ROWCOUNT > 0 
			SET @result= 'Successfully Created'
		ELSE
			SET @result = 'Failed'
	SELECT @Result AS Result
END
GO
/****** Object:  StoredProcedure [dbo].[STP_CreateCourse]    Script Date: 30/06/2021 08:17:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Chidiebere Nwaneto>
-- Create date: <24th June, 2021>
-- Description:	<Stored Procedure to create a course record>
-- =============================================
CREATE PROCEDURE [dbo].[STP_CreateCourse]
	@CourseTitle NVARCHAR (200),
	@CourseSyllable  NVARCHAR (200)
AS
BEGIN
	DECLARE @result VARCHAR(100) =''
	INSERT INTO Courses
	VALUES   
        (   
			@CourseTitle,
			@CourseSyllable


        )
		IF  @@ROWCOUNT > 0 
			SET @result= 'Successfully Created'
		ELSE
			SET @result = 'Failed'
	SELECT @Result AS Result
END
GO
/****** Object:  StoredProcedure [dbo].[STP_CreateStudent]    Script Date: 30/06/2021 08:17:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Chidiebere Nwaneto>
-- Create date: <24th June, 2021>
-- Description:	<Stored Procedure to create student record>
-- =============================================
CREATE PROCEDURE [dbo].[STP_CreateStudent]
	@FirstName NVARCHAR (200),
	@LastName NVARCHAR (200),
	@Address  NVARCHAR (200),
	@Gender NVARCHAR(20)
AS
BEGIN
	DECLARE @result VARCHAR(100) =''
	INSERT INTO Students
	VALUES   
        (   
			@FirstName,
			@LastName,
			@Address,
			@Gender

        )
		IF  @@ROWCOUNT > 0 
			SET @result= 'Successfully Created'
		ELSE
			SET @result = 'Failed'
	SELECT @Result AS Result
END
GO
/****** Object:  StoredProcedure [dbo].[STP_CreateTeacher]    Script Date: 30/06/2021 08:17:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Chidiebere Nwaneto>
-- Create date: <24th June, 2021>
-- Description:	<Stored Procedure to create teacher record>
-- =============================================
CREATE PROCEDURE [dbo].[STP_CreateTeacher]
	@FirstName NVARCHAR (200),
	@LastName NVARCHAR (200),
	@Address  NVARCHAR (200),
	@Gender NVARCHAR(20)
AS
BEGIN
	DECLARE @result VARCHAR(100) =''
	INSERT INTO Teachers
	VALUES   
        (   
			@FirstName,
			@LastName,
			@Address,
			@Gender

        )
		IF  @@ROWCOUNT > 0 
			SET @result= 'Successfully Created'
		ELSE
			SET @result = 'Failed'
	SELECT @Result AS Result
END
GO
/****** Object:  StoredProcedure [dbo].[STP_DeleteCourse]    Script Date: 30/06/2021 08:17:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Chidiebere Nwaneto>
-- Create date: <24th June, 2021>
-- Description:	<Stored Procedure to delete a course by courseID>
-- =============================================
CREATE PROCEDURE [dbo].[STP_DeleteCourse]
	@CourseId int
AS
BEGIN
	DELETE 
		FROM Courses  
        WHERE  CourseID = @CourseId  
END
GO
/****** Object:  StoredProcedure [dbo].[STP_DeleteStudent]    Script Date: 30/06/2021 08:17:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Chidiebere Nwaneto>
-- Create date: <24th June, 2021>
-- Description:	<Stored Procedure to delete a student's record>
-- =============================================
CREATE PROCEDURE [dbo].[STP_DeleteStudent]
	@StudentId int
AS
BEGIN
	DELETE 
		FROM Students  
        WHERE  StudentID = @StudentId  
END
GO
/****** Object:  StoredProcedure [dbo].[STP_DeleteTeacher]    Script Date: 30/06/2021 08:17:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Chidiebere Nwaneto>
-- Create date: <24th June, 2021>
-- Description:	<Stored Procedure to delete a teacher's record>
-- =============================================
CREATE PROCEDURE [dbo].[STP_DeleteTeacher]
	@TeacherId int
AS
BEGIN
	DELETE 
		FROM Teachers  
        WHERE  TeacherID = @TeacherId  
END
GO
/****** Object:  StoredProcedure [dbo].[STP_GetAllCourses]    Script Date: 30/06/2021 08:17:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Chidiebere Nwaneto>
-- Create date: <24th June, 2021>
-- Description:	<Stored Procedure get all available courses>
-- =============================================
CREATE PROCEDURE [dbo].[STP_GetAllCourses]
	AS
BEGIN
	SELECT 
		CourseID,
		CourseTitle,
		CourseSyllable
	from Courses 
END
GO
/****** Object:  StoredProcedure [dbo].[STP_GetAllCoursesRegByStudent]    Script Date: 30/06/2021 08:17:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		<Chidiebere Nwaneto>
-- Create date: <24th June, 2021>
-- Description:	<Stored Procedure get all courses registered by a student>
-- =============================================
CREATE PROCEDURE [dbo].[STP_GetAllCoursesRegByStudent]
	@StudentId INT
	AS
BEGIN
	SELECT 
		c.CourseID, CourseTitle, CourseSyllable, s.FirstName as TeacherName
	from Courses c
		INNER JOIN tbl_Student_Teacher_Course t ON c.CourseID = t.Teacher_CourseID
		LEFT OUTER JOIN Teachers s ON s.TeacherID = t.ID
	WHERE StudentID = @StudentId
END
GO
/****** Object:  StoredProcedure [dbo].[STP_GetAllCoursesTaughtByTeacher]    Script Date: 30/06/2021 08:17:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Chidiebere Nwaneto>
-- Create date: <24th June, 2021>
-- Description:	<Stored Procedure get all courses taught by a teacher>
-- =============================================
CREATE PROCEDURE [dbo].[STP_GetAllCoursesTaughtByTeacher]
	@TeacherId INT
	AS
BEGIN
	SELECT 
		c.CourseID, CourseTitle, CourseSyllable
	from Courses c
		INNER JOIN tbl_Teacher_Course t ON c.CourseID = t.CourseID
	WHERE TeacherID = @TeacherId
END
GO
/****** Object:  StoredProcedure [dbo].[STP_GetAllStudents]    Script Date: 30/06/2021 08:17:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Chidiebere Nwaneto>
-- Create date: <24th June, 2021>
-- Description:	<Stored Procedure get all students record>
-- =============================================
CREATE PROCEDURE [dbo].[STP_GetAllStudents]
	AS
BEGIN
	SELECT 
		StudentID,
		FirstName,
		LastName,
		Address,
		Gender
	from Students 
END
GO
/****** Object:  StoredProcedure [dbo].[STP_GetAllTeachers]    Script Date: 30/06/2021 08:17:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Chidiebere Nwaneto>
-- Create date: <24th June, 2021>
-- Description:	<Stored Procedure get all teachers record>
-- =============================================
CREATE PROCEDURE [dbo].[STP_GetAllTeachers]
	AS
BEGIN
	SELECT 
		TeacherID,
		FirstName,
		LastName,
		Address,
		Gender
	from Teachers 
END
GO
/****** Object:  StoredProcedure [dbo].[STP_GetCourse]    Script Date: 30/06/2021 08:17:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Chidiebere Nwaneto>
-- Create date: <24th June, 2021>
-- Description:	<Stored Procedure to get a course by courseID>
-- =============================================
CREATE PROCEDURE [dbo].[STP_GetCourse]
	@CourseId int
AS
BEGIN
	SELECT 
		CourseID,
		CourseTitle,
		CourseSyllable
	FROM Courses 
	WHERE CourseID = @CourseId
END
GO
/****** Object:  StoredProcedure [dbo].[STP_GetStudent]    Script Date: 30/06/2021 08:17:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Chidiebere Nwaneto>
-- Create date: <24th June, 2021>
-- Description:	<Stored Procedure to read a student's record using studentID>
-- =============================================
CREATE PROCEDURE [dbo].[STP_GetStudent]
	@StudentId int
AS
BEGIN
	SELECT 
		StudentID,
		FirstName,
		LastName,
		Address,
		Gender
	FROM Students 
	WHERE StudentID = @StudentId
END
GO
/****** Object:  StoredProcedure [dbo].[STP_GetTeacher]    Script Date: 30/06/2021 08:17:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Chidiebere Nwaneto>
-- Create date: <24th June, 2021>
-- Description:	<Stored Procedure to read a teacher's record using teacherID>
-- =============================================
CREATE PROCEDURE [dbo].[STP_GetTeacher]
	@TeacherId int
AS
BEGIN
	SELECT 
		TeacherID,
		FirstName,
		LastName,
		Address,
		Gender
	FROM Teachers 
	WHERE TeacherID = @TeacherId
END
GO
/****** Object:  StoredProcedure [dbo].[STP_RegisterStudentToCourse]    Script Date: 30/06/2021 08:17:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Chidiebere Nwaneto>
-- Create date: <24th June, 2021>
-- Description:	<Stored Procedure for student to register for a course>
-- =============================================
CREATE PROCEDURE [dbo].[STP_RegisterStudentToCourse]
	@StudentID INT,
	@TeacherCourseID INT
AS
BEGIN
	DECLARE @result VARCHAR(100) =''
	INSERT INTO tbl_Student_Teacher_Course
	VALUES   
        (   
			@StudentID,
			@TeacherCourseID

        )
		IF  @@ROWCOUNT > 0 
			SET @result= 'Successfully Created'
		ELSE
			SET @result = 'Failed'
	SELECT @Result AS Result
END
GO
/****** Object:  StoredProcedure [dbo].[STP_UpdateCourse]    Script Date: 30/06/2021 08:17:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Chidiebere Nwaneto>
-- Create date: <24th June, 2021>
-- Description:	<Stored Procedure to update a course record>
-- =============================================
CREATE PROCEDURE [dbo].[STP_UpdateCourse]
	@CourseId INT,
	@CourseTitle NVARCHAR (200),
	@CourseSyllable  NVARCHAR (200)
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @Status NVARCHAR(50)
	UPDATE Courses
		SET 
			CourseTitle = @CourseTitle,
			CourseSyllable = @CourseSyllable
		WHERE CourseID = @CourseId
		IF @@ROWCOUNT > 0
			SET @Status = 'Updated Successfully'
		ELSE
			SET @Status = 'Failed'

	SELECT @Status AS Result
END
GO
/****** Object:  StoredProcedure [dbo].[STP_UpdateStudent]    Script Date: 30/06/2021 08:17:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Chidiebere Nwaneto>
-- Create date: <24th June, 2021>
-- Description:	<Stored Procedure to update a student's record>
-- =============================================
CREATE PROCEDURE [dbo].[STP_UpdateStudent]
	@StudentId INT,
	@FirstName NVARCHAR (200),
	@LastName NVARCHAR (200),
	@Address  NVARCHAR (200),
	@Gender NVARCHAR(20)
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @Status NVARCHAR(50)
	UPDATE Students
		SET 
			FirstName = @FirstName,
			LastName = @LastName,
			Address = @Address,
			Gender = @Gender
		WHERE StudentID = @StudentId
		IF @@ROWCOUNT > 0
			SET @Status = 'Updated Successfully'
		ELSE
			SET @Status = 'Failed'

	SELECT @Status AS Result
END
GO
/****** Object:  StoredProcedure [dbo].[STP_UpdateTeacher]    Script Date: 30/06/2021 08:17:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Chidiebere Nwaneto>
-- Create date: <24th June, 2021>
-- Description:	<Stored Procedure to update a teacher's record>
-- =============================================
CREATE PROCEDURE [dbo].[STP_UpdateTeacher]
	@TeacherId INT,
	@FirstName NVARCHAR (200),
	@LastName NVARCHAR (200),
	@Address  NVARCHAR (200),
	@Gender NVARCHAR(20)
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @Status NVARCHAR(50)
	UPDATE Teachers
		SET 
			FirstName = @FirstName,
			LastName = @LastName,
			Address = @Address,
			Gender = @Gender
		WHERE TeacherID = @TeacherId
		IF @@ROWCOUNT > 0
			SET @Status = 'Updated Successfully'
		ELSE
			SET @Status = 'Failed'

	SELECT @Status AS Result
END
