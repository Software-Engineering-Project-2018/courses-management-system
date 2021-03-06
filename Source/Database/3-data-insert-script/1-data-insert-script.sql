USE [CoursesSystem]

GO

/*Table Student*/
INSERT INTO Student (IdentificationCode, UserPw, UserName, UserFullName, UserDob, UserGender, UserAddress, UserMobile, UserEmail ,UserType)
VALUES('1111111', 'student', N'admin', N'Administrator', CAST(N'1998-1-1' AS Date), 1, '', '', '', 3);
INSERT INTO Student (IdentificationCode, UserPw, UserName, UserFullName, UserDob, UserGender, UserAddress, UserMobile, UserEmail ,UserType)
VALUES('1612085', 'student', 'truongthanhdanh', N'Trương Thành Danh', CAST(N'1998-07-10' AS Date), 1, '', '', '', 3);
INSERT INTO Student (IdentificationCode, UserPw, UserName, UserFullName, UserDob, UserGender, UserAddress, UserMobile, UserEmail ,UserType)
VALUES('1612597', 'student', 'huynhduytan', N'Huỳnh Duy Tân', CAST(N'1998-10-10' AS Date), 1, '', '', '', 3);
INSERT INTO Student (IdentificationCode, UserPw, UserName, UserFullName, UserDob, UserGender, UserAddress, UserMobile, UserEmail ,UserType)
VALUES('1612602', 'student', N'nguyenquangthach', N'Nguyễn Quang Thạch', CAST(N'1998-01-16' AS Date), 1, '', '', '', 3);
INSERT INTO Student (IdentificationCode, UserPw, UserName, UserFullName, UserDob, UserGender, UserAddress, UserMobile, UserEmail ,UserType)
VALUES('1612647', 'student', N'levanthi', N'Lê Văn Thi', CAST(N'1998-04-17' AS Date), 1, '', '', '', 3);
INSERT INTO Student (IdentificationCode, UserPw, UserName, UserFullName, UserDob, UserGender, UserAddress, UserMobile, UserEmail ,UserType)
VALUES('1612806', 'student', N'lamkhangvi', N'Lâm Khang Vỉ', CAST(N'1998-02-20' AS Date), 1, '', '', '', 3);

GO
/*Table */
INSERT INTO Parent(UserPw, UserName, UserFullName, UserDob, UserGender, UserAddress, UserMobile, UserEmail, StudentId ,UserType)
VALUES('parent', 'thanhdanhtruongparent', N'Thành Danh Trương Parent', CAST(N'1997-07-10' AS Date), 1, '','','',1 , 4)
INSERT INTO Parent(UserPw, UserName, UserFullName, UserDob, UserGender, UserAddress, UserMobile, UserEmail, StudentId ,UserType)
VALUES('parent', 'huynhduytanparent', N'Huỳnh Duy Tân Parent', CAST(N'1997-07-10' AS Date), 1, '','','',1 , 4)
INSERT INTO Parent(UserPw, UserName, UserFullName, UserDob, UserGender, UserAddress, UserMobile, UserEmail, StudentId ,UserType)
VALUES('parent', 'nguyenquangthachparent', N'Nguyễn Quang Thạch Parent', CAST(N'1997-07-10' AS Date), 1, '','','',1 , 4)
INSERT INTO Parent(UserPw, UserName, UserFullName, UserDob, UserGender, UserAddress, UserMobile, UserEmail, StudentId ,UserType)
VALUES('parent', 'levanthiparent', N'Lê Văn Thi Parent', CAST(N'1997-07-10' AS Date), 1, '','','',1 , 4)
INSERT INTO Parent(UserPw, UserName, UserFullName, UserDob, UserGender, UserAddress, UserMobile, UserEmail, StudentId ,UserType)
VALUES('parent', 'lamkhangviparent', N'Lâm Khang Vỉ Parent', CAST(N'1997-07-10' AS Date), 1, '','','',1 , 4)

/*Table Teacher*/
INSERT INTO Teacher(IdentificationCode, UserPw, UserName, UserFullName, UserDob, UserGender, UserAddress, UserMobile, UserEmail, UserType)
 VALUES('TC001', 'teacher', 'trantrungdung', N'Trần Trung Dũng', null, 2, '', '', '', 2)
INSERT INTO Teacher(IdentificationCode, UserPw, UserName, UserFullName, UserDob, UserGender, UserAddress, UserMobile, UserEmail, UserType)
 VALUES('TC002', 'teacher', 'nguyenthiminhtuyen', N'Nguyễn Thị Minh Tuyền', null, 2, '', '', '', 2)
INSERT INTO Teacher(IdentificationCode, UserPw, UserName, UserFullName, UserDob, UserGender, UserAddress, UserMobile, UserEmail, UserType)
 VALUES('TC003', 'teacher', 'truongtoanthinh', N'Trương Toàn Thịnh', null, 2, '', '', '', 2)
INSERT INTO Teacher(IdentificationCode, UserPw, UserName, UserFullName, UserDob, UserGender, UserAddress, UserMobile, UserEmail, UserType)
 VALUES('TC004', 'teacher', 'nguyenanhthi', N'Nguyễn Anh Thi', null, 2, '', '', '', 2)

/*Table Manager*/
INSERT INTO MANAGER (UserPw, UserName, UserFullName, UserDob, UserGender, UserAddress, UserMobile, UserEmail, UserType)
 VALUES('admin', N'admin','Administrator', null, 1, '', '', '', 1)
INSERT INTO MANAGER (UserPw, UserName, UserFullName, UserDob, UserGender, UserAddress, UserMobile, UserEmail, UserType)
 VALUES('admin', N'admin1','Administrator1', null, 1, '', '', '', 1)
INSERT INTO MANAGER (UserPw, UserName, UserFullName, UserDob, UserGender, UserAddress, UserMobile, UserEmail, UserType)
 VALUES('admin', N'admin2','Administrator2', null, 1, '', '', '', 1)

/*Table Course*/
INSERT INTO COURSE (CourseName, DateStart, DateEnd, Tutition)
VALUES(N'Hệ điều hành 16/31 Học kì 1 2018-2019', CAST(N'2018-09-15' AS Date), CAST(N'2018-12-24' AS Date), 5000000)
INSERT INTO COURSE (CourseName, DateStart, DateEnd, Tutition)
VALUES(N'Hệ điều hành 16/32 Học kì 1 2018-2019', CAST(N'2018-09-15' AS Date), CAST(N'2018-12-24' AS Date), 5000000)
INSERT INTO COURSE (CourseName, DateStart, DateEnd, Tutition)
VALUES(N'Nhập môn công nghệ phần mềm 16/31 Học kì 1 2018-2019', CAST(N'2018-09-15' AS Date), CAST(N'2018-12-24' AS Date), 5000000)
