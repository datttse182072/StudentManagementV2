using System;
using System.Collections.Generic;

namespace StudentManagement.Models;

/// <summary>
/// Lớp Account đại diện cho tài khoản người dùng trong hệ thống.
/// Đây là model chính để lưu trữ thông tin đăng nhập.
/// </summary>
public partial class Account
{
    /// <summary>
    /// ID của tài khoản, là khóa chính trong cơ sở dữ liệu
    /// </summary>
    public int AccountId { get; set; }

    /// <summary>
    /// Tên đăng nhập của người dùng, phải là duy nhất
    /// </summary>
    public string Username { get; set; } = null!;

    /// <summary>
    /// Mật khẩu đã được băm của người dùng
    /// Trong ứng dụng thực tế, nên sử dụng các thuật toán băm mạnh như bcrypt
    /// </summary>
    public string PasswordHash { get; set; } = null!;

    /// <summary>
    /// Vai trò của người dùng trong hệ thống: Student, Teacher, hoặc Admin
    /// Quyết định các chức năng mà người dùng có thể truy cập
    /// </summary>
    public string Role { get; set; } = null!;

    /// <summary>
    /// Thông tin sinh viên liên kết với tài khoản này (nếu vai trò là Student)
    /// Đây là mối quan hệ 1-1 với bảng Students
    /// </summary>
    public virtual Student? Student { get; set; }

    /// <summary>
    /// Thông tin giáo viên liên kết với tài khoản này (nếu vai trò là Teacher)
    /// Đây là mối quan hệ 1-1 với bảng Teachers
    /// </summary>
    public virtual Teacher? Teacher { get; set; }
}
