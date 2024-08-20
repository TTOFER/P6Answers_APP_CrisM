using P6Answers_APP_CrisM.Views;

namespace P6Answers_APP_CrisM
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new BienvenidaPage());
        }
    }
}
