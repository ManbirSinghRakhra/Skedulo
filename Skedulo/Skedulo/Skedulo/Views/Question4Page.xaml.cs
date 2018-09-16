using Skedulo.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Skedulo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Question4Page : ContentPage
    {
        Question4ViewModel viewModel;


        public Question4Page()
        {
            InitializeComponent();
            BindingContext = viewModel = new Question4ViewModel();
            searchButton.IsEnabled = false;
        }

        private void SearchString_TextChanged(object sender, TextChangedEventArgs e)
        {
            viewModel.SearchString = e.NewTextValue;
            if (viewModel.SearchString.Length > 2)
            {
                searchButton.IsEnabled = true;
            }
            else
            {
                if(viewModel.SearchString.Length == 0)
                    viewModel.LoadItemsCommand.Execute(null);

                searchButton.IsEnabled = false;
            }
                
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        private void searchButton_Clicked(object sender, System.EventArgs e)
        {
            viewModel.LoadItemsCommand.Execute(null);
        }
    }
}