using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pri.Ca.Games.Core.Interfaces.Repositories;
using Pri.Ca.Games.Core.Interfaces.Services;
using Pri.Ca.Games.Web.Models;
using Pri.Ca.Games.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Pri.Ca.Games.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //private readonly IGameRepository _gameRepository;
        private readonly IGameService _gameService;

        public HomeController(ILogger<HomeController> logger,
            IGameService gameService)
        {
            _logger = logger;
            _gameService = gameService;
        }

        public async Task<IActionResult> Index()
        {
            //use the service class to get the games
            var games = await _gameService.GetGamesAsync();
            var homeIndexViewModel = new HomeIndexViewModel();
            homeIndexViewModel.Games = new List<BaseGameViewModel>();
            homeIndexViewModel.Errors = new List<string>();
            //test the IsSuccess bool
            if (games.IsSuccess == true)
            {
                
                homeIndexViewModel.Games = games.Games.Select(
                    g => new BaseGameViewModel
                    { Id = g.Id, Name = g.Name}
                    );
                return View(homeIndexViewModel);
            }
            //if we get here => error!  
            //add the validationerrors to the viewmodel
            homeIndexViewModel.Errors = games.ValidationErrors
                .Select(ve => ve.ErrorMessage); 
            return View(homeIndexViewModel);
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
