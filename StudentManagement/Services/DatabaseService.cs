using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using StudentManagement.Models;

namespace StudentManagement.Services
{
    /// <summary>
    /// Lớp DatabaseService cung cấp các phương thức để tương tác với cơ sở dữ liệu.
    /// Lớp này tuân thủ nguyên tắc Single Responsibility trong SOLID.
    /// </summary>
    public class DatabaseService
    {
        /// <summary>
        /// Chuỗi kết nối đến cơ sở dữ liệu SQL Server
        /// Trong môi trường thực tế, nên lưu trữ chuỗi kết nối trong tệp cấu hình
        /// </summary>
        private readonly string _connectionString = "Data Source=.;Initial Catalog=SchoolManagement;Integrated Security=True";

        /// <summary>
        /// Phương thức xác thực người dùng bằng tên đăng nhập và mật khẩu.
        /// Phương thức này truy vấn cơ sở dữ liệu để kiểm tra thông tin đăng nhập.
        /// 
        /// Quy trình xác thực:
        /// 1. Mở kết nối đến cơ sở dữ liệu
        /// 2. Tạo truy vấn SQL để tìm tài khoản theo tên đăng nhập
        /// 3. Thực thi truy vấn và đọc kết quả
        /// 4. So sánh mật khẩu được nhập với mật khẩu đã lưu
        /// 5. Nếu khớp, trả về đối tượng Account; nếu không, trả về null
        /// 
        /// @param username Tên đăng nhập của người dùng
        /// @param password Mật khẩu của người dùng (chưa được băm)
        /// @return Đối tượng Account nếu xác thực thành công, null nếu thất bại
        /// </summary>
        public async Task<Account> AuthenticateUserAsync(string username, string password)
        {
            // Trong ứng dụng thực tế, bạn nên băm mật khẩu trước khi so sánh
            // Để đơn giản, chúng ta đang so sánh văn bản thuần túy ở đây
            
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                // Mở kết nối đến cơ sở dữ liệu một cách bất đồng bộ
                await connection.OpenAsync();
                
                // Xây dựng truy vấn SQL để lấy thông tin tài khoản theo tên đăng nhập
                string query = "SELECT AccountID, Username, PasswordHash, Role FROM Accounts WHERE Username = @Username";
                
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Thêm tham số để tránh tấn công SQL Injection
                    command.Parameters.AddWithValue("@Username", username);
                    
                    // Thực thi truy vấn và đọc kết quả
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        // Kiểm tra xem có bản ghi nào được trả về không
                        if (await reader.ReadAsync())
                        {
                            // Lấy giá trị mật khẩu đã băm từ cơ sở dữ liệu
                            string storedHash = reader["PasswordHash"].ToString();
                            
                            // So sánh mật khẩu
                            // Trong ứng dụng thực tế, sử dụng phương pháp so sánh mật khẩu an toàn
                            if (storedHash == password)
                            {
                                // Tạo và trả về đối tượng Account nếu xác thực thành công
                                return new Account
                                {
                                    AccountId = Convert.ToInt32(reader["AccountID"]),
                                    Username = reader["Username"].ToString(),
                                    PasswordHash = storedHash,
                                    Role = reader["Role"].ToString()
                                };
                            }
                        }
                    }
                }
            }
            
            // Trả về null nếu xác thực thất bại
            return null;
        }
    }
}
