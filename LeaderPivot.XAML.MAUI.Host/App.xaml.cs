namespace LeaderAnalytics.LeaderPivot.XAML.MAUI.Host;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        MainPage = new AppShell();
    }
}
