using CommunityToolkit.Maui;
using DropdownControl.Pages;
using DropdownControl.Pages.BottomSheets;
using DropdownControl.ViewModels;
using DropdownControl.ViewModels.Bottomsheets;
using Microsoft.Extensions.Logging;
using The49.Maui.BottomSheet;

namespace DropdownControl
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .UseBottomSheet()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif
            builder.Services.AddTransient<DropdownBottomSheet>();
            builder.Services.AddTransient<DropdownList>();

            builder.Services.AddTransient<DropdownListViewModel>();
            builder.Services.AddTransient<DropdownBottomSheetViewModel>();
            return builder.Build();
        }
    }
}
