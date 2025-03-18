using System.Collections.ObjectModel;

namespace Contacts.Maui.Views;

public class Person
{
    public string? Name { get; set; }
    public int Age { get; set; }
    public string? Address { get; set; }
}

public class MainViewModel
{
    public ObservableCollection<Person> People { get; set; }
    public MainViewModel()
    {
        People = new ObservableCollection<Person>
        {
            new Person { Name = "AAAAAAAAAAAAAAAA", Age = 12, Address = "Hà Nam" },
            new Person { Name = "A", Age = 12, Address = "Hà Nam" },
            new Person { Name = "A", Age = 12, Address = "Hà Nam" }
        };
    }
}

public partial class ContactsPage : ContentPage
{
	public ContactsPage()
	{
		InitializeComponent();
        BindingContext = new MainViewModel();

    }

    

    private void handleAddContact(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(AddContactPage));
    }

    private void handleEditContact(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(EditContactPage));
    }
}