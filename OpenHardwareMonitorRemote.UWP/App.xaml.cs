﻿using System;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Navigation;
using Cimbalino.Toolkit.Controls;
using OpenHardwareMonitorRemote.UWP.Views;
using OpenHardwareMonitorRemote.UWP.Views.UserControls;

namespace OpenHardwareMonitorRemote.UWP
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App
    {
        public static CoreDispatcher UiDispatcher;

        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            InitializeComponent();
            Suspending += OnSuspending;
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="e">Details about the launch request and process.</param>
        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            UiDispatcher = CoreWindow.GetForCurrentThread().Dispatcher;

            var rootFrame = Window.Current.Content as HamburgerFrame;

            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (rootFrame == null)
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                rootFrame = new HamburgerFrame
                {
                    Header = new HamburgerTitleBar
                    {
                        Title = "Open Hardware Monitor Remote"
                    },
                    Pane = new HamburgerMenu()
                };
                rootFrame.Navigated += RootFrame_Navigated;
                SystemNavigationManager.GetForCurrentView().BackRequested += OnBackRequested;
                UpdateBackButton(rootFrame);

                rootFrame.NavigationFailed += OnNavigationFailed;

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    //TODO: Load state from previously suspended application
                }

                // Place the frame in the current Window
                Window.Current.Content = rootFrame;
            }

            if (e.PrelaunchActivated == false)
            {
                if (rootFrame.Content == null)
                {
                    // When the navigation stack isn't restored navigate to the first page,
                    // configuring the new page by passing required information as a navigation
                    // parameter
                    rootFrame.Navigate(typeof(ConnectionsPage), e.Arguments);
                }
                // Ensure the current window is active
                Window.Current.Activate();
            }
        }
        private static void RootFrame_Navigated(object sender, NavigationEventArgs e)
        {
            var frame = (HamburgerFrame)sender;

            UpdateBackButton(frame);
        }

        private static void UpdateBackButton(HamburgerFrame frame)
        {
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = frame.CanGoBack
                ? AppViewBackButtonVisibility.Visible
                : AppViewBackButtonVisibility.Collapsed;
        }

        private static void OnBackRequested(object sender, BackRequestedEventArgs backRequestedEventArgs)
        {
            var frame = Window.Current.Content as HamburgerFrame;
            if (frame?.CanGoBack != true) return;

            backRequestedEventArgs.Handled = true;
            frame.GoBack();
        }
        
        private static void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }
        
        private static void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            //TODO: Save application state and stop any background activity
            deferral.Complete();
        }
    }
}
