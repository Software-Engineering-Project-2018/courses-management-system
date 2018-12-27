using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using WebServer.Models;

namespace WebServer.Repository
{
    public class DocumentDetailReposistory : BaseReposistory
    {
        //Thêm mới 1 tài liệu chi tiết.
        public DocumentDetail InsertDocumentDetail(DocumentDetail documentdetail)
        {

            //Câu lệnh truy vấn ở dạng string
            string queryString = "INSERT INTO DocumentDetail(DocumentDetailId, CourseId, TeacherId, DocumentDetailFileUpload) VALUES" +
                                 "(@DocumentDetailId, @CourseId, @TeacherId, @DocumentDetailFileUpload);";

            //Mở kết nối đến database
            using (SqlConnection connection =
                new SqlConnection(this.ConnectionString))
            {
                // Khởi tạo command với các tham số truyền vào là các trường trong đối tượng DocumentDetail
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@documentDetailId", documentdetail.DocumentDetailId);
                command.Parameters.AddWithValue("@courseId", documentdetail.CourseId);
                command.Parameters.AddWithValue("@teacherId", documentdetail.TeacherId);
                command.Parameters.AddWithValue("@documentDetailFileUpload",documentdetail.DocumentDetailFileUpload);
                //Mở kết nối và thực hiện query vào database
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                //Đọc kết quả trả về
                while (reader.Read())
                {
                    //Lấy documentDetailID sau khi Create xong
                    documentdetail.DocumentDetailId = Convert.ToInt64(reader.GetValue(0).ToString());
                }
                reader.Close();
                connection.Close();
            }

            return documentdetail;
        }

        //Hàm sửa đổi thông tin chi tiết của tài liệu.
        public DocumentDetail UpdateDocumentDetail(DocumentDetail documentdetail)
        {
            string queryString = "UPDATE DocumentDetail SET CourseId = @courseId, TeacherId = @teacherId, DocumentDetailFileUpLoad = @documentDetailFileUpload "
                               + "  WHERE DocumentDetailId = @documentDetailId";
            //Mở kết nối đến database
            using (SqlConnection connection =
                new SqlConnection(this.ConnectionString))
            {
                // Khởi tạo command với các tham số truyền vào là các trường trong đối tượng DocumentDetail
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@documentDetailId", documentdetail.DocumentDetailId);
                command.Parameters.AddWithValue("@courseId", documentdetail.CourseId);
                command.Parameters.AddWithValue("@teacherId", documentdetail.TeacherId);
                command.Parameters.AddWithValue("@documentDetailFileUpload", documentdetail.DocumentDetailFileUpload);
                //Mở kết nối và thực hiện query vào database
                connection.Open();
                command.ExecuteNonQuery(); //Không có giá trị trả về: dùng ExecuteNonQuery

                //Đóng kết nối
                connection.Close();
            }

            //Trả về chính tham số truyền vào nếu hàm không xảy ra bất cứ lỗi gì
            return documentdetail;
        }

        //Lấy danh sách chi tiết tất cả tài liệu.
        public List<DocumentDetail> GetAllDocumentDetailByCourseAndTeacher(long courseId, long teacherId)
        {
            //Giá trị trả về của hàm này: List<DocumentDetail>
            List<DocumentDetail> queryResult = new List<DocumentDetail>();

            //Cấu lệnh truy vấn ở dạng string
            string queryString = "SELECT * FROM DocumentDetail WHERE CourseId like '%' + @courseId + '%' OR TeacherId like '%' + @teacherId +'%'";

            //Mở kết nối đến database
            using (SqlConnection connection =
                new SqlConnection(this.ConnectionString))
            {
                // Khởi tạo command có tham số nào truyền vào là từ khóa tìm kiếm
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@courseId", courseId);
                command.Parameters.AddWithValue("@teacherId", teacherId);
                //Mở kết nối và thực hiện query vào database
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                //Đọc dữ liệu trả về từ truy vấn ở trên
                while (reader.Read())
                {
                    //Tạo biến tạm để lấy đọc giá trị và sau dó thêm vào List queryResult
                    DocumentDetail entity = new DocumentDetail();

                    //Lấy từng cột đọc được lưu vào entity
                    if (reader["DocumentDetailId"] != DBNull.Value)
                    {
                        entity.DocumentDetailId = (long)reader["DocumentDetailId"];
                    }
                    if (reader["CourseId"] != DBNull.Value)
                    {
                        entity.CourseId = (long)reader["CourseId"];
                    }
                    if (reader["TeacherId"] != DBNull.Value)
                    {
                        entity.TeacherId = (long)reader["TeacherId"];
                    }
                    if (reader["DocumentDetailFileUpload"] != DBNull.Value)
                    {
                        entity.DocumentDetailFileUpload = (string)reader["DocumentDetailFileUpload"];
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
        public DocumentDetail GetOneDocumentDetailById(long documentDetailId)
        {
            //Giá trị trả về của hàm này
            DocumentDetail queryResult = new DocumentDetail();

            //Câu lệnh truy vấn ở dạng string
            string queryString = "SELECT * FROM DocumentDetail WHERE DocumentDetailId = @documentDetailId";

            //Mở kết nối đến database
            using (SqlConnection connection =
                new SqlConnection(this.ConnectionString))
            {
                // Khởi tạo command với tham số truyền vào là DocumentDetailId
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@documentDetailId", documentDetailId);

                //Mở kết nối và thực hiện query vào database
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                //Đọc dữ liệu trả về từ truy vấn ở trên
                while (reader.Read())
                {
                    //Lấy từng cột đọc được lưu vào queryResult
                    if (reader["DocumentDetailId"] != DBNull.Value)
                    {
                        queryResult.DocumentDetailId = (long)reader["DocumentDetailId"];
                    }
                    if (reader["CourseId"] != DBNull.Value)
                    {
                        queryResult.CourseId = (long)reader["CourseId"];
                    }
                    if (reader["TeacherId"] != DBNull.Value)
                    {
                        queryResult.TeacherId = (long)reader["TeacherId"];
                    }
                    if (reader["DocumentDetailFileUpload"] != DBNull.Value)
                    {
                        queryResult.DocumentDetailFileUpload = (string)reader["DocumentDetailFileUpload"];
                    }
                    //Đóng kết nối
                    reader.Close();
                    connection.Close();
                }
                //Trả về kết quả
                return queryResult;
            }
        }

        //Hàm xóa thông tin tài liệu ra khỏi danh sách
        public long DeleteDocumentDetailById(long documentDetailId)
        {
            // Hàm trả về TaskDetailId

            //Cấu lệnh truy vấn ở dạng string
            string queryString = "DELETE FROM DocumentDetail WHERE DocumentDetailId = @documentDetailId";

            //Mở kết nối đến database
            using (SqlConnection connection =
                new SqlConnection(this.ConnectionString))
            {
                // Khởi tạo command với tham số truyền vào là taskDetailId
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@documentDetailId", documentDetailId);

                //Mở kết nối và thực hiện query vào database
                connection.Open();
                command.ExecuteNonQuery(); //Không có giá trị trả về: dùng ExecuteNonQuery

                //Đóng kết nối
                connection.Close();
            }

            // Hàm trả về taskDetailId
            return documentDetailId;
        }
    }
}