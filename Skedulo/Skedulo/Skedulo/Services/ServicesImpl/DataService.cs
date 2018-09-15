using Newtonsoft.Json;
using Skedulo.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skedulo.Services.ServicesImpl
{
    public class DataService : IDataService
    {
        IRestService restService;
        public DataService()
        {
            restService = new RestService();
        }
        public async Task<List<Interests>> GetInterestsAsync()
        {
            var interests = new List<Interests>();
            var interestsContent = await restService.RefreshDataAsync($"http://{Constants.IpAddress}:3000/interests?personIds=1,2");
            interests = JsonConvert.DeserializeObject<List<Interests>>(interestsContent);
            return interests;
        }

        public async Task<List<People>> GetPeopleAsync()
        {
            var people = new List<People>();
            var peopleContent = await restService.RefreshDataAsync($"http://{Constants.IpAddress}:3000/people");
            people = JsonConvert.DeserializeObject<List<People>>(peopleContent);
            if (people.Any())
            {
                people = await PopulatePeopleWithInterestsAsync(people);
                people = await PopulatePeopleWithSkillsAsync(people);
            }
            return people;
        }

        public async Task<Richest> GetRichestPersonAsync()
        {
            var richest = new Richest();
            var richestContent = await restService.RefreshDataAsync($"http://{Constants.IpAddress}:3000/richest");
            richest = JsonConvert.DeserializeObject<Richest>(richestContent);
            return richest;
        }

        public async Task<List<Skills>> GetSkillsAsync()
        {
            var skills = new List<Skills>();
            var skillsContent = await restService.RefreshDataAsync($"http://{Constants.IpAddress}:3000/skills?personIds=1,2,3");
            skills = JsonConvert.DeserializeObject<List<Skills>>(skillsContent);
            return skills;
        }

        public async Task<List<People>> PopulatePeopleWithSkillsAsync(List<People> people)
        {
            var skills = await GetSkillsAsync();
            foreach (var skill in skills)
            {
                if (people.Any(c => c.Id.Equals(skill.PersonId)))
                    people.FirstOrDefault(c => c.Id.Equals(skill.PersonId)).Skills.Add(skill);
            }
            return people;
        }

        public async Task<List<People>> PopulatePeopleWithInterestsAsync(List<People> people)
        {
            var interests = await GetInterestsAsync();
            foreach (var interest in interests)
            {
                if (people.Any(c => c.Id.Equals(interest.PersonId)))
                    people.FirstOrDefault(c => c.Id.Equals(interest.PersonId)).Interests.Add(interest);
            }
            return people;
        }
    }
}
