using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace StudentManagement.Converters
{
    /// <summary>
    /// Converter chuyển đổi giá trị boolean thành Visibility.
    /// Được sử dụng để hiển thị/ẩn các phần tử UI dựa trên điều kiện.
    /// 
    /// Ví dụ: Hiển thị thông báo "Đang đăng nhập..." chỉ khi IsLoading = true
    /// </summary>
    public class BooleanToVisibilityConverter : IValueConverter
    {
        /// <summary>
        /// Chuyển đổi từ boolean sang Visibility
        /// true -> Visible, false -> Collapsed
        /// 
        /// @param value Giá trị boolean đầu vào
        /// @param targetType Kiểu dữ liệu đích
        /// @param parameter Tham số bổ sung (không sử dụng)
        /// @param culture Thông tin văn hóa
        /// @return Giá trị Visibility tương ứng
        /// </summary>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Kiểm tra và chuyển đổi giá trị
            if (value is bool boolValue)
            {
                return boolValue ? Visibility.Visible : Visibility.Collapsed;
            }
            
            // Giá trị mặc định nếu không phải boolean
            return Visibility.Collapsed;
        }

        /// <summary>
        /// Chuyển đổi ngược từ Visibility sang boolean
        /// Visible -> true, Hidden/Collapsed -> false
        /// 
        /// @param value Giá trị Visibility đầu vào
        /// @param targetType Kiểu dữ liệu đích
        /// @param parameter Tham số bổ sung (không sử dụng)
        /// @param culture Thông tin văn hóa
        /// @return Giá trị boolean tương ứng
        /// </summary>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Kiểm tra và chuyển đổi giá trị
            if (value is Visibility visibility)
            {
                return visibility == Visibility.Visible;
            }
            
            // Giá trị mặc định nếu không phải Visibility
            return false;
        }
    }

    /// <summary>
    /// Converter đảo ngược giá trị boolean.
    /// Được sử dụng khi cần logic ngược lại với giá trị boolean.
    /// 
    /// Ví dụ: Vô hiệu hóa nút đăng nhập khi IsLoading = true
    /// </summary>
    public class InverseBooleanConverter : IValueConverter
    {
        /// <summary>
        /// Chuyển đổi giá trị boolean thành giá trị đối diện
        /// true -> false, false -> true
        /// 
        /// @param value Giá trị boolean đầu vào
        /// @param targetType Kiểu dữ liệu đích
        /// @param parameter Tham số bổ sung (không sử dụng)
        /// @param culture Thông tin văn hóa
        /// @return Giá trị boolean đảo ngược
        /// </summary>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Kiểm tra và đảo ngược giá trị
            if (value is bool boolValue)
            {
                return !boolValue;
            }
            
            // Giá trị mặc định 
            return true;
        }

        /// <summary>
        /// Chuyển đổi ngược lại, cũng đảo ngược giá trị
        /// Phương thức này đối xứng với Convert
        /// 
        /// @param value Giá trị boolean đầu vào
        /// @param targetType Kiểu dữ liệu đích
        /// @param parameter Tham số bổ sung (không sử dụng)
        /// @param culture Thông tin văn hóa
        /// @return Giá trị boolean đảo ngược
        /// </summary>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Kiểm tra và đảo ngược giá trị
            if (value is bool boolValue)
            {
                return !boolValue;
            }
            
            // Giá trị mặc định
            return true;
        }
    }
}
