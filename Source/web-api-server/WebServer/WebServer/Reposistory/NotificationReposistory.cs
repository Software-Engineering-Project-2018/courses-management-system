using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using WebServer.Models;

namespace WebServer.Repository
{
    public class NotificationReposistory : BaseReposistory
    {
        //Thêm mới 1 thông báo.
        public Notification InsertNotification(Notification notification)
        {

            //Câu lệnh truy vấn ở dạng string
            string queryString = "INSERT INTO Notification(NotificationId, NotificationName, NotificationDateCreate, NotificationCreatorName, NotificationContent, NotificationType, CourseId) VALUES" +
                                 "(@NotificationId, @NotificationName, @NotificationDateCreate, @NotificationCreatorName,@NotificationContent, @NotificationType, @CourseId);";

            //Mở kết nối đến database
            using (SqlConnection connection =
                new SqlConnection(this.ConnectionString))
            {
                // Khởi tạo command với các tham số truyền vào là các trường trong đối tượng Notification
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@NotificationId", notification.NotificationId);
                command.Parameters.AddWithValue("@NotificationName", notification.NotificationName);
                command.Parameters.AddWithValue("@NotificationDateCreate", notification.NotificationDateCreate);
                command.Parameters.AddWithValue("@NotificationCreatorName", notification.NotificationCreatorName);
                command.Parameters.AddWithValue("@NotificationContent", notification.NotificationContent);
                command.Parameters.AddWithValue("@NotificationType", notification.NotificationType);
                command.Parameters.AddWithValue("@CourseId", notification.CourseId);
                //Mở kết nối và thực hiện query vào database
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                //Đọc kết quả trả về
                while (reader.Read())
                {
                    //Lấy notificationId sau khi Create xong
                    notification.NotificationId = Convert.ToInt64(reader.GetValue(0).ToString());
                }
                reader.Close();
                connection.Close();
            }

            return notification;
        }

        //Hàm sửa đổi thông tin thông báo.
        public Notification UpdateNotification(Notification notification)
        {
            string queryString = "UPDATE Notification SET NotificationName = @notificationName, NotificationDateCreate =  @notificationDateCreate, NotificationCreatorName = @notificationCreatorName, NotificationContent = @notificationContent, NotificationType = @notificationType, CourseId = @courseId "
                               + "  WHERE NotificationId = @notificationId"; 
            //Mở kết nối đến database
            using (SqlConnection connection =
                new SqlConnection(this.ConnectionString))
            {
                // Khởi tạo command với các tham số truyền vào là các trường trong đối tượng Notification
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@NotificationId", notification.NotificationId);
                command.Parameters.AddWithValue("@NotificationName", notification.NotificationName);
                command.Parameters.AddWithValue("@NotificationDateCreate", notification.NotificationDateCreate);
                command.Parameters.AddWithValue("@NotificationCreatorName", notification.NotificationCreatorName);
                command.Parameters.AddWithValue("@NotificationContent", notification.NotificationContent);
                command.Parameters.AddWithValue("@NotificationType", notification.NotificationType);
                command.Parameters.AddWithValue("@CourseId", notification.CourseId);
                //Mở kết nối và thực hiện query vào database
                connection.Open();
                command.ExecuteNonQuery(); //Không có giá trị trả về: dùng ExecuteNonQuery

                //Đóng kết nối
                connection.Close();
            }

            //Trả về chính tham số truyền vào nếu hàm không xảy ra bất cứ lỗi gì
            return notification;
        }

        //Lấy danh sách tất cả thông báo chung.
        public List<Notification> GetAllGeneralNotification(string searchKeyword)
        {
            //Giá trị trả về của hàm này: List<Notification>
            List<Notification> queryResult = new List<Notification>();

            //Cấu lệnh truy vấn ở dạng string
            string queryString = "SELECT * FROM Notification WHERE NotificationType = 1 AND NotificationName like '%' + @searchKeyword + '%'";

            //Mở kết nối đến database
            using (SqlConnection connection =
                new SqlConnection(this.ConnectionString))
            {
                // Khởi tạo command có tham số nào truyền vào là từ khóa tìm kiếm
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@searchKeyword", string.IsNullOrEmpty(searchKeyword) ? "" : searchKeyword);
                //Mở kết nối và thực hiện query vào database
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                //Đọc dữ liệu trả về từ truy vấn ở trên
                while (reader.Read())
                {
                    //Tạo biến tạm để lấy đọc giá trị và sau dó thêm vào List queryResult
                    Notification entity = new Notification();

                    //Lấy từng cột đọc được lưu vào entity
                    if (reader["NotificationId"] != DBNull.Value)
                    {
                        entity.NotificationId = (long)reader["NotificationId"];
                    }
                    if (reader["NotificationName"] != DBNull.Value)
                    {
                        entity.NotificationName = (string)reader["NotificationName"];
                    }
                    if (reader["NotificationDateCreate"] != DBNull.Value)
                    {
                        entity.NotificationDateCreate = (DateTime)reader["NotificationDateCreate"];
                    }
                    if (reader["NotificationCreatorName"] != DBNull.Value)
                    {
                        entity.NotificationCreatorName = (string)reader["NotificationCreatorname"];
                    }
                    if (reader["NotificationContent"] != DBNull.Value)
                    {
                        entity.NotificationContent = (string)reader["NotificationContent"];
                    }
                    if (reader["NotificationType"] != DBNull.Value)
                    {
                        entity.NotificationType = (long)reader["NotificationType"];
                    }
                    if (reader["CourseId"] != DBNull.Value)
                    {
                        entity.CourseId = (long)reader["CourseId"];
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

        //Lấy danh sách tất cả thông báo từ khóa học mà học sinh tham gia.
        public List<Notification> GetAllCourseNotification(string searchKeyword, long studentId)
        {
            //Giá trị trả về của hàm này: List<Notification>
            List<Notification> queryResult = new List<Notification>();

            //Cấu lệnh truy vấn ở dạng string
            string queryString = "SELECT nt.* FROM Notification nt JOIN CourseStudentDetail csd ON nt.CourseId = csd.CourseId WHERE NotificationType = 2 AND csd.StudentId = @studentId AND nt.NotificationName like '%' + @searchKeyword + '%'";

            //Mở kết nối đến database
            using (SqlConnection connection =
                new SqlConnection(this.ConnectionString))
            {
                // Khởi tạo command có tham số nào truyền vào là từ khóa tìm kiếm
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@searchKeyword", string.IsNullOrEmpty(searchKeyword) ? "" : searchKeyword);
                command.Parameters.AddWithValue("@studentId", studentId);
                //Mở kết nối và thực hiện query vào database
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                //Đọc dữ liệu trả về từ truy vấn ở trên
                while (reader.Read())
                {
                    //Tạo biến tạm để lấy đọc giá trị và sau dó thêm vào List queryResult
                    Notification entity = new Notification();

                    //Lấy từng cột đọc được lưu vào entity
                    if (reader["NotificationId"] != DBNull.Value)
                    {
                        entity.NotificationId = (long)reader["NotificationId"];
                    }
                    if (reader["NotificationName"] != DBNull.Value)
                    {
                        entity.NotificationName = (string)reader["NotificationName"];
                    }
                    if (reader["NotificationDateCreate"] != DBNull.Value)
                    {
                        entity.NotificationDateCreate = (DateTime)reader["NotificationDateCreate"];
                    }
                    if (reader["NotificationCreatorName"] != DBNull.Value)
                    {
                        entity.NotificationCreatorName = (string)reader["NotificationCreatorname"];
                    }
                    if (reader["NotificationContent"] != DBNull.Value)
                    {
                        entity.NotificationContent = (string)reader["NotificationContent"];
                    }
                    if (reader["NotificationType"] != DBNull.Value)
                    {
                        entity.NotificationType = (long)reader["NotificationType"];
                    }
                    if (reader["CourseId"] != DBNull.Value)
                    {
                        entity.CourseId = (long)reader["CourseId"];
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

        //Hàm lấy 1 thông báo  Id
        public Notification GetOneNotificationById(long notificationId)
        {
            //Giá trị trả về của hàm này
            Notification queryResult = new Notification();

            //Câu lệnh truy vấn ở dạng string
            string queryString = "SELECT * FROM Notification WHERE NotificationId = @notificationId";

            //Mở kết nối đến database
            using (SqlConnection connection =
                new SqlConnection(this.ConnectionString))
            {
                // Khởi tạo command với tham số truyền vào là DocumentDetailId
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@notificationId", notificationId);

                //Mở kết nối và thực hiện query vào database
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                //Đọc dữ liệu trả về từ truy vấn ở trên
                while (reader.Read())
                {
                    //Lấy từng cột đọc được lưu vào queryResult
                    if (reader["NotificationId"] != DBNull.Value)
                    {
                        queryResult.NotificationId = (long)reader["NotificationId"];
                    }
                    if (reader["NotificationName"] != DBNull.Value)
                    {
                        queryResult.NotificationName = (string)reader["NotificationName"];
                    }
                    if (reader["NotificationDateCreate"] != DBNull.Value)
                    {
                        queryResult.NotificationDateCreate = (DateTime)reader["NotificationDateCreate"];
                    }
                    if (reader["NotificationCreatorName"] != DBNull.Value)
                    {
                        queryResult.NotificationCreatorName = (string)reader["NotificationCreatorname"];
                    }
                    if (reader["NotificationContent"] != DBNull.Value)
                    {
                        queryResult.NotificationContent = (string)reader["NotificationContent"];
                    }
                    if (reader["NotificationType"] != DBNull.Value)
                    {
                        queryResult.NotificationType = (long)reader["NotificationType"];
                    }
                    if (reader["CourseId"] != DBNull.Value)
                    {
                        queryResult.CourseId = (long)reader["CourseId"];
                    }

                }
                //Đóng kết nối
                reader.Close();
                connection.Close();

                //Trả về kết quả
                return queryResult;
            }
        }

        //Hàm xóa thông báo ra khỏi danh sách
        public long DeleteNotificationById(long notificationId)
        {
            // Hàm trả về NotificationId

            //Cấu lệnh truy vấn ở dạng string
            string queryString = "DELETE FROM Notification WHERE NotificationId = @notificationId";

            //Mở kết nối đến database
            using (SqlConnection connection =
                new SqlConnection(this.ConnectionString))
            {
                // Khởi tạo command với tham số truyền vào là taskDetailId
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@notificationId", notificationId);

                //Mở kết nối và thực hiện query vào database
                connection.Open();
                command.ExecuteNonQuery(); //Không có giá trị trả về: dùng ExecuteNonQuery

                //Đóng kết nối
                connection.Close();
            }

            // Hàm trả về notificationId
            return notificationId;
        }
    }
}