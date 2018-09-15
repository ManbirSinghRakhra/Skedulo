using Skedulo.Services;
using Skedulo.Services.ServicesImpl;
using Xunit;
using System.Linq;

namespace Skedulo.IntegrationTests
{
    public class RestApiTests
    {
        public DataService CreateDefaultDataService()
        {
            return new DataService();
        }

        [Fact]
        public async System.Threading.Tasks.Task GetPeopleAsync_ReturnContainsListOfSkillsAsync()
        {
            IDataService dataService = CreateDefaultDataService();

            var people = await dataService.GetPeopleAsync();

            Assert.True(people.FirstOrDefault().Skills.Count > 0);
        }

        [Fact]
        public async System.Threading.Tasks.Task GetPeopleAsync_ReturnContainsListOfInterestsAsync()
        {
            IDataService dataService = CreateDefaultDataService();

            var people = await dataService.GetPeopleAsync();

            Assert.True(people.FirstOrDefault().Interests.Count > 0);
        }

        [Fact]
        public async System.Threading.Tasks.Task RefreshDataAsync_ReturnListOfSkillsAsync()
        {
            IDataService dataService = CreateDefaultDataService();

            var skills = await dataService.GetSkillsAsync();

            Assert.True(skills.Count > 0, skills.ToString());
        }


        [Fact]
        public async System.Threading.Tasks.Task GetPeopleAsync_ReturnListOfPeopleAsync()
        {
            IDataService dataService = CreateDefaultDataService();

            var people = await dataService.GetPeopleAsync();

            Assert.True(people.Count > 0, people.Count.ToString());
        }

        [Fact]
        public async System.Threading.Tasks.Task GetInterestsAsync_ReturnListOfInterestAsync()
        {
            IDataService dataService = CreateDefaultDataService();

            var interests = await dataService.GetInterestsAsync();

            Assert.True(interests.Count > 0, interests.Count.ToString());
        }


        [Fact]
        public async System.Threading.Tasks.Task GetRichestPersonAsync_RichestUrl_ReturnRichestPersonIdAsync()
        {
            IDataService dataService = CreateDefaultDataService();
            int expected = 1;

            var richest = await dataService.GetRichestPersonAsync();
            int actual = richest.RichestPerson;


            Assert.Equal(expected, actual);
        }
    }
}
