using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;
using System.Windows;
using WPF.Model;
using WPF.ViewModel;

namespace WPF
{
    public partial class App : Application
    {
        private static IHost __Host;
        public static IHost Host => __Host ??= EntryPoint.CreateHostBuilder(Environment.GetCommandLineArgs()).Build();

        private static Core __Core;
        //public static Core Core => __Core ??= Task.Run(() => new Core()).Result;
        public static Core Core => __Core ??= new Core();

        internal static void ConfigureServices(HostBuilderContext host, IServiceCollection services)
        {
            services.AddSingleton<MainWindowViewModel>();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var host = Host;
            await host.StartAsync().ConfigureAwait(false);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            var host = Host;
            await host.StopAsync().ConfigureAwait(false);
            host.Dispose();
            __Host = null;
        }
    }
}
