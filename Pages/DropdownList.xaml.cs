using DropdownControl.ViewModels;

namespace DropdownControl.Pages;

public partial class DropdownList : ContentPage
{
	public DropdownList()
	{
		InitializeComponent();
		BindingContext = new DropdownListViewModel();
	}
}