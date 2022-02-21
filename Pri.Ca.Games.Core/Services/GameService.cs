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
        public async Task<GameResultModel> GetGameByIdAsync(int id)
        {
            //resultModel
            var gameResultModel = new GameResultModel();
            if(id < 1)
            {
                //gameResultModel.IsSuccess = false;
                gameResultModel.ValidationErrors = new List<ValidationResult>
                { new ValidationResult("Game not found")};
                return gameResultModel;
            }

            //get the game
            var game = await _gameRepository.GetGameByIdAsync(id);
            //perform null check
            if(game == null)
            {
                //gameResultModel.IsSuccess = false;
                gameResultModel.ValidationErrors = new List<ValidationResult>
                { new ValidationResult("Game not found")};
                return gameResultModel;
            }
            //if we get here, everything is ok
            gameResultModel.Games = new List<Game> {
                game
            };
            gameResultModel.IsSuccess = true;
            return gameResultModel;
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
