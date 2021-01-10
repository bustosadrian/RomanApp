using Microsoft.Extensions.DependencyInjection;
using Reedoo.API.Xamarin;
using Reedoo.NET.Client.Extensions.Bindings.Local;
using Reedoo.NET.Controller.Builder;
using Reedoo.NET.Messages.Output;
using Reedoo.NET.Storage.SQLite.Builder;
using RomanApp.Messages.Input;
using Serilog;
using System;
using Xamarin.Forms;

namespace RomanApp.Client.Mobile
{
    public partial class App : Application
    {
        private const string APP_NAME = "RomanApp";

        private ServiceCollection _services;

        private ServiceProvider _serviceProvider;

        private IHandlerBuilder _handlerBuilder;

        private XamarinClient _client;

        public App()
        {
            Device.SetFlags(new[] { "Shapes_Experimental", "Brush_Experimental" });

            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());

            LoadDependencies();

            LoadClient(_serviceProvider);

            var o = System.Globalization.CultureInfo.CurrentUICulture;
            o.ToString();
        }

        protected override void OnStart()
        {
            _client
                .LocalBinding(_handlerBuilder)

                .Application("RomanApp")
                .Room(RomanApp.Controller.Bootstrap.ROOM_ID)
                .Bind(new Credential()
                {
                    Id = "5d1e406f-5d13-4ce3-a74e-80c480e8c07e",
                    RoomId = "Room1",
                });
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        private void LoadDependencies()
        {
            _services = new ServiceCollection();
            ConfigureServices();
            ConfigureLogging();

            _serviceProvider = _services.BuildServiceProvider();
        }

        private void ConfigureServices()
        {
            _services
                .AddSingleton(typeof(IHandlerBuilder), x => new HandlerBuilder(x));
        }

        private void LoadClient(ServiceProvider serviceProvider)
        {
            _handlerBuilder = new RomanApp.Controller.Bootstrap().GetBuilder(_serviceProvider);

            _handlerBuilder.SQLiteStorage("sqlite")
                .Location(Environment.GetFolderPath(Environment.SpecialFolder.Personal))
                .Add();

            Reedoo.NET.Client.Builder.ClientBuilder builder =
                 new Reedoo.NET.Client.Builder.ClientBuilder(serviceProvider);
            builder.AddAssembly(GetType().Assembly);
            builder.NewApp(APP_NAME)
                .AddAssembly(GetType().Assembly)
                .AddAssembly(typeof(BackInput).Assembly)
                .Add();

            _client = builder.BuildXamarinClient();
            //_client.CredentialArrived += UWPClient_CredentialArrived;
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
