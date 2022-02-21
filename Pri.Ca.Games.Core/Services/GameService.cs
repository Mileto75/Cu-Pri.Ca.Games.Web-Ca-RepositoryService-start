using Pri.Ca.Games.Core.Entities;
using Pri.Ca.Games.Core.Interfaces.Repositories;
using Pri.Ca.Games.Core.Interfaces.Services;
using Pri.Ca.Games.Core.Services.Models.Games;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.Ca.Games.Core.Services
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;

        public GameService(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }
        public Task<GameResultModel> GetGameByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<GameResultModel> GetGamesAsync()
        {
            var games = await _gameRepository.GetGamesAsync();
            var gameResultModel = new GameResultModel();
            gameResultModel.IsSuccess = true;
            //check for games
            if(games == null || games.Count() == 0)
            {
                gameResultModel.ValidationErrors =
                    new List<ValidationResult>
                    {
                        new ValidationResult("No games found!")
                    };
                gameResultModel.IsSuccess = false;
                return gameResultModel;
            }
            //add games to resultmodel
            gameResultModel.Games = games.Select(g => new Game
            {
                Id = g.Id,
                Name = g.Name,
                Genres = g.Genres
            });
            return gameResultModel;
        }
    }
}
