using Microsoft.Extensions.DependencyInjection;
using MVVMNavigationWPF.Core;
using MVVMNavigationWPF.MVVM.ViewModel;
using MVVMNavigationWPF.Services;
using System.Configuration;
using System.Data;
using System.Windows;

namespace MVVMNavigationWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        private readonly ServiceProvider _serviceProvider;
        public App() 
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<MainWindow>(provider => new MainWindow
            {
                DataContext = provider.GetRequiredService<MainViewModel>()
            }) ;

            services.AddSingleton<MainViewModel>();
            services.AddSingleton<HomeViewModel>();
            services.AddSingleton<SettingsViewModel>();

            services.AddSingleton<INavigationService,NavigationService>();

            services.AddSingleton<Func<Type,ViewModel>>(serviceProvider => 
            viewModelType=> (ViewModel)serviceProvider.GetRequiredService(viewModelType));

            _serviceProvider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {

            var mainWindow = _serviceProvider.GetService<MainWindow>();

            if (mainWindow != null)
            {
                mainWindow.Show();
            }
            else
            {
                // Maneja el caso donde mainWindow es null.
                // Por ejemplo, puedes lanzar una excepción o registrar un mensaje de error.
                throw new InvalidOperationException("MainWindow could not be resolved.");
            }

            base.OnStartup(e);
        }
    }

}
