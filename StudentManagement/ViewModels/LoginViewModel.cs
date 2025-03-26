using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using StudentManagement.Models;
using StudentManagement.Services;

namespace StudentManagement.ViewModels
{
    /// <summary>
    /// ViewModel cho màn hình đăng nhập.
    /// Quản lý logic cho quá trình đăng nhập và tương tác với UI.
    /// Đây là một ví dụ điển hình của mô hình MVVM.
    /// </summary>
    public class LoginViewModel : ViewModelBase
    {
        /// <summary>
        /// Đối tượng dịch vụ cơ sở dữ liệu để xác thực người dùng
        /// </summary>
        private readonly DatabaseService _databaseService;
        
        /// <summary>
        /// Lưu trữ tên đăng nhập được nhập bởi người dùng
        /// </summary>
        private string _username;
        
        /// <summary>
        /// Lưu trữ mật khẩu được nhập bởi người dùng
        /// </summary>
        private string _password;
        
        /// <summary>
        /// Lưu trữ thông báo lỗi để hiển thị cho người dùng
        /// </summary>
        private string _errorMessage;
        
        /// <summary>
        /// Đánh dấu trạng thái đang tải (đang xử lý đăng nhập)
        /// </summary>
        private bool _isLoading;

        /// <summary>
        /// Thuộc tính cho tên đăng nhập với thông báo thay đổi
        /// </summary>
        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }

        /// <summary>
        /// Thuộc tính cho mật khẩu với thông báo thay đổi
        /// </summary>
        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        /// <summary>
        /// Thuộc tính cho thông báo lỗi với thông báo thay đổi
        /// </summary>
        public string ErrorMessage
        {
            get => _errorMessage;
            set => SetProperty(ref _errorMessage, value);
        }

        /// <summary>
        /// Thuộc tính cho trạng thái đang tải với thông báo thay đổi
        /// </summary>
        public bool IsLoading
        {
            get => _isLoading;
            set => SetProperty(ref _isLoading, value);
        }

        /// <summary>
        /// Lệnh để thực hiện đăng nhập khi người dùng nhấn nút Đăng nhập
        /// Sử dụng ICommand để ràng buộc với nút trong XAML
        /// </summary>
        public ICommand LoginCommand { get; }

        /// <summary>
        /// Sự kiện được kích hoạt khi đăng nhập thành công
        /// Sẽ được lắng nghe bởi MainWindow để xử lý chuyển hướng
        /// </summary>
        public event EventHandler<Account> LoginSuccessful;

        /// <summary>
        /// Constructor khởi tạo dịch vụ cơ sở dữ liệu và lệnh đăng nhập
        /// </summary>
        public LoginViewModel()
        {
            // Khởi tạo service để tương tác với cơ sở dữ liệu
            _databaseService = new DatabaseService();
            
            // Khởi tạo lệnh đăng nhập với phương thức xử lý và điều kiện
            LoginCommand = new RelayCommand(async param => await Login(), param => CanLogin());
        }

        /// <summary>
        /// Kiểm tra xem người dùng có thể thực hiện đăng nhập không
        /// Đảm bảo các trường bắt buộc đã được nhập và không đang trong quá trình xử lý
        /// 
        /// @return true nếu có thể đăng nhập, false nếu không
        /// </summary>
        private bool CanLogin()
        {
            // Kiểm tra tên đăng nhập và mật khẩu không trống và không đang trong quá trình đăng nhập
            return !string.IsNullOrWhiteSpace(Username) && 
                   !string.IsNullOrWhiteSpace(Password) && 
                   !IsLoading;
        }

        /// <summary>
        /// Phương thức xử lý đăng nhập.
        /// - Gọi service để xác thực người dùng
        /// - Xử lý kết quả đăng nhập
        /// - Cập nhật UI dựa trên kết quả
        /// 
        /// Quy trình đăng nhập:
        /// 1. Đặt trạng thái loading
        /// 2. Xóa thông báo lỗi cũ
        /// 3. Gọi service xác thực
        /// 4. Nếu thành công, kích hoạt sự kiện và chuyển hướng
        /// 5. Nếu thất bại, hiển thị thông báo lỗi
        /// </summary>
        private async Task Login()
        {
            try
            {
                // Đặt cờ loading để vô hiệu hóa UI trong quá trình xử lý
                IsLoading = true;
                
                // Xóa thông báo lỗi cũ
                ErrorMessage = string.Empty;

                // Gọi service để xác thực người dùng
                Account account = await _databaseService.AuthenticateUserAsync(Username, Password);

                // Kiểm tra kết quả xác thực
                if (account != null)
                {
                    // Kích hoạt sự kiện đăng nhập thành công để thông báo cho View
                    LoginSuccessful?.Invoke(this, account);
                    
                    // Hiển thị thông báo thành công
                    // Trong ứng dụng thực tế, có thể bỏ qua bước này và chuyển hướng ngay
                    MessageBox.Show($"Login successful! Welcome {account.Username} ({account.Role})", 
                        "Login Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    
                    // Ở đây thường sẽ chuyển hướng đến màn hình khác dựa trên vai trò của người dùng
                }
                else
                {
                    // Hiển thị thông báo lỗi nếu xác thực thất bại
                    ErrorMessage = "Invalid username or password";
                }
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ và hiển thị thông báo lỗi
                ErrorMessage = $"An error occurred: {ex.Message}";
            }
            finally
            {
                // Đặt lại cờ loading để kích hoạt lại UI
                IsLoading = false;
            }
        }
    }

    /// <summary>
    /// Lớp RelayCommand triển khai giao diện ICommand.
    /// Cho phép ràng buộc các phương thức với các điều khiển UI thông qua data binding.
    /// Đây là một mẫu thiết kế phổ biến trong MVVM.
    /// </summary>
    public class RelayCommand : ICommand
    {
        /// <summary>
        /// Phương thức sẽ được thực thi khi lệnh được gọi
        /// </summary>
        private readonly Func<object, Task> _execute;
        
        /// <summary>
        /// Phương thức kiểm tra xem lệnh có thể được thực thi không
        /// </summary>
        private readonly Predicate<object> _canExecute;
        private Action logout;

        /// <summary>
        /// Constructor khởi tạo lệnh với phương thức thực thi và kiểm tra
        /// 
        /// @param execute Phương thức sẽ được thực thi
        /// @param canExecute Phương thức kiểm tra điều kiện thực thi
        /// </summary>
        public RelayCommand(Func<object, Task> execute, Predicate<object> canExecute = null)
        {
            // Kiểm tra và gán phương thức thực thi
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            
            // Gán phương thức kiểm tra (có thể null)
            _canExecute = canExecute;
        }

        public RelayCommand(Action logout)
        {
            this.logout = logout;
        }

        /// <summary>
        /// Kiểm tra xem lệnh có thể được thực thi không
        /// 
        /// @param parameter Tham số được truyền từ UI
        /// @return true nếu lệnh có thể thực thi, false nếu không
        /// </summary>
        public bool CanExecute(object parameter)
        {
            // Nếu không có phương thức kiểm tra, luôn trả về true
            return _canExecute?.Invoke(parameter) ?? true;
        }

        /// <summary>
        /// Thực thi lệnh khi được gọi từ UI
        /// 
        /// @param parameter Tham số được truyền từ UI
        /// </summary>
        public async void Execute(object parameter)
        {
            // Gọi phương thức thực thi một cách bất đồng bộ
            await _execute(parameter);
        }

        /// <summary>
        /// Sự kiện được kích hoạt khi điều kiện thực thi thay đổi
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            // Kết nối với sự kiện RequerySuggested của CommandManager
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
