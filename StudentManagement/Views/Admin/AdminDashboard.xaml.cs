using System;
using System.Windows;
using StudentManagement.ViewModels;

namespace StudentManagement.Views.Admin
{
    /// <summary>
    /// Interaction logic for AdminDashboard.xaml
    /// </summary>
    public partial class AdminDashboard : Window
    {
        private readonly AdminViewModel _viewModel;

        /// <summary>
        /// Constructor khởi tạo AdminDashboard và đăng ký các xử lý sự kiện
        /// </summary>
        public AdminDashboard()
        {
            InitializeComponent();
            
            // Khởi tạo ViewModel và đặt làm DataContext
            _viewModel = new AdminViewModel();
            DataContext = _viewModel;
            
            // Đăng ký sự kiện đăng xuất
            _viewModel.LogoutRequested += OnLogoutRequested;
            
            // Đăng ký sự kiện đóng cửa sổ
            Closed += OnWindowClosed;
        }

        /// <summary>
        /// Xử lý sự kiện khi người dùng yêu cầu đăng xuất
        /// </summary>
        private void OnLogoutRequested(object sender, EventArgs e)
        {
            // Mở cửa sổ đăng nhập mới
            var loginWindow = new MainWindow();
            loginWindow.Show();
            
            // Đóng cửa sổ hiện tại
            Close();
        }

        /// <summary>
        /// Xử lý sự kiện khi cửa sổ bị đóng để hủy đăng ký các sự kiện
        /// </summary>
        private void OnWindowClosed(object sender, EventArgs e)
        {
            // Hủy đăng ký sự kiện để tránh memory leak
            _viewModel.LogoutRequested -= OnLogoutRequested;
            Closed -= OnWindowClosed;
        }
    }
}
