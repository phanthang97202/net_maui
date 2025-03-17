﻿using System.Reflection;

namespace Contacts.Maui
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            Type typeContentPage = typeof(ContentPage);
            PropertyInfo[] p = typeContentPage.GetProperties();

            foreach (PropertyInfo pi in p) { 
                Console.WriteLine(pi.Name);
            }

            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";
            // Hỗ trợ người khiếm thị (đọc to nội dung nút)
            SemanticScreenReader.Announce(CounterBtn.Text);
        }

        private async void handleGetValueCounterBtn(object sender, EventArgs e)
        {
            string value = CounterBtn.Text;
            await Application.Current.MainPage.DisplayAlert("Thông báo", value, "OK");
        }

        private void handleAddContact(object sender, EventArgs e)
        {
             
        }
        
        private void handleListContact(object sender, EventArgs e)
        {

        }
    }

}
