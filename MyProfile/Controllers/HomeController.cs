using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyProfile.Models;
using MyProfile.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MyProfile.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork<Owner> _owner;
        private readonly IUnitOfWork<PortfolioItem> _portfolio;

        public HomeController(IUnitOfWork<Owner> owner, IUnitOfWork<PortfolioItem> portfolio)
        {
            this._owner = owner;
            this._portfolio = portfolio;
        }

            public IActionResult Index()
            {
                var homeViewModel = new HomeViewModel
                {
                    Owner = _owner.Entity.GetAll().First(),
                    portfolioItems = _portfolio.Entity.GetAll().ToList()
                };
                return View(homeViewModel);
            }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
