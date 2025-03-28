USE [SchoolManagement]
GO
/****** Object:  Table [dbo].[Accounts]    Script Date: 3/26/2025 6:11:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accounts](
	[AccountID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[PasswordHash] [nvarchar](255) NOT NULL,
	[Role] [nvarchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[AccountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Classes]    Script Date: 3/26/2025 6:11:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Classes](
	[ClassID] [int] IDENTITY(1,1) NOT NULL,
	[ClassName] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ClassID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClassRooms]    Script Date: 3/26/2025 6:11:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClassRooms](
	[ClassRoomID] [int] IDENTITY(1,1) NOT NULL,
	[RoomName] [nvarchar](50) NOT NULL,
	[Capacity] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ClassRoomID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Students]    Script Date: 3/26/2025 6:11:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[StudentID] [int] IDENTITY(1,1) NOT NULL,
	[AccountID] [int] NOT NULL,
	[FullName] [nvarchar](100) NOT NULL,
	[DateOfBirth] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[StudentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudySlots]    Script Date: 3/26/2025 6:11:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudySlots](
	[StudySlotID] [int] IDENTITY(1,1) NOT NULL,
	[ClassID] [int] NOT NULL,
	[SubjectID] [int] NOT NULL,
	[TeacherID] [int] NOT NULL,
	[ClassRoomID] [int] NOT NULL,
	[StartTime] [datetime] NOT NULL,
	[EndTime] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[StudySlotID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subjects]    Script Date: 3/26/2025 6:11:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subjects](
	[SubjectID] [int] IDENTITY(1,1) NOT NULL,
	[SubjectCode] [varchar](50) NOT NULL,
	[SubjectName] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[SubjectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teachers]    Script Date: 3/26/2025 6:11:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teachers](
	[TeacherID] [int] IDENTITY(1,1) NOT NULL,
	[AccountID] [int] NOT NULL,
	[FullName] [nvarchar](100) NOT NULL,
	[Specialty] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[TeacherID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Accounts] ON 

INSERT [dbo].[Accounts] ([AccountID], [Username], [PasswordHash], [Role]) VALUES (1, N'admin1', N'hashed_password_1', N'Admin')
INSERT [dbo].[Accounts] ([AccountID], [Username], [PasswordHash], [Role]) VALUES (2, N'student1', N'hashed_password_2', N'Student')
INSERT [dbo].[Accounts] ([AccountID], [Username], [PasswordHash], [Role]) VALUES (3, N'student2', N'hashed_password_3', N'Student')
INSERT [dbo].[Accounts] ([AccountID], [Username], [PasswordHash], [Role]) VALUES (4, N'teacher1', N'hashed_password_4', N'Teacher')
INSERT [dbo].[Accounts] ([AccountID], [Username], [PasswordHash], [Role]) VALUES (5, N'teacher2', N'hashed_password_5', N'Teacher')
SET IDENTITY_INSERT [dbo].[Accounts] OFF
GO
SET IDENTITY_INSERT [dbo].[Classes] ON 

INSERT [dbo].[Classes] ([ClassID], [ClassName]) VALUES (1, N'Class 12A')
INSERT [dbo].[Classes] ([ClassID], [ClassName]) VALUES (2, N'Class 12B')
SET IDENTITY_INSERT [dbo].[Classes] OFF
GO
SET IDENTITY_INSERT [dbo].[ClassRooms] ON 

INSERT [dbo].[ClassRooms] ([ClassRoomID], [RoomName], [Capacity]) VALUES (1, N'Room A1', 30)
INSERT [dbo].[ClassRooms] ([ClassRoomID], [RoomName], [Capacity]) VALUES (2, N'Room B2', 40)
SET IDENTITY_INSERT [dbo].[ClassRooms] OFF
GO
SET IDENTITY_INSERT [dbo].[Students] ON 

INSERT [dbo].[Students] ([StudentID], [AccountID], [FullName], [DateOfBirth]) VALUES (1, 2, N'Nguyen Van A', CAST(N'2002-05-10' AS Date))
INSERT [dbo].[Students] ([StudentID], [AccountID], [FullName], [DateOfBirth]) VALUES (2, 3, N'Tran Thi B', CAST(N'2001-09-15' AS Date))
SET IDENTITY_INSERT [dbo].[Students] OFF
GO
SET IDENTITY_INSERT [dbo].[StudySlots] ON 

INSERT [dbo].[StudySlots] ([StudySlotID], [ClassID], [SubjectID], [TeacherID], [ClassRoomID], [StartTime], [EndTime]) VALUES (1, 1, 1, 1, 1, CAST(N'2025-04-01T08:00:00.000' AS DateTime), CAST(N'2025-04-01T10:00:00.000' AS DateTime))
INSERT [dbo].[StudySlots] ([StudySlotID], [ClassID], [SubjectID], [TeacherID], [ClassRoomID], [StartTime], [EndTime]) VALUES (2, 1, 2, 2, 2, CAST(N'2025-04-02T08:00:00.000' AS DateTime), CAST(N'2025-04-02T10:00:00.000' AS DateTime))
INSERT [dbo].[StudySlots] ([StudySlotID], [ClassID], [SubjectID], [TeacherID], [ClassRoomID], [StartTime], [EndTime]) VALUES (3, 2, 3, 1, 1, CAST(N'2025-04-03T13:00:00.000' AS DateTime), CAST(N'2025-04-03T15:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[StudySlots] OFF
GO
SET IDENTITY_INSERT [dbo].[Subjects] ON 

INSERT [dbo].[Subjects] ([SubjectID], [SubjectCode], [SubjectName]) VALUES (1, N'MATH101', N'Calculus')
INSERT [dbo].[Subjects] ([SubjectID], [SubjectCode], [SubjectName]) VALUES (2, N'PHY102', N'Physics')
INSERT [dbo].[Subjects] ([SubjectID], [SubjectCode], [SubjectName]) VALUES (3, N'CS103', N'Computer Science')
SET IDENTITY_INSERT [dbo].[Subjects] OFF
GO
SET IDENTITY_INSERT [dbo].[Teachers] ON 

INSERT [dbo].[Teachers] ([TeacherID], [AccountID], [FullName], [Specialty]) VALUES (1, 4, N'Le Van C', N'Mathematics')
INSERT [dbo].[Teachers] ([TeacherID], [AccountID], [FullName], [Specialty]) VALUES (2, 5, N'Pham Thi D', N'Physics')
SET IDENTITY_INSERT [dbo].[Teachers] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Accounts__536C85E41DB21E03]    Script Date: 3/26/2025 6:11:36 PM ******/
ALTER TABLE [dbo].[Accounts] ADD UNIQUE NONCLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Classes__F8BF561B4E8A6C0C]    Script Date: 3/26/2025 6:11:36 PM ******/
ALTER TABLE [dbo].[Classes] ADD UNIQUE NONCLUSTERED 
(
	[ClassName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__ClassRoo__6B500B55016A316E]    Script Date: 3/26/2025 6:11:36 PM ******/
ALTER TABLE [dbo].[ClassRooms] ADD UNIQUE NONCLUSTERED 
(
	[RoomName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UQ__Students__349DA5870153BD8D]    Script Date: 3/26/2025 6:11:36 PM ******/
ALTER TABLE [dbo].[Students] ADD UNIQUE NONCLUSTERED 
(
	[AccountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Subjects__4C5A7D55E726008A]    Script Date: 3/26/2025 6:11:36 PM ******/
ALTER TABLE [dbo].[Subjects] ADD UNIQUE NONCLUSTERED 
(
	[SubjectName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Subjects__9F7CE1A93349F0C7]    Script Date: 3/26/2025 6:11:36 PM ******/
ALTER TABLE [dbo].[Subjects] ADD UNIQUE NONCLUSTERED 
(
	[SubjectCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UQ__Teachers__349DA58786045A81]    Script Date: 3/26/2025 6:11:36 PM ******/
ALTER TABLE [dbo].[Teachers] ADD UNIQUE NONCLUSTERED 
(
	[AccountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Students]  WITH CHECK ADD FOREIGN KEY([AccountID])
REFERENCES [dbo].[Accounts] ([AccountID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[StudySlots]  WITH CHECK ADD FOREIGN KEY([ClassID])
REFERENCES [dbo].[Classes] ([ClassID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[StudySlots]  WITH CHECK ADD FOREIGN KEY([ClassRoomID])
REFERENCES [dbo].[ClassRooms] ([ClassRoomID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[StudySlots]  WITH CHECK ADD FOREIGN KEY([SubjectID])
REFERENCES [dbo].[Subjects] ([SubjectID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[StudySlots]  WITH CHECK ADD FOREIGN KEY([TeacherID])
REFERENCES [dbo].[Teachers] ([TeacherID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Teachers]  WITH CHECK ADD FOREIGN KEY([AccountID])
REFERENCES [dbo].[Accounts] ([AccountID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Accounts]  WITH CHECK ADD CHECK  (([Role]='Teacher' OR [Role]='Student' OR [Role]='Admin'))
GO
ALTER TABLE [dbo].[ClassRooms]  WITH CHECK ADD CHECK  (([Capacity]>(0)))
GO
