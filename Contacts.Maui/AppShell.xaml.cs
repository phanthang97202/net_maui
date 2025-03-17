namespace Contacts.Maui
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            //foreach (var item in this.Items)
            //{
            //    Console.WriteLine($"Route: {item.Route}");
            //} 

            // Chạy điều hướng sau khi Shell hoàn tất khởi tạo
            // nếu không thì MAUI sẽ không trì hoãn việc navigate khi mà Shell chưa khởi tạo xong
            Dispatcher.Dispatch(() =>
            {
                NavigateDefaultRoute();
            });


        }

        public async void NavigateDefaultRoute()
        {
            await Shell.Current.GoToAsync("//ContactsPage");
        }
    }
}
