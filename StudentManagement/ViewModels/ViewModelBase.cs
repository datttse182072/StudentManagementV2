using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace StudentManagement.ViewModels
{
    /// <summary>
    /// Lớp cơ sở cho tất cả các ViewModel trong ứng dụng.
    /// Triển khai giao diện INotifyPropertyChanged để hỗ trợ ràng buộc dữ liệu hai chiều.
    /// Đây là một phần quan trọng của mô hình MVVM.
    /// </summary>
    public class ViewModelBase : INotifyPropertyChanged
    {
        /// <summary>
        /// Sự kiện được kích hoạt khi một thuộc tính thay đổi giá trị.
        /// Giao diện người dùng sẽ lắng nghe sự kiện này để cập nhật hiển thị.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Phương thức gọi sự kiện PropertyChanged.
        /// Được sử dụng để thông báo cho UI biết rằng một thuộc tính đã thay đổi.
        /// 
        /// @param propertyName Tên của thuộc tính đã thay đổi
        /// </summary>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            // Sử dụng toán tử ?. để kiểm tra null trước khi gọi sự kiện
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Phương thức trợ giúp để thiết lập giá trị cho một thuộc tính.
        /// Kiểm tra xem giá trị mới có khác với giá trị hiện tại không.
        /// Nếu khác, cập nhật giá trị và gọi OnPropertyChanged.
        /// 
        /// @param field Trường lưu trữ giá trị
        /// @param value Giá trị mới
        /// @param propertyName Tên của thuộc tính (được xác định tự động)
        /// @return true nếu giá trị đã thay đổi, false nếu không
        /// </summary>
        protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            // Kiểm tra xem giá trị mới có giống với giá trị hiện tại không
            if (Equals(field, value)) return false;
            
            // Cập nhật giá trị
            field = value;
            
            // Thông báo sự thay đổi
            OnPropertyChanged(propertyName);
            
            return true;
        }
    }
}
