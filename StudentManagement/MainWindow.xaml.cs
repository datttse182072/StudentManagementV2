using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using StudentManagement.Models;
using StudentManagement.ViewModels;

namespace StudentManagement
{
    /// <summary>
    /// Lớp tương tác cho MainWindow.xaml
    /// Đây là màn hình đăng nhập chính của ứng dụng
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// ViewModel quản lý trạng thái và logic đăng nhập
        /// </summary>
        private readonly LoginViewModel _viewModel;

        /// <summary>
        /// Constructor khởi tạo cửa sổ và thiết lập ViewModel
        /// </summary>
        public MainWindow()
        {
            // Khởi tạo các thành phần UI từ XAML
            InitializeComponent();
            
            // Khởi tạo ViewModel và gán cho DataContext để hỗ trợ data binding
            _viewModel = new LoginViewModel();
            DataContext = _viewModel;
            
            // Kết nối sự kiện PasswordChanged với xử lý (vì PasswordBox không hỗ trợ binding)
            // Đây là giải pháp để bảo mật mật khẩu trong WPF
            txtPassword.PasswordChanged += OnPasswordChanged;
            
            // Đăng ký lắng nghe sự kiện đăng nhập thành công
            _viewModel.LoginSuccessful += OnLoginSuccessful;
        }
        
        /// <summary>
        /// Xử lý sự kiện thay đổi mật khẩu để cập nhật giá trị trong ViewModel
        /// PasswordBox không hỗ trợ binding trực tiếp vì lý do bảo mật
        /// 
        /// @param sender Đối tượng phát sinh sự kiện (PasswordBox)
        /// @param e Tham số sự kiện
        /// </summary>
        private void OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            // Kiểm tra DataContext và cập nhật mật khẩu trong ViewModel
            if (DataContext is LoginViewModel viewModel)
            {
                viewModel.Password = txtPassword.Password;
            }
        }
        
        /// <summary>
        /// Xử lý sự kiện đăng nhập thành công
        /// Chuyển hướng người dùng đến màn hình tương ứng dựa trên vai trò
        /// 
        /// @param sender Đối tượng phát sinh sự kiện (LoginViewModel)
        /// @param account Thông tin tài khoản đã đăng nhập
        /// </summary>
        private void OnLoginSuccessful(object sender, Account account)
        {
            // Chuyển hướng đến màn hình thích hợp dựa trên vai trò của người dùng
            // Trong ứng dụng thực tế, sẽ mở cửa sổ mới hoặc chuyển đổi View
            
            switch (account.Role)
            {
                case "Admin":
                    // Chuyển đến bảng điều khiển admin hoặc mở cửa sổ admin
                    // Đây chỉ là mã giả - trong ứng dụng thực tế sẽ mở AdminWindow
                    MessageBox.Show("Admin dashboard would open here");
                    break;
                case "Teacher":
                    // Chuyển đến bảng điều khiển giáo viên hoặc mở cửa sổ giáo viên
                    // Đây chỉ là mã giả - trong ứng dụng thực tế sẽ mở TeacherWindow
                    MessageBox.Show("Teacher dashboard would open here");
                    break;
                case "Student":
                    // Chuyển đến bảng điều khiển sinh viên hoặc mở cửa sổ sinh viên
                    // Đây chỉ là mã giả - trong ứng dụng thực tế sẽ mở StudentWindow
                    MessageBox.Show("Student dashboard would open here");
                    break;
            }
        }
    }
}