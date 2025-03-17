### Vì sao c?n b?t Windows Hypervisor Platform và Hyper-V khi dùng .NET MAUI?
	- Khi b?n phát tri?n ?ng d?ng .NET MAUI trên Windows, n?u mu?n ch?y ?ng d?ng trên trình gi? l?p 
	Android (Android Emulator), b?n c?n b?t Windows Hypervisor Platform và Hyper-V.

	+ Hyper-V là công ngh? ?o hóa c?a Microsoft giúp t?o máy ?o (Virtual Machine - VM).
	+ Nó cho phép ch?y nhi?u h? ?i?u hành trên m?t máy tính mà không c?n kh?i ??ng l?i.
	+ Trong .NET MAUI, Hyper-V giúp ch?y trình gi? l?p Android nhanh h?n.

### Windows Hypervisor Platform là gì?
	+ Windows Hypervisor Platform (WHPX) là m?t thành ph?n giúp ?ng d?ng bên th? ba (nh? trình gi? 
	l?p Android) truy c?p vào kh? n?ng ?o hóa c?a Windows.
	+ Khi b?t WHPX, trình gi? l?p Android có th? ch?y m??t mà h?n mà không c?n dùng 
	Intel HAXM (Hypervisor c?a Intel, ch? ho?t ??ng v?i CPU Intel).
=> Cách b?t: 
	DISM /Online /Enable-Feature /All /FeatureName:Microsoft-Hyper-V
	DISM /Online /Enable-Feature /All /FeatureName:HypervisorPlatform

### Structual project
	App.xaml	Lưu trữ tài nguyên chung của ứng dụng
	App.xaml.cs	Khởi động ứng dụng, đặt trang chính (AppShell)

	AppShell.xaml	Xác định cấu trúc điều hướng (Shell)
	AppShell.xaml.cs	Xử lý logic điều hướng, đăng ký routes

	MainPage.xaml	Giao diện chính của ứng dụng
	MainPage.xaml.cs	Xử lý sự kiện, logic giao diện


IOS     |
Android |---> MauiProgram.cs ---> App ---> AppShell
Windows |

Mọi file App.xaml.cs đều có hàm InitializeComponent(); trong 
constructor để khởi tạo giao diện UI từ file .xaml tương ứng của nó

		-->	view -->
		|			|
		v			v
	state  <------	events
					
### <ContentPage>
	Là 1 loại Page dùng để hiển thị nội dung đơn giản (thường là
	Grid, ScrollView, StackLayout)
	Ex: 
		<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             x:Class="Contacts.Maui.MainPage">
		+ xmlns="http://schemas.microsoft.com/dotnet/2021/maui" khai báo namespace cho .net maui, nó cho phép sử dụng các thành phần của net maui trong file xaml
		+ xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml" là khai báo namespace chuẩn, giúp sử dụng các tính năng nâng cao của xaml như: x:Class (liên kết với file C#), x:Name (định danh cho control), x:Static(Sử dụng giá trị tĩnh)
		+ x:Class="Contacts.Maui.MainPage" chỉ định tên class C# tương tứng với file xaml này, có nghĩa là MainPage.xaml được liên kết với MainPage.xaml.cs, khi chạy ứng dụng nó sẽ khởi tạo MainPage.xaml.cs rồi load file xaml từ file này

	Một số properties khác cho ContentPage
		### **1️⃣ Thuộc tính liên quan đến Giao diện & Layout**
			| Thuộc tính | Mô tả |
			|------------|--------|
			| **Padding** | Thiết lập khoảng cách bên trong `ContentPage` (giống `margin` nhưng là khoảng cách nội dung bên trong). |
			| **BackgroundColor** | Màu nền của trang. |
			| **BackgroundImageSource** | Hình nền của trang. |
			| **Content** | Thành phần chính bên trong trang (thường là `StackLayout`, `Grid`, hoặc một View khác). |
			| **Frame** | Định nghĩa khung của `ContentPage`. |
			| **Bounds** | Xác định vị trí và kích thước của `ContentPage` trong cửa sổ. |
			| **ContainerArea** | Vùng nội dung có thể sử dụng trong `ContentPage`. |

		---

		### **2️⃣ Điều khiển hành vi & Trạng thái**
			| Thuộc tính | Mô tả |
			|------------|--------|
			| **IsVisible** | Xác định xem `ContentPage` có hiển thị hay không. |
			| **IsEnabled** | Cho phép hoặc vô hiệu hóa tương tác với trang. |
			| **IsFocused** | Kiểm tra xem trang có đang được focus hay không. |
			| **IsBusy** | Hiển thị trạng thái "bận" (thường dùng để hiển thị spinner). |
			| **InputTransparent** | Nếu `true`, trang sẽ không nhận sự kiện chạm (touch events). |

		---

		### **3️⃣ Điều khiển Animation & Hiệu ứng**
			| Thuộc tính | Mô tả |
			|------------|--------|
			| **Opacity** | Điều chỉnh độ trong suốt của `ContentPage`. |
			| **Rotation, RotationX, RotationY** | Xoay trang theo các trục X, Y hoặc cả hai. |
			| **TranslationX, TranslationY** | Di chuyển trang theo trục X/Y. |
			| **Scale, ScaleX, ScaleY** | Phóng to hoặc thu nhỏ trang. |
			| **Clip** | Cắt nội dung của `ContentPage` theo một hình dạng nhất định. |
			| **Shadow** | Thêm bóng đổ cho `ContentPage`. |

		---

		### **4️⃣ Điều khiển Navigation & Menu**
			| Thuộc tính | Mô tả |
			|------------|--------|
			| **Navigation** | Cung cấp quyền truy cập vào trình điều hướng để chuyển trang. |
			| **NavigationProxy** | Hỗ trợ cho hệ thống điều hướng nội bộ của MAUI. |
			| **ToolbarItems** | Danh sách các nút trên thanh công cụ (Toolbar). |
			| **MenuBarItems** | Danh sách các mục trong thanh menu (menu bar trên macOS). |

		---

		### **5️⃣ Thuộc tính nâng cao & Tùy chỉnh**
			| Thuộc tính | Mô tả |
				|------------|--------|
				| **Effects** | Cho phép áp dụng hiệu ứng tùy chỉnh trên `ContentPage`. |
				| **Behaviors** | Gán các hành vi (behavior) mở rộng cho `ContentPage`. |
				| **Visual** | Điều chỉnh cách hiển thị UI theo nền tảng. |
				| **Style** | Xác định kiểu giao diện (CSS-like) cho trang. |

		---

		### **6️⃣ Thuộc tính Handler (Liên quan đến Native Control)**
			| Thuộc tính | Mô tả |
			|------------|--------|
			| **Handler** | Cung cấp khả năng truy cập vào lớp `Handler`, giúp tương tác với thành phần gốc trên từng nền tảng (Android, iOS, Windows). |
			| **DesiredSize** | Kích thước mong muốn của `ContentPage`. |

		---

		### **📌 Kết luận**
		🔹 **Nếu muốn tùy chỉnh giao diện?** 👉 Sử dụng **BackgroundColor, Padding, Opacity, Scale, Rotation**.  
		🔹 **Nếu muốn điều khiển trạng thái?** 👉 Kiểm tra **IsVisible, IsBusy, IsFocused**.  
		🔹 **Nếu cần điều hướng trang?** 👉 Sử dụng **Navigation, ToolbarItems, MenuBarItems**.  
		🔹 **Nếu muốn thêm hiệu ứng?** 👉 Dùng **Effects, Behaviors, Shadow**.   


### Các loại thuộc tính cần chú ý
	+ Thuộc tính bình thường của Control như: Text="Clickme", FontSize, ... Là nó chỉ áp dụng cấu hình cho control trực tiếp
	+ Thuộc tính mà có tiền tố x: như x:Name, x:Key, ..... Là nó dùng để định danh control để truy xuấ trong C#, định danh resource để tái sử dụng, code-behind ở file .xaml.cs
		✅ xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml" rất quan trọng vì:
			+ Nó cho phép sử dụng các thuộc tính x:Name, x:Key, x:Class,...
			+ Nếu không có nó, XAML sẽ báo lỗi khi gặp các thuộc tính x:.
			
			+ Đây là namespace mặc định cho các tính năng mở rộng của XAML. 🚀
				🔹 Tóm tắt - Vì sao dùng định danh dạng URL?
				✅ 1. Tránh xung đột namespace giữa các thư viện khác nhau.
				✅ 2. Theo tiêu chuẩn XML Namespaces (XMLNS) giúp dễ tích hợp với XML.
				✅ 3. Phân biệt nhà cung cấp (Microsoft, Google, Meta, AWS,...).
				✅ 4. URL không phải một trang web thật, chỉ là một định danh duy nhất giúp XAML biết namespace nào là của ai.
				🚀 Đây là một tiêu chuẩn giúp XAML có thể mở rộng và làm việc với nhiều thư viện khác nhau một cách an toàn!

			+ x chỉ là alias, bạn có thể thay bằng bất kỳ tên nào như abc, xyz, custom.
				✅ Alias giúp bạn dùng namespace theo cách ngắn gọn hơn, ví dụ: x:Name, x:Key.
				✅ Namespace chính (xmlns="") không cần alias, mọi thẻ không có prefix sẽ thuộc về

### Navigate trong MAUI
	Trong .NET MAUI Shell, màn hình đầu tiên mà ứng dụng hiển thị khi khởi động chính là ShellContent được khai báo đầu tiên trong Shell.

	Shell là thành phần chính trong MAUI, nó không thể nằm trong thẻ ContentPage
	Phải đặt trong AppShell.xaml

	+ FlyoutItem	
		Đại diện cho một mục trong menu điều hướng (Flyout menu).
		Nếu có nhiều ShellContent bên trong, nó sẽ hiển thị các mục con.
		Dùng khi bạn muốn có một menu chính mà người dùng có thể mở từ bên trái màn hình.
	
	+ Tab	
		Dùng để nhóm các trang trong tab bar (thanh điều hướng dưới cùng màn hình).
		Chỉ dùng bên trong FlyoutItem.

	+ ShellContent	
		Là phần tử nhỏ nhất chứa nội dung thực sự của trang.
		Liên kết đến một trang cụ thể

	+ Property Route
		Route trong .NET MAUI định danh duy nhất cho một trang (ShellContent), giúp bạn có thể điều hướng đến trang đó bằng cách sử dụng tên thay vì kiểu dữ liệu trang.
		Có thể dùng GoToAsync("RouteName") để mở trang thay vì tạo instance mới.
		Có thể đăng ký Route cho trang ngoài Shell bằng Routing.RegisterRoute
	
	+ Dispatcher 
		Trong MAUI là 1 cơ chế giúp thực thi mã trên luồng UI chính (Main thread)
		Trong MAUI các thao tác UI như cập nhật giao diện, điều hướng, ... chỉ có thể thực hiện trên luồng UI chính - main thread. Nếu cố tình gọi hàm cập nhật UI từ 1 luồng nền - background thread => ứng dụng có thể bị lỗi