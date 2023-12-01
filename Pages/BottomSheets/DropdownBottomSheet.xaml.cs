using DropdownControl.ViewModels;
using DropdownControl.ViewModels.Bottomsheets;
using The49.Maui.BottomSheet;

namespace DropdownControl.Pages.BottomSheets;

public partial class DropdownBottomSheet : BottomSheet
{
	public DropdownBottomSheet(DropdownListViewModel dropdownListViewModel)
	{
		InitializeComponent();
		BindingContext = new DropdownBottomSheetViewModel(dropdownListViewModel, this);
	}
}