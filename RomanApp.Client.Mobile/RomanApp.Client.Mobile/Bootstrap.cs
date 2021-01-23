using Microsoft.Extensions.DependencyInjection;
using Reedoo.API.Xamarin;
using Reedoo.NET.Client;
using Reedoo.NET.Client.Builder;
using Reedoo.NET.Client.Extensions.Bindings.Local;
using Reedoo.NET.Controller.Builder;
using Reedoo.NET.Messages.Output;
using Reedoo.NET.Storage.SQLite.Builder;
using RomanApp.Messages.Input;
using Serilog;
using System;
using System.Threading.Tasks;

namespace RomanApp.Client.Mobile
{
    public class Bootstrap
    {
        private const string APP_NAME = "RomanApp";

        private ServiceCollection _services;

        private ServiceProvider _serviceProvider;

        private IHandlerBuilder _handlerBuilder;

        private XamarinClient _client;

        private Bootstrap()
        {

        }

        #region Singletone

        private static Bootstrap _instance;
        public static Bootstrap Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Bootstrap();
                }

                return _instance;
            }
        }

        #endregion

        public async void Load()
        {
            if (!IsLoaded)
            {
                IsLoaded = true;
                await Task.Run(() =>
                {
                    LoadDependencies();

                    LoadClient();

                    BindClient();
                });
            }
        }

        public void Start()
        {
            _client.StealthMode = false;
            _client.RunLastNavigation();
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

        private void ConfigureLogging()
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

        private void LoadClient()
        {
            var builder = LoadClientBuilder(_serviceProvider);

            _client = builder.BuildXamarinClient();
        }

        private ClientBuilder LoadClientBuilder(ServiceProvider serviceProvider)
        {
            ClientBuilder retval = null;

            _handlerBuilder = new RomanApp.Controller.Bootstrap().GetBuilder(_serviceProvider);

            _handlerBuilder.SQLiteStorage("sqlite")
                .Location(Environment.GetFolderPath(Environment.SpecialFolder.Personal))
                .Add();

            retval = new ClientBuilder(serviceProvider);
            retval.AddAssembly(GetType().Assembly);
            retval.NewApp(APP_NAME)
                .AddAssembly(GetType().Assembly)
                .AddAssembly(typeof(BackInput).Assembly)
                .Add();

            return retval;
        }

        public void BindClient()
        {
            _client.StealthMode = true;
            _client.StageChanged += Client_StageChanged;
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

        

        private void Client_StageChanged(object sender, ClientStageEventArgs e)
        {
            switch (e.Stage)
            {
                case ClientStage.Ready:
                    RaiseOnClientLoaded();
                    break;
            }
        }

        #region Events

        public event EventHandler<ClientLoadedEventArgs> OnClientLoaded;
        private void RaiseOnClientLoaded()
        {
            OnClientLoaded?.Invoke(this, new ClientLoadedEventArgs()
            {
                Client = _client
            });
        }

        #endregion

        #region Properties

        public bool IsLoaded
        {
            get;
            private set;
        }


        #endregion
    }

    public class ClientLoadedEventArgs : EventArgs
    {
        #region Properties

        public XamarinClient Client
        {
            get;
            set;
        }

        #endregion
    }
}
