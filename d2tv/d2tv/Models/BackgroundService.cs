using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace d2tv.Models
{
    public class BackgroundService : IHostedService, IDisposable
    {
        private readonly IServiceScopeFactory scopeFactory;
        Timer timer;
      
        

        public BackgroundService(IServiceScopeFactory scopeFactory)
        {
            this.scopeFactory = scopeFactory;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(40));
            return Task.CompletedTask;
        }
        public void DoWork(object obj)
        {
           

            using (var scope = scopeFactory.CreateScope())
            {
                var d2context = scope.ServiceProvider.GetRequiredService<D2Context>();
               
            
             
              
                //proMatches.ForEach(match = proMatches.SingleOrDefault(m=>m.start_time==p)p => d2context.Matches.Update(new Match { dire_name=p.dire_name, dire_score=p.dire_score, dire_team_id=p.dire_team_id, duration=p.duration, leagueid=p.leagueid,
                //    league_name =p.league_name, radiant_win=p.radiant_win, radiant_name=p.radiant_name, radiant=p.radiant, radiant_score=p.radiant_score, radiant_team_id=p.radiant_team_id,
                //    series_id =p.series_id, series_type=p.series_type, start_time=p.start_time}));
               
               
                d2context.SaveChanges();
            }

            
        }
        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
        public void Dispose()
        {
            timer.Dispose();
        }
    }
}
