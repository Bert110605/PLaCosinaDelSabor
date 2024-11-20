using Microsoft.Maui.Controls;
using LaCosinaDelSabor.Services;

namespace LaCosinaDelSabor
{
    public partial class App : Application
    {
        static MariaDBDatabase database;

        public static MariaDBDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new MariaDBDatabase();
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new BienvenidaPage());
        }
    }
}
