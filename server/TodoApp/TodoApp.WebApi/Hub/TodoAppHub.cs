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
    [HubName("TodoAppHub")]
    public class TodoAppHub : Microsoft.AspNet.SignalR.Hub
    {
        private readonly IJokeFetcher _jokeFetcher;

        public TodoAppHub(IJokeFetcher jokeFetcher)
        {
            _jokeFetcher = jokeFetcher;
            Task.Run(DisplayRandomJoke);
        }

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