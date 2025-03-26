using System;
using System.Collections.Generic;

namespace StudentManagement.Models
{
    /// <summary>
    /// Lớp đại diện cho thông tin sinh viên trong hệ thống.
    /// Liên kết với bảng Students trong cơ sở dữ liệu.
    /// </summary>
    public class Student
    {
        /// <summary>
        /// ID của sinh viên, là khóa chính trong cơ sở dữ liệu
        /// </summary>
        public int StudentId { get; set; }

        /// <summary>
        /// ID tài khoản liên kết với sinh viên này
        /// Đây là khóa ngoại tới bảng Accounts
        /// </summary>
        public int AccountId { get; set; }

        /// <summary>
        /// Họ và tên đầy đủ của sinh viên
        /// </summary>
        public string FullName { get; set; } = null!;

        /// <summary>
        /// Ngày sinh của sinh viên
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Tài khoản liên kết với sinh viên này
        /// Đây là quan hệ navigation property
        /// </summary>
        public virtual Account Account { get; set; } = null!;
    }
}
