using System.Collections.Generic;
using System.Threading.Tasks;

namespace Skedulo.Services
{
    public interface IRestService
    {
        Task<string> RefreshDataAsync(string url);
    }
}
