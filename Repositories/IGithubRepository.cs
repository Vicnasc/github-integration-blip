using System.Threading.Tasks;
using Octokit;

namespace Api.Reposiories
{
    public interface IGithubRepository
    {

        public Task<string> GetTitle(int pos);
        public Task<string> GetDescription(int pos);
        public Task<string> GetPicture();
    }
}