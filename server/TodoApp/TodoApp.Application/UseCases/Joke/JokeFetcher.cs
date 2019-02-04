using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TodoApp.Application.UseCases.Joke
{
    public class JokeFetcher : IJokeFetcher
    {
        private class ChuckNorrisJokeModel
        {
            public string Value { get; set; }
            public string Icon_Url { get; set; }
        }

        public async Task<JokeOutput> GetRandomJoke()
        {
            const string url = "https://api.chucknorris.io/jokes/random";
            var webClient = new WebClient();
            var joke = await webClient.DownloadStringTaskAsync(url);
            var result = JsonConvert.DeserializeObject<ChuckNorrisJokeModel>(joke);

            if (result != null)
                return new JokeOutput
                {
                    Text = result.Value,
                    IconUrl = result.Icon_Url
                };

            return null;
        }
    }
}