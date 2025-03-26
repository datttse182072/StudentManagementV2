using System;
using System.Collections.Generic;

namespace StudentManagement.Models;

/// <summary>
/// Lớp đại diện cho thông tin giáo viên trong hệ thống.
/// Liên kết với bảng Teachers trong cơ sở dữ liệu.
/// </summary>
public partial class Teacher
{
    /// <summary>
    /// ID của giáo viên, là khóa chính trong cơ sở dữ liệu
    /// </summary>
    public int TeacherId { get; set; }

    /// <summary>
    /// ID tài khoản liên kết với giáo viên này
    /// Đây là khóa ngoại tới bảng Accounts
    /// </summary>
    public int AccountId { get; set; }

    /// <summary>
    /// Họ và tên đầy đủ của giáo viên
    /// </summary>
    public string FullName { get; set; } = null!;

    /// <summary>
    /// Chuyên môn/lĩnh vực giảng dạy của giáo viên
    /// </summary>
    public string? Specialty { get; set; }

    /// <summary>
    /// Tài khoản liên kết với giáo viên này
    /// Đây là quan hệ navigation property
    /// </summary>
    public virtual Account Account { get; set; } = null!;

    public virtual ICollection<StudySlot> StudySlots { get; set; } = new List<StudySlot>();
}
