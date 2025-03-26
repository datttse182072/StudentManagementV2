using System.Windows;
using StudentManagement.Models;
using StudentManagement.Views.Admin;

namespace StudentManagement.Helper
{
    /// <summary>
    /// Lớp helper để quản lý việc điều hướng giữa các cửa sổ trong ứng dụng
    /// </summary>
    public static class NavigationHelper
    {
        /// <summary>
        /// Mở cửa sổ tương ứng dựa trên vai trò của tài khoản
        /// </summary>
        /// <param name="account">Tài khoản đã đăng nhập</param>
        /// <param name="currentWindow">Cửa sổ hiện tại cần đóng</param>
        public static void NavigateToRoleBasedWindow(Account account, Window currentWindow)
        {
            Window newWindow = null;

            // Lưu thông tin tài khoản vào CurrentAccount helper
            CurrentAccount.SetAccount(
                account.AccountId,
                account.Username,
                account.PasswordHash,
                account.Role
            );

            // Mở cửa sổ tương ứng với vai trò
            switch (account.Role)
            {
                case "Admin":
                    newWindow = new AdminDashboard();
                    break;
                case "Teacher":
                    // TODO: Sẽ tạo TeacherDashboard sau
                    MessageBox.Show("Teacher Dashboard sẽ được triển khai sau.",
                        "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                case "Student":
                    // TODO: Sẽ tạo StudentDashboard sau
                    MessageBox.Show("Student Dashboard sẽ được triển khai sau.",
                        "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                default:
                    MessageBox.Show($"Không hỗ trợ vai trò: {account.Role}",
                        "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
            }

            // Hiển thị cửa sổ mới và đóng cửa sổ hiện tại
            if (newWindow != null)
            {
                newWindow.Show();
                currentWindow.Close();
            }
        }
    }
}
