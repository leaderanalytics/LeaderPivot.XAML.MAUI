//using CommunityToolkit.Maui;
//using CommunityToolkit.Maui.Core;
//using CommunityToolkit.Maui.Markup;


namespace LeaderAnalytics.LeaderPivot.XAML.MAUI.Host;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        return builder.Build();
    }
}
//.UseMauiCommunityToolkitCore()
//.UseMauiCommunityToolkit()
//.UseMauiCommunityToolkitMarkup()