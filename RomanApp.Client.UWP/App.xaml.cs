﻿
using Microsoft.Extensions.DependencyInjection;
using Reedoo.API.UWP;
using Reedoo.NET.Client.Extensions.Bindings.Local;
using Reedoo.NET.Controller.Builder;
using Reedoo.NET.Messages.Output;
using Reedoo.NET.Storage.SQLite.Builder;
using RomanApp.Messages.Input;
using Serilog;
using System;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace RomanApp.Client.UWP
{
    sealed partial class App : Application
    {
        private const string APP_NAME = "RomanApp";

        private ServiceCollection _services;

        private ServiceProvider _serviceProvider;

        private IHandlerBuilder _handlerBuilder;

        private UWPClient _uwpClient;

        public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;
            App.Current.UnhandledException += Current_UnhandledException;
        }

        private void Current_UnhandledException(object sender, Windows.UI.Xaml.UnhandledExceptionEventArgs e)
        {
            try
            {
                _uwpClient.HandleError(e.Exception);
                e.Handled = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="e">Details about the launch request and process.</param>
        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;

            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (rootFrame == null)
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                rootFrame = new Frame();

                rootFrame.NavigationFailed += OnNavigationFailed;

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    //TODO: Load state from previously suspended application
                }

                // Place the frame in the current Window
                Window.Current.Content = rootFrame;

                LoadDependencies();

                LoadClient(_serviceProvider);

                _uwpClient
                    .LocalBinding(_handlerBuilder)

                    .Application("RomanApp")
                    .Room(RomanApp.Controller.Bootstrap.ROOM_ID)
                    .Bind(new Credential()
                    {
                        Id = "5d1e406f-5d13-4ce3-a74e-80c480e8c07e",
                        RoomId = "Room1",
                    });

            }

            if (e.PrelaunchActivated == false)
            {
                if (rootFrame.Content == null)
                {
                    // When the navigation stack isn't restored navigate to the first page,
                    // configuring the new page by passing required information as a navigation
                    // parameter
                    rootFrame.Navigate(typeof(MainPage), e.Arguments);
                }
                // Ensure the current window is active
                Window.Current.Activate();
            }
        }

        /// <summary>
        /// Invoked when Navigation to a certain page fails
        /// </summary>
        /// <param name="sender">The Frame which failed navigation</param>
        /// <param name="e">Details about the navigation failure</param>
        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            //TODO: Save application state and stop any background activity
            deferral.Complete();
        }

        private void LoadClient(ServiceProvider serviceProvider)
        {
            _handlerBuilder = new RomanApp.Controller.Bootstrap().GetBuilder(_serviceProvider);
            _handlerBuilder.SQLiteStorage("sqlite")
                .Location(Windows.Storage.ApplicationData.Current.LocalFolder.Path)
                .Add();

            Reedoo.NET.Client.Builder.ClientBuilder builder =
                new Reedoo.NET.Client.Builder.ClientBuilder(serviceProvider);
            builder.AddAssembly(GetType().Assembly);
            builder.NewApp(APP_NAME)
                .AddAssembly(GetType().Assembly)
                .AddAssembly(typeof(BackInput).Assembly)
                .Add();

            _uwpClient = builder.BuildUWPClient();
            //_uwpClient.CredentialArrived += UWPClient_CredentialArrived;
        }

        void LoadDependencies()
        {
            _services = new ServiceCollection();
            ConfigureServices();
            ConfigureLogging();

            _serviceProvider = _services.BuildServiceProvider();
        }

        void ConfigureServices()
        {
            _services.AddSingleton(typeof(IHandlerBuilder), x => new HandlerBuilder(x));
        }

        void ConfigureLogging()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Debug()
                .CreateLogger();

            _services.AddLogging(configure =>
            {
                configure.AddSerilog();
            });
        }
    }
}
