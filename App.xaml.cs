using DropdownControl.Pages;
#if __ANDROID__
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
#endif
namespace DropdownControl
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new DropdownList();

            Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(nameof(Entry), (handler, view) =>
            {
#if __ANDROID__

                handler.PlatformView.BackgroundTintList = Android.Content.Res.ColorStateList.ValueOf(Colors.Transparent.ToAndroid());
#elif __IOS__
            handler.PlatformView.BackgroundColor = UIKit.UIColor.Clear;
            handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#endif
            });
        }
    }
}
