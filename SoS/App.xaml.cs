using SoS.Services;
using Xamarin.Forms;


namespace SoS
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockAllEventDataStore>();
            DependencyService.Register<MockRegistrationDataStore>();
            DependencyService.Register<GroupingEventsService>();
            DependencyService.Register<IDatabase, MockDatabase>();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
