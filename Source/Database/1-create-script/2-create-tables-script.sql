USE [CoursesSystem]

GO
--userType: 1/2/3/4 
--admin/teacher/student/parent 

--Create Student TABLE
CREATE TABLE Student
(
	UserId bigint IDENTITY(1,1) not null, --IDENTITY(1,1): tự động phát sinh Id không cần phải insert Id khi insert data
	IdentificationCode varchar(8), -- Mã số học sinh vd 1612647
	UserPw nvarchar(100) not null,
	UserName varchar(50) not null, --Tên đăng nhập	
	UserFullName nvarchar(50) not null, --Họ tên đầy đủ
	UserDob date not null,
	UserGender bigint null,
	UserAddress nvarchar(200) null,
	UserMobile varchar(11) null,
	UserEmail varchar(40) null,
	UserAvatar varchar(max) null,
	TotalTutition float null, --Tổng học phí
	TotalinDebt float null, --Tổng nợ
	UserType bigint not null,
	constraint pk_student primary key (UserId),
	constraint c_student_gender check (UserGender in (0, 1, 2)),  --khác/nam/nữ
	constraint c_student_userType check (UserType = 3) --student type
)

--Create Parent TABLE
CREATE TABLE Parent
(
	UserId bigint IDENTITY(1,1) not null,
	UserPw varchar(15) not null,
	UserName varchar(50) not null,
	UserFullName nvarchar(50) not null,
	UserDob date not null,
	UserGender bigint null,
	UserAddress nvarchar(200) null,
	UserMobile varchar(11) null,
	UserEmail varchar(40) null,
	UserAvatar varchar(max) null,
	StudentId bigint not null,	--foreign key
	UserType bigint not null,
	constraint pk_parent primary key (UserId),
	constraint c_parent_gender check (UserGender in (0, 1, 2)),
	constraint c_parent_userType check (UserType = 4)  --parent  type
)

--Create Teacher TABLE
CREATE TABLE Teacher
(
	UserId bigint IDENTITY(1,1) not null,
	IdentificationCode varchar(8), -- Mã số giáo viên
	UserPw varchar(15) not null,
	UserName varchar(50) not null,
	UserFullName nvarchar(50) not null,
	UserDob date null,
	UserGender bigint null,
	UserAddress nvarchar(200) null,
	UserMobile varchar(11) null,
	UserEmail varchar(40) null,
	UserAvatar varchar(max) null,
	UserType bigint not null,
	constraint pk_teacher primary key (UserId),
	constraint c_teacher_gender check (UserGender in (0, 1, 2)),
	constraint c_teacher_userType check (UserType = 2)  --teacher type
)

--Create Manager TABLE
CREATE TABLE Manager
(
	UserId bigint IDENTITY(1,1) not null,
	UserPw varchar(15) not null,
	UserName varchar(50) not null,
	UserFullName nvarchar(50) not null,
	UserDob date null,
	UserGender bigint null,
	UserAddress nvarchar(200) null,
	UserMobile varchar(11) null,
	UserEmail varchar(40) null,
	UserAvatar varchar(max) null,
	UserType bigint not null,
	constraint pk_manager primary key (UserId),
	constraint c_manager_gender check (UserGender in (0, 1, 2)),
	constraint c_manager_userType check (UserType = 1)  --admin type
)

--Create Course TABLE
CREATE TABLE Course
(
	CourseId bigint IDENTITY(1,1) not null,
	CourseName nvarchar(50) not null,
	DateStart date not null,
	DateEnd date not null,
	Tutition float not null, -- học phí
	constraint pk_course primary key (CourseId)
)

--Quản lý khóa học của học sinh, 1 học sinh có thể tham gia nhiều khóa học
--Create CourseDetail TABLE
CREATE TABLE CourseStudentDetail
(
	CourseStudentDetailId bigint IDENTITY(1,1) not null,
	CourseId bigint not null,	--foreign key
	StudentId bigint not null,	--foreign key
	FinalScore float null,
	constraint pk_course_student_detail primary key (CourseStudentDetailId)
)

--Quản lý khóa học của giáo viên, 1 giáo viên có thể tham gia nhiều khóa học, 1 khóa ọc có thể gồm nhiều giáo viên
--Create CourseDetail TABLE
CREATE TABLE CourseTeacherDetail
(
	CourseTeacherDetailId bigint IDENTITY(1,1) not null,
	CourseId bigint not null,	--foreign key
	TeacherId bigint not null,	--foreign key
	constraint pk_course_teacher_detail primary key (CourseTeacherDetailId)
)

--Quản lý danh sách bài tập cho từng khóa học
--Create Task TABLE
CREATE TABLE Task
(
	TaskId bigint IDENTITY(1,1) not null,
	TaskName nvarchar(50) not null,
	CourseId bigint not null,	--foreign key
	TaskDescription nvarchar(300) null,
	TaskContent nvarchar(max) null,
	TaskDateStart datetime not null,
	TaskDeadline datetime not null,
	TaskDateSubmission datetime null,
	constraint pk_task primary key (TaskId)
)

--Quản lý bài tập của học sinh, 1 học sinh hay 1 khóa học có thể gồm nhiều bài tập
--Create TaskDetail TABLE
CREATE TABLE TaskDetail
(
	TaskDetailId bigint IDENTITY(1,1) not null,
	StudentId bigint not null,	--foreign key
	TaskId bigint not null,	--foreign key
	TaskFileUpload varchar(max) null,
	TaskSubmissionState bit not null,
	TaskScore float null,
	constraint pk_task_detail primary key (TaskDetailId)
)

--Quản lý tài liệu của giáo viên, 1 khóa học hay 1 giáo viên có thể quản lý nhiều tài tiệu
--Create TaskDetail TABLE
CREATE TABLE DocumentDetail
(
	DocumentDetailId bigint IDENTITY(1,1) not null,
	CourseId bigint not null,	--foreign key
	TeacherId bigint not null,	--foreign key
	DocumentDetailFileUpload varchar(max) null,
	constraint pk_document_detail primary key (DocumentDetailId)
)

--Create Notification TABLE
CREATE TABLE Notification
(
	NotificationId bigint IDENTITY(1,1) not null,
	NotificationName nvarchar(50) not null,
	NotificationDateCreate datetime not null,
	NotificationCreatorName datetime not null,
	NotificationContent nvarchar(max) null,
	NotificationType bigint not null,
	CourseId bigint null,	--foreign key. NotificationType là 2 thì lấy dữ liệu từ CourseId, NotificationType là 0 thì không lấy
	constraint pk_notification primary key (NotificationId),
	constraint c_notification_type check (NotificationType in (1, 2)) --thông báo chung/thông báo từ khóa học đã đăng ký
)