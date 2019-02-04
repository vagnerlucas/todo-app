using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR.Hubs;
using TodoApp.Application.UseCases.Joke;

namespace TodoApp.WebApi.Hub
{
    /// <summary>
    /// Socket service for the TodoApp
    /// </summary>
    [HubName("TodoAppHub")]
    public class TodoAppHub : Microsoft.AspNet.SignalR.Hub
    {
        private readonly IJokeFetcher _jokeFetcher;

        public TodoAppHub(IJokeFetcher jokeFetcher)
        {
            _jokeFetcher = jokeFetcher;
            Task.Run(DisplayRandomJoke);
        }

        /// <summary>
        /// Fetch random joke and send to the hub client
        /// </summary>
        /// <returns>Task</returns>
        private async Task DisplayRandomJoke()
        {
            while (true)
            {
                var joke = await _jokeFetcher.GetRandomJoke();

                if (joke != null)
                    Clients.All.TellJoke(joke);

                Thread.Sleep(TimeSpan.FromMinutes(2));
             }
        }
    }
}