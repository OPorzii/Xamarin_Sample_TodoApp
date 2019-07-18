using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TodoApp.pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewTodoPage : ContentPage
    {
        public NewTodoPage()
        {
            InitializeComponent();


        }


        private async void Save_Clicked(object sender, EventArgs e)
        {
            var Item = (Todo)BindingContext;
            Item.TimeStamp = DateTime.Now;
            await App.DbInstance.SaveTodo(Item);
            await Navigation.PopAsync();
        }

        private async void Delete_Clicked(object sender, EventArgs e)
        {
            var Item = (Todo)BindingContext;
            var confirm = await DisplayAlert("Alert", "Confirm Delete?", "Yes", "No");
            if (confirm)
            {
                await App.DbInstance.DeleteTodo(Item);
                await Navigation.PopAsync();
            }

            

        }
    }
}