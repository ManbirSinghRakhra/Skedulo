using Skedulo.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Skedulo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Question3Page : ContentPage
    {
        Question3ViewModel viewModel;

        public Question3Page()
        {
            InitializeComponent();
            BindingContext = viewModel = new Question3ViewModel();

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.People.Count == 0)
                viewModel.LoadPeopleCommand.Execute(null);

        }
    }
}