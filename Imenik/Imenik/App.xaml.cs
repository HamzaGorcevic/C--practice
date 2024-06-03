using Imenik.Model;
using Imenik.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Imenik
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IServiceProvider serviceProvider;
        public App()
        {
            // insliarti microsofto , dependency injetion
            ServiceCollection services = new ServiceCollection();
            ConfigureServices();

        }

        public void ConfigureServices(ServiceContainer services)
        {
            services.AddScoped<IEventAggregator, EventAggregator() > ();
            services.AddScoped<IFriendService, FriendService>();
            services.AddScoped<IFriendDetailsViewModel, FriendsListViewModel>();
            services.AddSingleton<MainWindow>();


// kad god je injectovan interface IEventAggregator ti koristi objekat klase EventAggreagit jihu se bakazu y DI continaeru. Scoped->trajace jednu sesiju, Transiant->Svaki put se kreira nova instanca te klase kada se injectuje, Singletin->jedna instanca /objekat za ceo zivotni vek aplikacije

        }

        public void App_Run()
        {
            var main = serviceProvider.GetService<MainWindow>();
            main.show();
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            App_Run();
        }
    }
}
