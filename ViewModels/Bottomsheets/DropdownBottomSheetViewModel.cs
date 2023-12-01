using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DropdownControl.Pages.BottomSheets;
using System.Collections.ObjectModel;

namespace DropdownControl.ViewModels.Bottomsheets
{
    public partial class DropdownBottomSheetViewModel : ObservableObject
    {
        [ObservableProperty]
        string selectedItem;

        [ObservableProperty]
        string selectedValue;

        [ObservableProperty]
        string clearedItem;

        [ObservableProperty]
        string searchText = string.Empty;

        [ObservableProperty]
        bool selectedItemVisible = false;

        [ObservableProperty]
        bool noItemslblVisible = false;

        [ObservableProperty]
        List<string> ddlItems;

        [ObservableProperty]
        ObservableCollection<string> ddlSource;

        [ObservableProperty]
        ObservableCollection<string> selectedItemsList;

        [ObservableProperty]
        DropdownBottomSheet ddlBottomSheet;

        [ObservableProperty]
        DropdownListViewModel ddlViewModel;
        public DropdownBottomSheetViewModel(DropdownListViewModel dropdownList, DropdownBottomSheet dropdownBottomSheet)
        {
            DdlBottomSheet = dropdownBottomSheet;
            DdlViewModel = dropdownList;
            SelectedItemsList = [];
            DdlItems = [];
            DdlSource = [];
            if (DdlViewModel.SelectedValue.ToLower() != "choose an item")
            {
                SelectedItemsList.Add(DdlViewModel.SelectedValue);
                SelectedItemVisible = true;
            }
            DdlSource =
            [
                "Value 1",
                "Value 2",
                "Value 3",
                "Value 4",
                "Value 5",
                "Value 6",
                "Value 7",
                "Value 8",
                "Value 9",
                "Value 10",
                "Value 11",
                "Value 12"
            ];
            DdlItems = DdlSource.ToList();
            NoItemslblVisible = DdlSource.Count == 0;
        }
        [RelayCommand]
        void SelectionChanged()
        {
            if (SelectedItem != null)
            {
                ClearedItem = null;
                SelectedItemsList.Clear();
                SelectedItemsList.Add(SelectedItem);
                SelectedItemVisible = true;
            }
        }
        [RelayCommand]
        void ClearSelectedItem()
        {
            if (ClearedItem != null)
            {
                SelectedItemsList.Remove(ClearedItem);
                SelectedItem = null;
            }
            SelectedItemVisible = false;
        }
        [RelayCommand]
        void Cancel()
        {
            DdlBottomSheet.DismissAsync();
        }
        [RelayCommand]
        void Done()
        {
            DdlViewModel.SelectedValue = SelectedItemsList.Count > 0 ? SelectedItem : "Choose an item";
            DdlBottomSheet.DismissAsync();
        }
        [RelayCommand]
        void SearchItem()
        {
                DdlSource.Clear();
                List<string> searchResult;
                if (SearchText.Length > 0)
                {
                    searchResult = DdlItems.Where(x => x.ToLower().Contains(SearchText.ToLower())).ToList();
                }
                else
                {
                    searchResult = DdlItems;
                }
                foreach (var item in searchResult)
                {
                    DdlSource.Add(item);
                }
                NoItemslblVisible = DdlSource.Count == 0;
        }
        [RelayCommand]
        void ClearSearch()
        {
                SearchText = string.Empty;
        }
    }
}
