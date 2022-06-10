namespace PlatformLifecycleDemo;

using Microsoft.Maui.LifecycleEvents;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		MauiAppBuilder builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			})
			.ConfigureLifecycleEvents(events =>
			{
#if IOS
				events.AddiOS(ios => ios
					.OnActivated((_) => LogEvent("OnActivated"))
					.OnResignActivation((_) => LogEvent("OnResignActivation"))
					.DidEnterBackground((_) => LogEvent("DidEnterBackground"))
					.WillTerminate((_) => LogEvent("WillTerminate"))
					);
#endif
#if ANDROID
				events.AddAndroid(android => android
					.OnActivityResult((_, requestCode, __, ___) => LogEvent("OnActivityResult", requestCode.ToString()))
					.OnApplicationConfigurationChanged((_, requestCode) => LogEvent("OnApplicationConfigurationChanged", requestCode.ToString()))
					.OnApplicationCreate((_) => LogEvent("OnApplicationCreate"))
					.OnApplicationCreating((_) => LogEvent("OnApplicationCreating"))
					.OnApplicationLowMemory((_) => LogEvent("OnApplicationLowMemory"))
					.OnApplicationTrimMemory((_, requestCode) => LogEvent("OnApplicationTrimMemory", requestCode.ToString()))
					//.OnBackPressed((_) => LogEvent("OnBackPressed")) // How do I get this to log?
					.OnConfigurationChanged((_, requestCode) => LogEvent("OnConfigurationChanged", requestCode.ToString()))
					.OnCreate((_, __) => LogEvent("OnCreate"))
					.OnDestroy((_) => LogEvent("OnDestroy"))
					.OnNewIntent((_, requestCode) => LogEvent("OnNewIntent", requestCode.ToString()))
					.OnPause((_) => LogEvent("OnPause"))
					.OnPostCreate((_, requestCode) => LogEvent("OnPostCreate", requestCode?.ToString()))
					.OnPostResume((_) => LogEvent("OnPostResume"))
					.OnRequestPermissionsResult((_, requestCode, __, ___) => LogEvent("OnRequestPermissionsResult", requestCode.ToString()))
					.OnRestart((_) => LogEvent("OnRestart"))
					.OnRestoreInstanceState((_, requestCode) => LogEvent("OnRestoreInstanceState", requestCode.ToString()))
					.OnResume((_) => LogEvent("OnResume"))
					.OnSaveInstanceState((_, requestCode) => LogEvent("OnSaveInstanceState", requestCode.ToString()))
					.OnStart((_) => LogEvent("OnStart"))
					.OnStop((_) => LogEvent("OnStop"))
					);
#endif
#if WINDOWS
				events.AddWindows(windows => windows
							 .OnActivated((_, __) => LogEvent("OnActivated"))
							 .OnClosed((_, __) => LogEvent("OnClosed"))
							 .OnLaunched((_, __) => LogEvent("OnLaunched"))
							 .OnLaunching((_, __) => LogEvent("OnLaunching"))
							 .OnPlatformMessage((_, args) => LogEvent("OnPlatformMessage", args?.MessageId.ToString()))
							 //.OnPlatformWindowSubclassed((_, args) => LogEvent("OnPlatformWindowSubclassed", args?.ToString())) // This throws An unhandled exception of type 'System.StackOverflowException' occurred in Microsoft.Maui.dll
							 .OnResumed((_) => LogEvent("OnResumed"))
							 .OnVisibilityChanged((_, args) => LogEvent("OnVisibilityChanged:" + args?.Visible))
							 .OnWindowCreated((_) => LogEvent("OnWindowCreated"))
							 );
#endif
				static void LogEvent(string eventName, string type = null)
				{
					System.Diagnostics.Debug.WriteLine($"Life-cycle event: {eventName}{(type == null ? string.Empty : $" ({type})")}", "LifeCycleEvent");
				}
			});
		return builder.Build();
	}
}