﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
            var interestsContent = await restService.RefreshDataAsync($"http://{Constants.IpAddress}:3000/interests?personIds=1,2,3");
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
                people = await PopulatePeopleWithRichestAsync(people);
            }
            return people;
        }

        public async Task<List<People>> PopulatePeopleWithRichestAsync(List<People> people)
        {
            var richestPerson = await GetRichestPersonAsync();
            if (people.Any(c => c.Id.Equals(richestPerson.RichestPerson.ToString())))
            {
                var person = people.FirstOrDefault(c => c.Id.Equals(richestPerson.RichestPerson.ToString()));
                person.IsRichest = true;
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

        public async Task<List<Items>> GetGithubUsersAsync(string searchString)
        {
            var list_of_items = new List<Items>();
            var usersContent = await restService.RefreshDataAsync($"https://api.github.com/search/users?q={searchString}");
            JObject results = JObject.Parse(usersContent);
            var items = results["items"];
            foreach (var item in items)
            {
                list_of_items.Add(new Items
                {
                    avatar_url = (string)item["avatar_url"],
                    login = (string)item["login"],
                    score = (int)item["score"],
                    type = (string)item["type"]
                });
            }


            return list_of_items;
        }
    }
}
