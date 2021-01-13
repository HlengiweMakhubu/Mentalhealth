using Mentalhealth.ViewModels;
using Mentalhealth.Views;
using Prism;
using Prism.Ioc;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Mentalhealth
{
    public partial class App
    {
        public App() : this(null) { }
        public App(IPlatformInitializer initializer): base(initializer)
        {


        }

        protected override async void OnInitialized() 
        {
            InitializeComponent();
            await NavigationService.NavigateAsync("MasterDetail/NavigationPage/loginPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();

            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();

           
            containerRegistry.RegisterForNavigation<loginPage, loginPageViewModel>();
            containerRegistry.RegisterForNavigation<MasterDetail, MasterDetailViewModel>();
            containerRegistry.RegisterForNavigation<RegPage, RegPageViewModel>();
           

        }
    }
}
