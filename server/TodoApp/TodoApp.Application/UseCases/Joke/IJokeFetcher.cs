using System.Threading.Tasks;

namespace TodoApp.Application.UseCases.Joke
{
    public interface IJokeFetcher
    {
        Task<JokeOutput> GetRandomJoke();
    }
}