// App.xaml.cs
using Microsoft.Maui.Controls;

namespace ProfileApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new ProfilePage());
        }
    }
}