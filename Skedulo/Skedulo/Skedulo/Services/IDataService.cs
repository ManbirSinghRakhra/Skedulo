using Skedulo.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Skedulo.Services
{
    public interface IDataService
    {
        Task<List<People>> GetPeopleAsync();
        Task<List<Skills>> GetSkillsAsync();
        Task<List<Interests>> GetInterestsAsync();
        Task<Richest> GetRichestPersonAsync();
        Task<List<Items>> GetGithubUsersAsync(string searchString);

    }
}
