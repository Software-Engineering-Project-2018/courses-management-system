using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using WebServer.Models;

namespace WebServer.Repository
{
    public class TaskReposistory : BaseReposistory
    {
        //Thêm mới 1 bài tập.
        public Task InsertTask(Task task)
        {

            //Câu lệnh truy vấn ở dạng string
            string queryString = "INSERT INTO Task(TaskId, TaskName, CourseId, TaskDescripsion, TaskContent, TaskDateStart, TaskDeadline, TaskDateSubmission) VALUES" +
                                 "(@taskId, @taskName, @courseId, @taskDescripsion, @taskContent, @taskDateStart, @taskDeadline, @taskDateSubmission);";

            //Mở kết nối đến database
            using (SqlConnection connection =
                new SqlConnection(this.ConnectionString))
            {
                // Khởi tạo command với các tham số truyền vào là các trường trong đối tượng Task
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@taskId", task.TaskId);
                command.Parameters.AddWithValue("@taskName", task.TaskName);
                command.Parameters.AddWithValue("@taskCourseId", task.CourseId);
                command.Parameters.AddWithValue("@taskDescripsion", task.TaskDescription);
                command.Parameters.AddWithValue("@taskContent", task.TaskContent);
                command.Parameters.AddWithValue("@taskDateStart", task.TaskDateStart);
                command.Parameters.AddWithValue("@taskDeadline", task.TaskDeadline);
                command.Parameters.AddWithValue("@taskDateSubmission", task.TaskDateSubmission);
                //Mở kết nối và thực hiện query vào database
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                //Đọc kết quả trả về
                while (reader.Read())
                {
                    //Lấy courseID sau khi Create xong
                    task.TaskId = Convert.ToInt64(reader.GetValue(0).ToString());
                }
                reader.Close();
                connection.Close();
            }

            return task;
        }

        //Hàm sửa đổi thông tin của bài tập.
        public Task UpdateTask(Task task)
        {
            string queryString = "UPDATE Task SET TaskName = @taskName, CourseId = @courseId, TaskDescripsion = @taskDescripsion, TaskContent = @taskContent, TaskDateStart = @taskDateStart, TaskDeadline = @taskDeadline,TaskDateSubmission = @taskDateSubmission "
                               + "  WHERE TakeId = @takeId";
            //Mở kết nối đến database
            using (SqlConnection connection =
                new SqlConnection(this.ConnectionString))
            {
                // Khởi tạo command với các tham số truyền vào là các trường trong đối tượng Task
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@taskId", task.TaskId);
                command.Parameters.AddWithValue("@taskName", task.TaskName);
                command.Parameters.AddWithValue("@taskCourseId", task.CourseId);
                command.Parameters.AddWithValue("@taskDescripsion", task.TaskDescription);
                command.Parameters.AddWithValue("@taskContent", task.TaskContent);
                command.Parameters.AddWithValue("@taskDateStart", task.TaskDateStart);
                command.Parameters.AddWithValue("@taskDeadline", task.TaskDeadline);
                command.Parameters.AddWithValue("@taskDateSubmission", task.TaskDateSubmission);
                //Mở kết nối và thực hiện query vào database
                connection.Open();
                command.ExecuteNonQuery(); //Không có giá trị trả về: dùng ExecuteNonQuery

                //Đóng kết nối
                connection.Close();
            }

            //Trả về chính tham số truyền vào nếu hàm không xảy ra bất cứ lỗi gì
            return task;
        }

        //Lấy danh sách tất cả bài tập.
        public List<Task> GetAllTask(string searchKeyword)
        {
            //Giá trị trả về của hàm này: List<Task>
            List<Task> queryResult = new List<Task>();

            //Cấu lệnh truy vấn ở dạng string
            string queryString = "SELECT * FROM Task WHERE TaskName like '%' + @searchKeyword + '%'";

            //Mở kết nối đến database
            using (SqlConnection connection =
                new SqlConnection(this.ConnectionString))
            {
                // Khởi tạo command có tham số nào truyền vào là từ khóa tìm kiếm
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@searchKeyword", searchKeyword);

                //Mở kết nối và thực hiện query vào database
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                //Đọc dữ liệu trả về từ truy vấn ở trên
                while (reader.Read())
                {
                    //Tạo biến tạm để lấy đọc giá trị và sau dó thêm vào List queryResult
                    Task entity = new Task();

                    //Lấy từng cột đọc được lưu vào entity
                    if (reader["TaskId"] != DBNull.Value)
                    {
                        entity.TaskId = (long)reader["TaskId"];
                    }
                    if (reader["TaskName"] != DBNull.Value)
                    {
                        entity.TaskName = (string)reader["TaskName"];
                    }
                    if (reader["CourseId"] != DBNull.Value)
                    {
                        entity.CourseId = (long)reader["CourseId"];
                    }
                    if (reader["TaskDescripsion"] != DBNull.Value)
                    {
                        entity.TaskDescription = (string)reader["TaskDescripsion"];
                    }
                    if (reader["TaskContent"] != DBNull.Value)
                    {
                        entity.TaskContent = (string)reader["TaskContent"];
                    }
                    if (reader["TaskDateStart"] != DBNull.Value)
                    {
                        entity.TaskDateStart = (DateTime)reader["TaskDateStart"];
                    }
                    if (reader["TaskDeadline"] != DBNull.Value)
                    {
                        entity.TaskDeadline = (DateTime)reader["TaskDeadline"];
                    }
                    if (reader["TaskDateSubmission"] != DBNull.Value)
                    {
                        entity.TaskDateSubmission = (DateTime)reader["TaskDateSubmission"];
                    }

                    //Thêm entity vào list trả về
                    queryResult.Add(entity);
                }

                //Đóng kết nối
                reader.Close();
                connection.Close();
            }

            //Trả về kết quả
            return queryResult;
        }

        //Hàm lấy 1 bài tập theo Id
        public Task GetOneTaskById(long taskId)
        {
            //Giá trị trả về của hàm này
            Task queryResult = new Task();

            //Câu lệnh truy vấn ở dạng string
            string queryString = "SELECT * FROM Task WHERE TaskId = @taskId";

            //Mở kết nối đến database
            using (SqlConnection connection =
                new SqlConnection(this.ConnectionString))
            {
                // Khởi tạo command với tham số truyền vào là TaskId
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@taskId", taskId);

                //Mở kết nối và thực hiện query vào database
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                //Đọc dữ liệu trả về từ truy vấn ở trên
                while (reader.Read())
                {
                    //Lấy từng cột đọc được lưu vào queryResult
                    if (reader["TaskId"] != DBNull.Value)
                    {
                        queryResult.TaskId = (long)reader["TaskId"];
                    }
                    if (reader["TaskName"] != DBNull.Value)
                    {
                       queryResult.TaskName = (string)reader["TaskName"];
                    }
                    if (reader["CourseId"] != DBNull.Value)
                    {
                       queryResult.CourseId = (long)reader["CourseId"];
                    }
                    if (reader["TaskDescripsion"] != DBNull.Value)
                    {
                        queryResult.TaskDescription = (string)reader["TaskDescripsion"];
                    }
                    if (reader["TaskContent"] != DBNull.Value)
                    {
                        queryResult.TaskContent = (string)reader["TaskContent"];
                    }
                    if (reader["TaskDateStart"] != DBNull.Value)
                    {
                        queryResult.TaskDateStart = (DateTime)reader["TaskDateStart"];
                    }
                    if (reader["TaskDeadline"] != DBNull.Value)
                    {
                        queryResult.TaskDeadline = (DateTime)reader["TaskDeadline"];
                    }
                    if (reader["TaskDateSubmission"] != DBNull.Value)
                    {
                        queryResult.TaskDateSubmission = (DateTime)reader["TaskDateSubmission"];
                    }
                    //Đóng kết nối
                    reader.Close();
                    connection.Close();
                }
                //Trả về kết quả
                return queryResult;
            }
        }

        //Hàm xóa thông tin bài tập ra khỏi danh sách
        public long DeleteTaskById(long taskId)
        {
            // Hàm trả về courseId

            //Cấu lệnh truy vấn ở dạng string
            string queryString = "DELETE FROM Task WHERE TaskId = @taskId";

            //Mở kết nối đến database
            using (SqlConnection connection =
                new SqlConnection(this.ConnectionString))
            {
                // Khởi tạo command với tham số truyền vào là courseId
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@taskId", taskId);

                //Mở kết nối và thực hiện query vào database
                connection.Open();
                command.ExecuteNonQuery(); //Không có giá trị trả về: dùng ExecuteNonQuery

                //Đóng kết nối
                connection.Close();
            }

            // Hàm trả về taskId
            return taskId;
        }
    }
}