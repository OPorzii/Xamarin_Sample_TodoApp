using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Model;
using TodoApp.pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TodoApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListTodo : ContentPage
    {
        public ListTodo()
        {
            InitializeComponent();
        }

        private async void AddBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewTodoPage()
            {
                BindingContext = new Todo()
            });
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            List<Todo> todoList = await App.DbInstance.GetAllData();
            listTodo.ItemsSource = todoList.OrderByDescending(item => item.TimeStamp).ToList();
        }

        private async void ListTodo_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new NewTodoPage
                {
                    BindingContext = e.SelectedItem as Todo
                });
            }
        }
    }
}