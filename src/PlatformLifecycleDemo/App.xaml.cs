namespace PlatformLifecycleDemo;

public partial class App : Application
{
	private int ResumeCount, SleepCount, StartCount = 0;

	public App()
	{
		InitializeComponent();
		MainPage = new AppShell();
	}

	/// <summary>Cross-platform life-cycle event: Resumed.</summary>
	/// <remarks>This cross-platform event maps to different platform events:
	/// Android = OnRestart
	/// iOS = WillEnterForeground
	/// Windows = Resumed
	/// </remarks>
	protected override void OnResume()
	{
		base.OnResume();
		ResumeCount++;
		SleepCount = 0; // Reset the sleep count
		LogEvent(nameof(OnResume), ResumeCount);
	}

	/// <summary>Cross-platform life-cycle event: Stopped</summary>
	/// <remarks>This cross-platform event maps to different platform events:
	/// Android = OnStop
	/// iOS = DidEnterBackground
	/// Windows = VisibilityChanged
	/// </remarks>
	protected override void OnSleep()
	{
		base.OnSleep();
		SleepCount++;
		ResumeCount = 0; // Reset the resume count
		LogEvent(nameof(OnSleep), SleepCount);
	}

	/// <summary>Cross-platform life-cycle event: Created</summary>
	/// <remarks>This cross-platform event maps to different platform events:
	/// Android = OnPostCreate
	/// iOS = FinishedLaunching
	/// Windows = Created
	/// </remarks>
	protected override void OnStart()
	{
		base.OnStart();
		StartCount++;
		LogEvent(nameof(OnStart), StartCount);
	}

	private static void LogEvent(string eventName, int eventCount)
	{
		System.Diagnostics.Debug.WriteLine($"Cross-platform life-cycle event: {eventName} : {eventCount}", "CrossPlatformLifeCycleEvent");
	}
}