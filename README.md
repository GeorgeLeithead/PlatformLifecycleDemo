# Platform Lifecycle Demo
[See: App lifecycle](https://docs.microsoft.com/en-us/dotnet/maui/fundamentals/app-lifecycle) for official documentation.

.NET Multi-platform App UI (.NET MAUI) apps generally have four execution states: *not running*, *running*, *deactivated*, and *stopped*. .NET MAUI raises cross-platform lifecycle events on the `Window` class when an app transitions from the not running state to the running state, the running state to the deactivated state, the deactivated state to the stopped state, the stopped state to the running state, and the stopped state to the not running state.

:::image type="content" source="https://docs.microsoft.com/en-us/dotnet/maui/fundamentals/media/app-lifecycle/app-lifecycle.png" alt-text=".NET MAUI app lifecycle" border="false":::

The execution state of an app depends on the app's history. For example, when an app is installed for the first time, or a device is started, the app can be considered to be *not running*. When the app is started, the `Created` and `Activated` events are raised and the app is *running*. If a different app window gains focus, the `Deactivated` event is raised and the app is *deactivated*. If the user switches to a different app or returns to the device's Home screen, so that the app window is no longer visible, the `Deactivated` and `Stopped` events are raised and the app is *stopped*. If the user returns to the app, the `Resuming` event is raised and app is *running*. Alternatively, an app might be terminated by a user while it's running. In this situation the app is *deactivated* then *stopped*, the `Destroying` event is raised, and the app is *not running*. Similarly, a device might terminate an app while it's stopped, due to resource restrictions, and the `Destroying` event is raised and the app is *not running*.

In addition, .NET MAUI enables apps to be notified when platform lifecycle events are raised.

## Issue "App Lifecycle event OnResume called more than once." #7894
An issue was raised on GitHub for when the *OnResume* event was called more than once, specifically on the Windows platform.

[See GitHub for details](https://github.com/dotnet/maui/issues/7894) of the issue.

### Demo repository
This demo repository have been created to help validate that the issue exists, and/or has been resolved.  It is based on the exampled provided in the official documentation '[App lifecycle](https://docs.microsoft.com/en-us/dotnet/maui/fundamentals/app-lifecycle)'.

When the *Windows Machine* is used in debug, the following events occur, and the second _onResume_ should not occur:
```
LifeCycleEvent: Life-cycle event: OnLaunching
LifeCycleEvent: Life-cycle event: OnPlatformMessage (70)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (124)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (125)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (124)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (125)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (70)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (131)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (71)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (128)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (128)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (12)
CrossPlatformLifeCycleEvent: Cross-platform life-cycle event: OnStart : 1
LifeCycleEvent: Life-cycle event: OnWindowCreated
LifeCycleEvent: Life-cycle event: OnPlatformMessage (24)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (70)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (70)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (28)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (134)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (127)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (6)
LifeCycleEvent: Life-cycle event: OnActivated
LifeCycleEvent: Life-cycle event: OnPlatformMessage (127)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (36)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (15)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (133)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (20)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (127)
LifeCycleEvent: Life-cycle event: OnVisibilityChanged:True
LifeCycleEvent: Life-cycle event: OnPlatformMessage (71)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (5)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (3)
LifeCycleEvent: Life-cycle event: OnLaunched
LifeCycleEvent: Life-cycle event: OnPlatformMessage (799)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (49374)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (20)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (20)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (15)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (13)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (32)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (32)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (32)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (32)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (32)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (32)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (32)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (32)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (32)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (32)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (32)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (32)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (32)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (32)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (32)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (32)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (32)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (32)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (32)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (32)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (32)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (32)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (32)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (32)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (32)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (32)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (32)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (32)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (32)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (32)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (32)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (32)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (32)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (32)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (32)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (32)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (32)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (32)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (32)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (32)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (32)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (32)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (32)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (32)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (32)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (32)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (32)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (528)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (33)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (32)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (274)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (70)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (36)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (131)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (71)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (3)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (5)
CrossPlatformLifeCycleEvent: Cross-platform life-cycle event: OnSleep : 1
LifeCycleEvent: Life-cycle event: OnVisibilityChanged:False
LifeCycleEvent: Life-cycle event: OnPlatformMessage (134)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (6)
LifeCycleEvent: Life-cycle event: OnActivated
LifeCycleEvent: Life-cycle event: OnPlatformMessage (28)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (127)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (127)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (70)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (71)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (28)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (134)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (6)
CrossPlatformLifeCycleEvent: Cross-platform life-cycle event: OnResume : 1
LifeCycleEvent: Life-cycle event: OnResumed
LifeCycleEvent: Life-cycle event: OnActivated
LifeCycleEvent: Life-cycle event: OnPlatformMessage (274)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (19)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (70)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (36)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (131)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (133)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (20)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (71)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (3)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (5)
LifeCycleEvent: Life-cycle event: OnVisibilityChanged:True
LifeCycleEvent: Life-cycle event: OnPlatformMessage (641)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (642)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (61)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (61)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (7)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (6)
CrossPlatformLifeCycleEvent: Cross-platform life-cycle event: OnResume : 2
LifeCycleEvent: Life-cycle event: OnResumed
LifeCycleEvent: Life-cycle event: OnActivated
LifeCycleEvent: Life-cycle event: OnPlatformMessage (8)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (641)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (15)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (32)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (32)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (32)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (32)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (32)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (32)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (32)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (32)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (32)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (32)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (32)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (32)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (32)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (32)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (32)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (32)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (32)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (32)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (32)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (32)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (32)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (32)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (32)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (32)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (32)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (32)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (32)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (32)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (32)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (32)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (32)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (32)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (32)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (32)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (32)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (32)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (32)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (32)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (32)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (32)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (32)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (32)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (32)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (32)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (32)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (32)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (32)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (528)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (33)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (32)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (274)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (16)
LifeCycleEvent: Life-cycle event: OnClosed
CrossPlatformLifeCycleEvent: Cross-platform life-cycle event: OnSleep : 1
LifeCycleEvent: Life-cycle event: OnVisibilityChanged:False
LifeCycleEvent: Life-cycle event: OnPlatformMessage (528)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (20)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (641)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (61)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (61)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (7)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (144)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (70)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (71)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (134)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (6)
LifeCycleEvent: Life-cycle event: OnActivated
LifeCycleEvent: Life-cycle event: OnPlatformMessage (28)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (8)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (641)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (642)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (2)
LifeCycleEvent: Life-cycle event: OnPlatformMessage (130)
```

Then the *Android Emulator* is used in debug, the following events occur:
```
[0:] LifeCycleEvent: Life-cycle event: OnApplicationCreating
[0:] LifeCycleEvent: Life-cycle event: OnApplicationCreate
[0:] LifeCycleEvent: Life-cycle event: OnCreate
[0:] LifeCycleEvent: Life-cycle event: OnStart
[0:] CrossPlatformLifeCycleEvent: Cross-platform life-cycle event: OnStart : 1
[0:] LifeCycleEvent: Life-cycle event: OnPostCreate
[0:] LifeCycleEvent: Life-cycle event: OnResume
[0:] LifeCycleEvent: Life-cycle event: OnPostResume
[0:] LifeCycleEvent: Life-cycle event: OnPause
[0:] CrossPlatformLifeCycleEvent: Cross-platform life-cycle event: OnSleep : 1
[0:] LifeCycleEvent: Life-cycle event: OnStop
[0:] LifeCycleEvent: Life-cycle event: OnSaveInstanceState (Bundle[{android:viewHierarchyState=Bundle[{android:views={1=android.view.AbsSavedState$1@2de8efa, 16908290=android.view.AbsSavedState$1@2de8efa, 2131230775=android.view.AbsSavedState$1@2de8efa, 2131230786=android.view.AbsSavedState$1@2de8efa}}], android:lastAutofillId=1073741823, android:fragments=android.app.FragmentManagerState@7af3cab}])
[0:] LifeCycleEvent: Life-cycle event: OnApplicationTrimMemory (UiHidden)
[0:] CrossPlatformLifeCycleEvent: Cross-platform life-cycle event: OnResume : 1
[0:] LifeCycleEvent: Life-cycle event: OnRestart
[0:] LifeCycleEvent: Life-cycle event: OnStart
[0:] LifeCycleEvent: Life-cycle event: OnResume
[0:] LifeCycleEvent: Life-cycle event: OnPostResume
```