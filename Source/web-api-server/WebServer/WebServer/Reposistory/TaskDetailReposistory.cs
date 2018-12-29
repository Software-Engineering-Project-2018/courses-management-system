using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using WebServer.Models;

namespace WebServer.Repository
{
    public class TaskDetailReposistory : BaseReposistory
    {
        //Thêm mới 1 bài tập chi tiết.
        public TaskDetail InsertTaskDetail(TaskDetail taskdetail)
        {
            taskdetail.TaskSubmissionState = true;

            //Câu lệnh truy vấn ở dạng string
            string queryString = "INSERT INTO TaskDetail(StudentId, TaskId, TaskFileUpload, TaskSubmissionState, TaskScore) VALUES" +
                                 "(@studentId, @taskId, @taskFileUpload, @taskSubmissionState, @taskScore); SELECT @@IDENTITY";

            //Mở kết nối đến database
            using (SqlConnection connection =
                new SqlConnection(this.ConnectionString))
            {
                // Khởi tạo command với các tham số truyền vào là các trường trong đối tượng TaskDetail
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@studentId", taskdetail.Student.UserId);
                command.Parameters.AddWithValue("@taskId", taskdetail.Task.TaskId);
                command.Parameters.AddWithValue("@taskFileUpload", string.IsNullOrEmpty(taskdetail.TaskFileUpload)
                    ? (object)DBNull.Value : taskdetail.TaskFileUpload);
                command.Parameters.AddWithValue("@taskSubmissionState", taskdetail.TaskSubmissionState);
                command.Parameters.AddWithValue("@taskScore", taskdetail.TaskScore == null ? (object)DBNull.Value : taskdetail.TaskScore);
                //Mở kết nối và thực hiện query vào database
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                //Đọc kết quả trả về
                while (reader.Read())
                {
                    //Lấy taskDetailID sau khi Create xong
                    taskdetail.TaskDetailId = Convert.ToInt64(reader.GetValue(0).ToString());
                }
                reader.Close();
                connection.Close();
            }

            return taskdetail;
        }

        //Hàm sửa đổi thông tin chi tiết của bài tập.
        public TaskDetail UpdateTaskDetail(TaskDetail taskdetail)
        {
            string queryString = "UPDATE TaskDetail SET StudentId = @studentId, TaskId = @taskId, TaskFileUpload = @taskFileUpload, TaskSubmissionState = @taskSubmissionState, TaskScore = @taskScore "
                               + "  WHERE TakeDetailId = @takeDetailId";
            //Mở kết nối đến database
            using (SqlConnection connection =
                new SqlConnection(this.ConnectionString))
            {
                // Khởi tạo command với các tham số truyền vào là các trường trong đối tượng TaskDetail
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@taskDetailId", taskdetail.TaskDetailId);
                command.Parameters.AddWithValue("@studentId", taskdetail.Student.UserId);
                command.Parameters.AddWithValue("@taskId", taskdetail.Task.TaskId);
                command.Parameters.AddWithValue("@taskFileUpload", string.IsNullOrEmpty(taskdetail.TaskFileUpload)
                    ? (object)DBNull.Value : taskdetail.TaskFileUpload);
                command.Parameters.AddWithValue("@taskSubmission", taskdetail.TaskSubmissionState);
                command.Parameters.AddWithValue("@taskScore", taskdetail.TaskScore == null ? (object)DBNull.Value : taskdetail.TaskScore);
                //Mở kết nối và thực hiện query vào database
                connection.Open();
                command.ExecuteNonQuery(); //Không có giá trị trả về: dùng ExecuteNonQuery

                //Đóng kết nối
                connection.Close();
            }

            //Trả về chính tham số truyền vào nếu hàm không xảy ra bất cứ lỗi gì
            return taskdetail;
        }

        //Lấy danh sách chi tiết tất cả bài tập.
        public List<TaskDetail> GetAllTaskDetailByTaskAndStudent(long taskId, long studentId)
        {
            //Giá trị trả về của hàm này: List<TaskDetail>
            List<TaskDetail> queryResult = new List<TaskDetail>();

            //Cấu lệnh truy vấn ở dạng string
            string queryString = "SELECT * FROM TaskDetail WHERE TaskId = @taskId AND StudentId = @studentId";

            //Mở kết nối đến database
            using (SqlConnection connection =
                new SqlConnection(this.ConnectionString))
            {
                // Khởi tạo command có tham số nào truyền vào là từ khóa tìm kiếm
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@taskId", taskId);
                command.Parameters.AddWithValue("@studentId", studentId);
                //Mở kết nối và thực hiện query vào database
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                //Đọc dữ liệu trả về từ truy vấn ở trên
                while (reader.Read())
                {
                    //Tạo biến tạm để lấy đọc giá trị và sau dó thêm vào List queryResult
                    TaskDetail entity = new TaskDetail();

                    //Lấy từng cột đọc được lưu vào entity
                    if (reader["TaskDetailId"] != DBNull.Value)
                    {
                        entity.TaskDetailId = (long)reader["TaskDetailId"];
                    }
                    if (reader["StudentId"] != DBNull.Value)
                    {
                        entity.Student.UserId = (long)reader["StudentId"];
                    }
                    if (reader["TaskId"] != DBNull.Value)
                    {
                        entity.Task.TaskId = (long)reader["TaskId"];
                    }
                    if (reader["TaskFileUpload"] != DBNull.Value)
                    {
                        entity.TaskFileUpload = (string)reader["TaskFileUpload"];
                    }
                    if (reader["TaskSubmissionState"] != DBNull.Value)
                    {
                        entity.TaskSubmissionState = (bool)reader["TaskSubmissionState"];
                    }
                    if (reader["TaskScore"] != DBNull.Value)
                    {
                        entity.TaskScore = (long)reader["TaskScore"];
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

        //Hàm lấy 1 thông tin bài tập theo Id
        public TaskDetail GetOneTaskDetailById(long taskDetailId)
        {
            //Giá trị trả về của hàm này
            TaskDetail queryResult = new TaskDetail();

            //Câu lệnh truy vấn ở dạng string
            string queryString = "SELECT * FROM TaskDetail WHERE TaskDetailId = @taskDetailId";

            //Mở kết nối đến database
            using (SqlConnection connection =
                new SqlConnection(this.ConnectionString))
            {
                // Khởi tạo command với tham số truyền vào là TaskDetailId
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@taskDetailId", taskDetailId);

                //Mở kết nối và thực hiện query vào database
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                //Đọc dữ liệu trả về từ truy vấn ở trên
                while (reader.Read())
                {
                    //Lấy từng cột đọc được lưu vào queryResult
                    if (reader["TaskDetailId"] != DBNull.Value)
                    {
                        queryResult.TaskDetailId = (long)reader["TaskDetailId"];
                    }
                    if (reader["StudentId"] != DBNull.Value)
                    {
                        queryResult.Student.UserId = (long)reader["StudentId"];
                    }
                    if (reader["TaskId"] != DBNull.Value)
                    {
                        queryResult.Task.TaskId = (long)reader["TaskId"];
                    }
                    if (reader["TaskFileUpload"] != DBNull.Value)
                    {
                        queryResult.TaskFileUpload = (string)reader["TaskFileUpload"];
                    }
                    if (reader["TaskSubmissionState"] != DBNull.Value)
                    {
                       queryResult.TaskSubmissionState = (Boolean)reader["TaskSubmissionState"];
                    }
                    if (reader["TaskScore"] != DBNull.Value)
                    {
                        queryResult.TaskScore = (long)reader["TaskScore"];
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
        public long DeleteTaskDetailById(long taskDetailId)
        {
            // Hàm trả về TaskDetailId

            //Cấu lệnh truy vấn ở dạng string
            string queryString = "DELETE FROM TaskDetail WHERE TaskDetailId = @taskDetailId";

            //Mở kết nối đến database
            using (SqlConnection connection =
                new SqlConnection(this.ConnectionString))
            {
                // Khởi tạo command với tham số truyền vào là taskDetailId
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@taskDetailId", taskDetailId);

                //Mở kết nối và thực hiện query vào database
                connection.Open();
                command.ExecuteNonQuery(); //Không có giá trị trả về: dùng ExecuteNonQuery

                //Đóng kết nối
                connection.Close();
            }

            // Hàm trả về taskDetailId
            return taskDetailId;
        }
    }
}