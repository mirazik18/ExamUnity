using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using d2tv.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace d2tv.Controllers
{
    public class HomeController : Controller
    {
       List<News> news = new List<News>();
        private D2Context d2Context;
        List<Team> teams = new List<Team>();
        List<Player> players = new List<Player>();
        public HomeController(D2Context d2Context)
        {
            this.d2Context = d2Context;
            news = d2Context.News.ToList();
            teams = d2Context.Teams.ToList();
            players = d2Context.Players.ToList();
            
        }
        // GET: d2tv
        public ActionResult Index()
        {
            return View();
        }

        // GET: d2tv/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: d2tv/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: d2tv/Create
        [System.Web.Http.HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: d2tv/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: d2tv/Edit/5
        [System.Web.Http.HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: d2tv/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: d2tv/Delete/5
        [System.Web.Http.HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [Authorize]
      
        public ViewResult GetNews()
        {
            // news = new List<News>
            //{  
            //    new News{ Title="Test", Body="Som", Image="why"}

            //};
            // news.ForEach(p => d2Context.News.Add(p));
            // d2Context.SaveChanges();
            var a = User;

            ViewBag.News = news;
            return View();
        }
        [Authorize]
        public ViewResult GetDetailNew(int id)
        {
            News news2 = news.SingleOrDefault(p => p.Id == id);
            ViewBag.News = news2;
            return View();
        }
        public ViewResult Ranking()
        {
            ViewBag.Teams = teams;
            return View();
        }
       public ViewResult GetAllPlayers()
        {
            ViewBag.Players = players;
            ViewBag.Teams = teams;
            return View();
        }
        public ViewResult GetDetailPlayer(int id)
        {
            Player player = players.SingleOrDefault(p => p.Id == id); 
            ViewBag.Player = players.SingleOrDefault(p => p.Id == id);
            Team team= teams.FirstOrDefault(p => p.Id == player.TeamId);
            ViewBag.Team = team;
            return View();
        }
        public ViewResult GetAllTeams()
        {
          
            ViewBag.Teams = teams;
            return View();
        }
        public ViewResult GetDetailTeam(int id)
        {
            Team team = teams.SingleOrDefault(p => p.Id == id);
            ViewBag.Team = teams.SingleOrDefault(p => p.Id == id);
            List<Player> players2 = new List<Player>();
            foreach(var player in players)
            {
                if (player.TeamId == team.Id)
                {
                    players2.Add(player);
                }
            }
            ViewBag.Players = players2;
            return View();
        }
        [System.Web.Http.HttpGet]
        public ViewResult AddNew()
        {
            ViewBag.Context = d2Context;
            return View();
        }
        [System.Web.Http.HttpPost]
        public RedirectResult CreateNew(News news2)
        {
            if(news.Where(currentTitle => currentTitle.Title == news2.Title).ToList().Count > 0)
            {
                return Redirect("~/Home/AddNew");
            }
            return Redirect("~/Home/GetNews");
        }

        
    }
}