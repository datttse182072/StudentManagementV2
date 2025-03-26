using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using StudentManagement.Models;
using StudentManagement.Helper;

namespace StudentManagement.ViewModels
{
    /// <summary>
    /// ViewModel cho màn hình Admin Dashboard.
    /// Quản lý dữ liệu và chức năng cho giao diện quản trị.
    /// </summary>
    public class AdminViewModel : ViewModelBase
    {
        private string _adminName;
        private int _totalStudents;
        private int _totalTeachers;
        private int _totalClasses;

        /// <summary>
        /// Constructor khởi tạo AdminViewModel
        /// </summary>
        public AdminViewModel()
        {
            // Lấy thông tin người dùng đã đăng nhập từ lớp Helper
            AdminName = CurrentAccount.Username;
            
            // Khởi tạo các lệnh
            LogoutCommand = new RelayCommand(Logout);
            //ManageStudentsCommand = new RelayCommand(ManageStudents);
            //ManageTeachersCommand = new RelayCommand(ManageTeachers);
            //ManageClassesCommand = new RelayCommand(ManageClasses);
            
            // Tải dữ liệu thống kê
            LoadDashboardData();
        }

        /// <summary>
        /// Tên người dùng admin đang đăng nhập
        /// </summary>
        public string AdminName
        {
            get => _adminName;
            set => SetProperty(ref _adminName, value);
        }

        /// <summary>
        /// Tổng số sinh viên trong hệ thống
        /// </summary>
        public int TotalStudents
        {
            get => _totalStudents;
            set => SetProperty(ref _totalStudents, value);
        }

        /// <summary>
        /// Tổng số giáo viên trong hệ thống
        /// </summary>
        public int TotalTeachers
        {
            get => _totalTeachers;
            set => SetProperty(ref _totalTeachers, value);
        }

        /// <summary>
        /// Tổng số lớp học trong hệ thống
        /// </summary>
        public int TotalClasses
        {
            get => _totalClasses;
            set => SetProperty(ref _totalClasses, value);
        }

        /// <summary>
        /// Lệnh để đăng xuất khỏi hệ thống
        /// </summary>
        public ICommand LogoutCommand { get; }

        /// <summary>
        /// Lệnh để điều hướng đến trang quản lý sinh viên
        /// </summary>
        public ICommand ManageStudentsCommand { get; }

        /// <summary>
        /// Lệnh để điều hướng đến trang quản lý giáo viên
        /// </summary>
        public ICommand ManageTeachersCommand { get; }

        /// <summary>
        /// Lệnh để điều hướng đến trang quản lý lớp học
        /// </summary>
        public ICommand ManageClassesCommand { get; }

        /// <summary>
        /// Sự kiện khi người dùng đăng xuất
        /// </summary>
        public event EventHandler LogoutRequested;

        /// <summary>
        /// Phương thức tải dữ liệu thống kê cho dashboard
        /// </summary>
        private void LoadDashboardData()
        {
            try
            {
                // Trong ứng dụng thực tế, bạn sẽ truy vấn cơ sở dữ liệu để lấy số liệu thống kê
                // Ví dụ đơn giản với dữ liệu giả
                TotalStudents = 120;
                TotalTeachers = 30;
                TotalClasses = 15;
                
                // Mã thực tế sẽ sử dụng DbContext để truy vấn dữ liệu
                // using (var context = new SchoolManagementContext())
                // {
                //     TotalStudents = context.Students.Count();
                //     TotalTeachers = context.Teachers.Count();
                //     TotalClasses = context.Classes.Count();
                // }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không thể tải dữ liệu dashboard: {ex.Message}", 
                    "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Xử lý đăng xuất
        /// </summary>
        private void Logout()
        {
            // Xóa thông tin đăng nhập hiện tại
            CurrentAccount.Clear();
            
            // Kích hoạt sự kiện đăng xuất để View có thể xử lý
            LogoutRequested?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Điều hướng đến trang quản lý sinh viên
        /// </summary>
        private void ManageStudents()
        {
            // Trong ứng dụng thực tế, điều hướng đến view quản lý sinh viên
            MessageBox.Show("Chức năng quản lý sinh viên sẽ được triển khai sau.",
                "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        /// <summary>
        /// Điều hướng đến trang quản lý giáo viên
        /// </summary>
        private void ManageTeachers()
        {
            // Trong ứng dụng thực tế, điều hướng đến view quản lý giáo viên
            MessageBox.Show("Chức năng quản lý giáo viên sẽ được triển khai sau.",
                "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        /// <summary>
        /// Điều hướng đến trang quản lý lớp học
        /// </summary>
        private void ManageClasses()
        {
            // Trong ứng dụng thực tế, điều hướng đến view quản lý lớp học
            MessageBox.Show("Chức năng quản lý lớp học sẽ được triển khai sau.",
                "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
