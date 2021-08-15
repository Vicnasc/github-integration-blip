using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Octokit;

namespace Api.Reposiories
{
    public class GitHubRepository : IGithubRepository
    {
        private readonly GitHubClient _client;
        public GitHubRepository(GitHubClient client)
        {
            _client = client;
        }

        private async Task<Repository> GetRepository(int pos)
        {
            SearchRepositoriesRequest request = new()
            {
                Language = Language.CSharp,
                User = "takenet",
                Order = SortDirection.Ascending
            };

            SearchRepositoryResult repositories = await _client.Search.SearchRepo(request);

            List<Repository> repositoriesList = repositories.Items.ToList();

            repositoriesList.Sort((x, y) => x.CreatedAt.CompareTo(y.CreatedAt));

            return repositoriesList[pos];
        }

        public async Task<string> GetDescription(int pos)
        {
            var repository = await GetRepository(pos);

            return repository.Description;
        }

        public async Task<string> GetPicture()
        {
            User user = await _client.User.Get("takenet");

            return user.AvatarUrl;
        }

        public async Task<string> GetTitle(int pos)
        {
            var repository = await GetRepository(pos);

            return repository.Name;
        }
    }
}