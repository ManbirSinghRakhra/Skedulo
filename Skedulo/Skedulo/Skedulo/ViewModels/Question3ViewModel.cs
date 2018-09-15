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
    public class Question3ViewModel : BaseViewModel
    {
        public ObservableCollection<People> People { get; set; }
        public Command LoadPeopleCommand { get; set; }
        public IDataService iDataService;
        public Question3ViewModel()
        {
            Title = "Question 3";
            People = new ObservableCollection<People>();
            iDataService = new DataService();
            LoadPeopleCommand = new Command(async () => await ExecuteLoadPeopleCommand());
        }

        async Task ExecuteLoadPeopleCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                People.Clear();
                var listofPeople = await iDataService.GetPeopleAsync();
                foreach(var people in listofPeople)
                {
                    People.Add(people);
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
