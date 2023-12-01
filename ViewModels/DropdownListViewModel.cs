using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DropdownControl.Pages.BottomSheets;

namespace DropdownControl.ViewModels
{
    public partial class DropdownListViewModel : ObservableObject
    {
        [ObservableProperty]
        string selectedValue;

        public DropdownListViewModel()
        {
            SelectedValue = "Choose an Item";
        }
        [RelayCommand]
        void DropdownClicked()
        {
            DropdownBottomSheet dropdownBottomSheet = new(this)
            {
                HasBackdrop = true,
            };
            dropdownBottomSheet.ShowAsync();
        }
    }
}
