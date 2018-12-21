--FK_Parent_Student
IF OBJECT_ID('FK_Parent_Student') IS NOT NULL
BEGIN
	ALTER TABLE [dbo].[Parent] DROP CONSTRAINT [FK_Parent_Student]
END
ALTER TABLE [dbo].[Parent]  WITH CHECK ADD CONSTRAINT [FK_Parent_Student] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Student] ([UserId])
ON UPDATE CASCADE
ON DELETE CASCADE

--FK_CourseStudentDetail_Student
IF OBJECT_ID('FK_CourseStudentDetail_Student') IS NOT NULL
BEGIN
	ALTER TABLE [dbo].[CourseStudentDetail] DROP CONSTRAINT [FK_CourseStudentDetail_Student]
END
ALTER TABLE [dbo].[CourseStudentDetail]  WITH CHECK ADD CONSTRAINT [FK_CourseStudentDetail_Student] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Student] ([UserId])
ON UPDATE CASCADE
ON DELETE CASCADE

--FK_CourseStudentDetail_Course
IF OBJECT_ID('FK_CourseStudentDetail_Course') IS NOT NULL
BEGIN
	ALTER TABLE [dbo].[CourseStudentDetail] DROP CONSTRAINT [FK_CourseStudentDetail_Course]
END
ALTER TABLE [dbo].[CourseStudentDetail]  WITH CHECK ADD CONSTRAINT [FK_CourseStudentDetail_Course] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Course] ([CourseId])
ON UPDATE CASCADE
ON DELETE CASCADE

--FK_CourseTeacherDetail_Teacher
IF OBJECT_ID('FK_CourseTeacherDetail_Teacher') IS NOT NULL
BEGIN
	ALTER TABLE [dbo].[CourseTeacherDetail] DROP CONSTRAINT [FK_CourseTeacherDetail_Teacher]
END
ALTER TABLE [dbo].[CourseTeacherDetail]  WITH CHECK ADD CONSTRAINT [FK_CourseTeacherDetail_Teacher] FOREIGN KEY([TeacherId])
REFERENCES [dbo].[Teacher] ([UserId])
ON UPDATE CASCADE
ON DELETE CASCADE

--FK_CourseStudentDetail_Course
IF OBJECT_ID('FK_CourseTeacherDetail_Course') IS NOT NULL
BEGIN
	ALTER TABLE [dbo].[CourseTeacherDetail] DROP CONSTRAINT [FK_CourseTeacherDetail_Course]
END
ALTER TABLE [dbo].[CourseTeacherDetail]  WITH CHECK ADD CONSTRAINT [FK_CourseTeacherDetail_Course] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Course] ([CourseId])
ON UPDATE CASCADE
ON DELETE CASCADE

--FK_Task_Course
IF OBJECT_ID('FK_Task_Course') IS NOT NULL
BEGIN
	ALTER TABLE [dbo].[Task] DROP CONSTRAINT [FK_Task_Course]
END
ALTER TABLE [dbo].[Task]  WITH CHECK ADD CONSTRAINT [FK_Task_Course] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Course] ([CourseId])
ON UPDATE CASCADE
ON DELETE CASCADE

--FK_TaskDetail_Student
IF OBJECT_ID('FK_TaskDetail_Student') IS NOT NULL
BEGIN
	ALTER TABLE [dbo].[TaskDetail] DROP CONSTRAINT [FK_TaskDetail_Student]
END
ALTER TABLE [dbo].[TaskDetail]  WITH CHECK ADD CONSTRAINT [FK_TaskDetail_Student] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Student] ([UserId])
ON UPDATE CASCADE
ON DELETE CASCADE

--FK_TaskDetail_Task
IF OBJECT_ID('FK_TaskDetail_Task') IS NOT NULL
BEGIN
	ALTER TABLE [dbo].[TaskDetail] DROP CONSTRAINT [FK_TaskDetail_Task]
END
ALTER TABLE [dbo].[TaskDetail]  WITH CHECK ADD CONSTRAINT [FK_TaskDetail_Task] FOREIGN KEY([TaskId])
REFERENCES [dbo].[Task] ([TaskId])
ON UPDATE CASCADE
ON DELETE CASCADE

--FK_DocumentDetail_Course
IF OBJECT_ID('FK_DocumentDetail_Course') IS NOT NULL
BEGIN
	ALTER TABLE [dbo].[DocumentDetail] DROP CONSTRAINT [FK_DocumentDetail_Course]
END
ALTER TABLE [dbo].[DocumentDetail]  WITH CHECK ADD CONSTRAINT [FK_DocumentDetail_Course] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Course] ([CourseId])
ON UPDATE CASCADE
ON DELETE CASCADE

--FK_DocumentDetail_Teacher
IF OBJECT_ID('FK_DocumentDetail_Teacher') IS NOT NULL
BEGIN
	ALTER TABLE [dbo].[DocumentDetail] DROP CONSTRAINT [FK_DocumentDetail_Teacher]
END
ALTER TABLE [dbo].[DocumentDetail]  WITH CHECK ADD CONSTRAINT [FK_DocumentDetail_Teacher] FOREIGN KEY([TeacherId])
REFERENCES [dbo].[Teacher] ([UserId])
ON UPDATE CASCADE
ON DELETE CASCADE

--FK_Notification_Course
IF OBJECT_ID('FK_Notification_Course') IS NOT NULL
BEGIN
	ALTER TABLE [dbo].[Notification] DROP CONSTRAINT [FK_Notification_Course]
END
ALTER TABLE [dbo].[Notification]  WITH CHECK ADD CONSTRAINT [FK_Notification_Course] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Course] ([CourseId])
ON UPDATE CASCADE
ON DELETE CASCADE