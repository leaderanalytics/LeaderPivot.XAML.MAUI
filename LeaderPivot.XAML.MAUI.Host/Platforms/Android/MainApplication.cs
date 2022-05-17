using Android.App;
using Android.Runtime;

namespace LeaderAnalytics.LeaderPivot.XAML.MAUI.Host;
[Application]
public class MainApplication : MauiApplication
{
    public MainApplication(IntPtr handle, JniHandleOwnership ownership)
        : base(handle, ownership)
    {
    }

    protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
}
