using System.Threading.Tasks;

namespace TodoApp.Application.UseCases.Joke
{
    /// <summary>
    /// Joke fetcher service
    /// </summary>
    public interface IJokeFetcher
    {
        /// <summary>
        /// Gets a random joke from remote api service
        /// </summary>
        /// <returns>Joke model</returns>
        Task<JokeOutput> GetRandomJoke();
    }
}