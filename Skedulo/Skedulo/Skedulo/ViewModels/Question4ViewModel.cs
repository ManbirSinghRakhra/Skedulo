using Skedulo.Models;
using Skedulo.Services;
using Skedulo.Services.ServicesImpl;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Skedulo.ViewModels
{
    public class Question4ViewModel : BaseViewModel
    {
        public ObservableCollection<Items> Items { get; set; }
        public Command LoadItemsCommand { get; set; }
        public IDataService iDataService;
        public string SearchString { get; set; }
        public Question4ViewModel()
        {
            Title = "Question 4";
            Items = new ObservableCollection<Items>();
            iDataService = new DataService();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                if (SearchString.Length > 0)
                {
                    var listofUsers = await iDataService.GetGithubUsersAsync(SearchString);
                    foreach (var user in listofUsers)
                        Items.Add(user);
                }
            }
            catch (Exception exp)
            {
                Debug.WriteLine(exp.Message);
            }
            finally
            {
                IsBusy = false;
            }

        }
    }
}
