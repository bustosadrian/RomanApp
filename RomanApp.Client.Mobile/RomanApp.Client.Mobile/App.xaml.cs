using System;
using Xamarin.Forms;

namespace RomanApp.Client.Mobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());

            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {

        }

        protected override void OnStart()
        {
            StartBootstrap();
        }

        private void StartBootstrap()
        {
            Bootstrap bootstrap = new Bootstrap();
            bootstrap.OnClientLoaded += (s, e) =>
            {
                e.Client.StealthMode = false;
            };
            bootstrap.Start();
        }
    }
}
