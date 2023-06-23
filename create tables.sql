
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Specialization](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[rowinserttime] [datetime] NOT NULL,
	[rowupdatetime] [datetime] NOT NULL,
 CONSTRAINT [PK_Specialization] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Specialization] ADD  CONSTRAINT [DF_Specialization_rowinserttime]  DEFAULT (getutcdate()) FOR [rowinserttime]
GO

ALTER TABLE [dbo].[Specialization] ADD  CONSTRAINT [DF_Specialization_rowupdatetime]  DEFAULT (getutcdate()) FOR [rowupdatetime]
GO



CREATE TABLE [dbo].[UserRole](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[role_name] [nvarchar](50) NOT NULL,
	[rowinserttime] [datetime] NOT NULL,
	[rowupdatetime] [datetime] NOT NULL,
 CONSTRAINT [PK_UserRole] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[UserRole] ADD  CONSTRAINT [DF_UserRole_rowinserttime]  DEFAULT (getutcdate()) FOR [rowinserttime]
GO

ALTER TABLE [dbo].[UserRole] ADD  CONSTRAINT [DF_UserRole_rowupdatetime]  DEFAULT (getutcdate()) FOR [rowupdatetime]
GO


CREATE TABLE [dbo].[Class](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[rowinserttime] [datetime] NOT NULL,
	[rowupdatetime] [datetime] NOT NULL,
 CONSTRAINT [PK_Class] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Class] ADD  CONSTRAINT [DF_Class_rowinserttime]  DEFAULT (getutcdate()) FOR [rowinserttime]
GO

ALTER TABLE [dbo].[Class] ADD  CONSTRAINT [DF_Class_rowupdatetime]  DEFAULT (getutcdate()) FOR [rowupdatetime]
GO

CREATE TABLE [dbo].[UserInfo](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[login] [nvarchar](50) NOT NULL,
	[password] [binary](50) NOT NULL,
	[role] [int] NOT NULL,
	[salt] [uniqueidentifier] NOT NULL,
	[rowinserttime] [datetime] NOT NULL,
	[rowupdatetime] [datetime] NOT NULL,
 CONSTRAINT [PK_UserInfo] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[UserInfo] ADD  CONSTRAINT [DF_UserInfo_rowinserttime]  DEFAULT (getutcdate()) FOR [rowinserttime]
GO

ALTER TABLE [dbo].[UserInfo] ADD  CONSTRAINT [DF_UserInfo_rowupdatetime]  DEFAULT (getutcdate()) FOR [rowupdatetime]
GO

ALTER TABLE [dbo].[UserInfo]  WITH CHECK ADD  CONSTRAINT [FK_UserInfo_UserRole] FOREIGN KEY([role])
REFERENCES [dbo].[UserRole] ([id])
GO

ALTER TABLE [dbo].[UserInfo] CHECK CONSTRAINT [FK_UserInfo_UserRole]
GO


CREATE TABLE [dbo].[Person](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[surname] [nvarchar](50) NOT NULL,
	[lastname] [nvarchar](50) NOT NULL,
	[birth_date] [date] NOT NULL,
	[user_id] [int] NOT NULL,
	[rowinserttime] [datetime] NOT NULL,
	[rowupdatetime] [datetime] NOT NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Person] ADD  CONSTRAINT [DF_Person_rowinserttime]  DEFAULT (getutcdate()) FOR [rowinserttime]
GO

ALTER TABLE [dbo].[Person] ADD  CONSTRAINT [DF_Person_rowupdatetime]  DEFAULT (getutcdate()) FOR [rowupdatetime]
GO

ALTER TABLE [dbo].[Person]  WITH CHECK ADD  CONSTRAINT [FK_Person_UserInfo] FOREIGN KEY([user_id])
REFERENCES [dbo].[UserInfo] ([id])
GO

ALTER TABLE [dbo].[Person] CHECK CONSTRAINT [FK_Person_UserInfo]
GO

CREATE TABLE [dbo].[Parent](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[person_id] [int] NOT NULL,
	[rowinserttime] [datetime] NOT NULL,
	[rowupdatetime] [datetime] NOT NULL,
 CONSTRAINT [PK_Parent] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Parent] ADD  CONSTRAINT [DF_Parent_rowinserttime]  DEFAULT (getutcdate()) FOR [rowinserttime]
GO

ALTER TABLE [dbo].[Parent] ADD  CONSTRAINT [DF_Parent_rowupdatetime]  DEFAULT (getutcdate()) FOR [rowupdatetime]
GO

ALTER TABLE [dbo].[Parent]  WITH CHECK ADD  CONSTRAINT [FK_Parent_Person] FOREIGN KEY([person_id])
REFERENCES [dbo].[Person] ([id])
GO

ALTER TABLE [dbo].[Parent] CHECK CONSTRAINT [FK_Parent_Person]
GO


CREATE TABLE [dbo].[Teacher](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[person_id] [int] NOT NULL,
	[class_id] [int] NOT NULL,
	[specialization_id] [int] NOT NULL,
	[rowinserttime] [datetime] NOT NULL,
	[rowupdatetime] [datetime] NOT NULL,
 CONSTRAINT [PK_Teacher] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Teacher] ADD  CONSTRAINT [DF_Teacher_rowinserttime]  DEFAULT (getutcdate()) FOR [rowinserttime]
GO

ALTER TABLE [dbo].[Teacher] ADD  CONSTRAINT [DF_Teacher_rowupdatetime]  DEFAULT (getutcdate()) FOR [rowupdatetime]
GO

ALTER TABLE [dbo].[Teacher]  WITH CHECK ADD  CONSTRAINT [FK_Teacher_Class] FOREIGN KEY([class_id])
REFERENCES [dbo].[Class] ([id])
GO

ALTER TABLE [dbo].[Teacher] CHECK CONSTRAINT [FK_Teacher_Class]
GO

ALTER TABLE [dbo].[Teacher]  WITH CHECK ADD  CONSTRAINT [FK_Teacher_Person] FOREIGN KEY([person_id])
REFERENCES [dbo].[Person] ([id])
GO

ALTER TABLE [dbo].[Teacher] CHECK CONSTRAINT [FK_Teacher_Person]
GO

ALTER TABLE [dbo].[Teacher]  WITH CHECK ADD  CONSTRAINT [FK_Teacher_Specialization] FOREIGN KEY([specialization_id])
REFERENCES [dbo].[Specialization] ([id])
GO

ALTER TABLE [dbo].[Teacher] CHECK CONSTRAINT [FK_Teacher_Specialization]
GO


CREATE TABLE [dbo].[Student](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[person_id] [int] NOT NULL,
	[class_id] [int] NOT NULL,
	[rowinserttime] [datetime] NOT NULL,
	[rowupdatetime] [datetime] NOT NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Student] ADD  CONSTRAINT [DF_Student_rowinserttime]  DEFAULT (getutcdate()) FOR [rowinserttime]
GO

ALTER TABLE [dbo].[Student] ADD  CONSTRAINT [DF_Student_rowupdatetime]  DEFAULT (getutcdate()) FOR [rowupdatetime]
GO

ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_Class] FOREIGN KEY([class_id])
REFERENCES [dbo].[Class] ([id])
GO

ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_Class]
GO

ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_Person] FOREIGN KEY([person_id])
REFERENCES [dbo].[Person] ([id])
GO

ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_Person]
GO



CREATE TABLE [dbo].[Lesson](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](50) NOT NULL,
	[rowinserttime] [datetime] NOT NULL,
	[rowupdatetime] [datetime] NOT NULL,
 CONSTRAINT [PK_Lesson] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Lesson] ADD  CONSTRAINT [DF_Lesson_rowinserttime]  DEFAULT (getutcdate()) FOR [rowinserttime]
GO

ALTER TABLE [dbo].[Lesson] ADD  CONSTRAINT [DF_Lesson_rowupdatetime]  DEFAULT (getutcdate()) FOR [rowupdatetime]
GO


CREATE TABLE [dbo].[Journal](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[student_id] [int] NOT NULL,
	[day_num] [int] NOT NULL,
	[lesson_id] [int] NOT NULL,
	[mark] [int] NOT NULL,
	[rowinserttime] [datetime] NOT NULL,
	[rowupdatetime] [datetime] NOT NULL,
 CONSTRAINT [PK_Journal] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Journal] ADD  CONSTRAINT [DF_Journal_rowinserttime]  DEFAULT (getutcdate()) FOR [rowinserttime]
GO

ALTER TABLE [dbo].[Journal] ADD  CONSTRAINT [DF_Journal_rowupdatetime]  DEFAULT (getutcdate()) FOR [rowupdatetime]
GO

ALTER TABLE [dbo].[Journal]  WITH CHECK ADD  CONSTRAINT [FK_Journal_Lesson] FOREIGN KEY([lesson_id])
REFERENCES [dbo].[Lesson] ([id])
GO

ALTER TABLE [dbo].[Journal] CHECK CONSTRAINT [FK_Journal_Lesson]
GO

ALTER TABLE [dbo].[Journal]  WITH CHECK ADD  CONSTRAINT [FK_Journal_Student] FOREIGN KEY([student_id])
REFERENCES [dbo].[Student] ([id])
GO

ALTER TABLE [dbo].[Journal] CHECK CONSTRAINT [FK_Journal_Student]
GO



CREATE TABLE [dbo].[Task](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[student_id] [int] NOT NULL,
	[lesson_id] [int] NOT NULL,
	[description] [nvarchar](600) NOT NULL,
	[deadline] [datetime] NOT NULL,
	[closedtime] [datetime] NOT NULL,
	[status] [bit] NOT NULL,
	[rowinserttime] [datetime] NOT NULL,
	[rowupdatetime] [datetime] NOT NULL,
 CONSTRAINT [PK_Task] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Task] ADD  CONSTRAINT [DF_Task_rowinserttime]  DEFAULT (getutcdate()) FOR [rowinserttime]
GO

ALTER TABLE [dbo].[Task] ADD  CONSTRAINT [DF_Task_rowupdatetime]  DEFAULT (getutcdate()) FOR [rowupdatetime]
GO

ALTER TABLE [dbo].[Task]  WITH CHECK ADD  CONSTRAINT [FK_Task_Lesson] FOREIGN KEY([lesson_id])
REFERENCES [dbo].[Lesson] ([id])
GO

ALTER TABLE [dbo].[Task] CHECK CONSTRAINT [FK_Task_Lesson]
GO

ALTER TABLE [dbo].[Task]  WITH CHECK ADD  CONSTRAINT [FK_Task_Student] FOREIGN KEY([student_id])
REFERENCES [dbo].[Student] ([id])
GO

ALTER TABLE [dbo].[Task] CHECK CONSTRAINT [FK_Task_Student]
GO



CREATE TABLE [dbo].[ParentStudent](
	[parent_id] [int] NOT NULL,
	[student_id] [int] NOT NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ParentStudent]  WITH CHECK ADD  CONSTRAINT [FK_ParentStudent_Parent] FOREIGN KEY([parent_id])
REFERENCES [dbo].[Parent] ([id])
GO

ALTER TABLE [dbo].[ParentStudent] CHECK CONSTRAINT [FK_ParentStudent_Parent]
GO

ALTER TABLE [dbo].[ParentStudent]  WITH CHECK ADD  CONSTRAINT [FK_ParentStudent_Student] FOREIGN KEY([student_id])
REFERENCES [dbo].[Student] ([id])
GO

ALTER TABLE [dbo].[ParentStudent] CHECK CONSTRAINT [FK_ParentStudent_Student]
GO



CREATE TABLE [dbo].[Shedule](
	[day_num] [int] NOT NULL,
	[lesson_num] [int] NOT NULL,
	[class_id] [int] NOT NULL,
	[teacher_id] [int] NOT NULL,
	[lesson_id] [int] NOT NULL,
	[rowinserttime] [datetime] NOT NULL,
	[rowupdatetime] [datetime] NOT NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Shedule] ADD  CONSTRAINT [DF_Shedule_rowinserttime]  DEFAULT (getutcdate()) FOR [rowinserttime]
GO

ALTER TABLE [dbo].[Shedule] ADD  CONSTRAINT [DF_Shedule_rowupdatetime]  DEFAULT (getutcdate()) FOR [rowupdatetime]
GO

ALTER TABLE [dbo].[Shedule]  WITH CHECK ADD  CONSTRAINT [FK_Shedule_Class] FOREIGN KEY([class_id])
REFERENCES [dbo].[Class] ([id])
GO

ALTER TABLE [dbo].[Shedule] CHECK CONSTRAINT [FK_Shedule_Class]
GO

ALTER TABLE [dbo].[Shedule]  WITH CHECK ADD  CONSTRAINT [FK_Shedule_Lesson] FOREIGN KEY([lesson_id])
REFERENCES [dbo].[Lesson] ([id])
GO

ALTER TABLE [dbo].[Shedule] CHECK CONSTRAINT [FK_Shedule_Lesson]
GO

ALTER TABLE [dbo].[Shedule]  WITH CHECK ADD  CONSTRAINT [FK_Shedule_Teacher] FOREIGN KEY([teacher_id])
REFERENCES [dbo].[Teacher] ([id])
GO

ALTER TABLE [dbo].[Shedule] CHECK CONSTRAINT [FK_Shedule_Teacher]
GO

