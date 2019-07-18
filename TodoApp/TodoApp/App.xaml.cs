using System;
using System.IO;
using TodoApp.DB;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TodoApp
{
    public partial class App : Application
    {

        static TodoDB DB;
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new ListTodo());
        }

        public static TodoDB DbInstance
        {
            get
            {
                if (DB == null)
                    DB = new TodoDB(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TodoDB.db"));
                return DB;
            }
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
