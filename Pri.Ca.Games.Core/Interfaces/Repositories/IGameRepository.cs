using Pri.Ca.Games.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.Ca.Games.Core.Interfaces.Repositories
{
    public interface IGameRepository
    {
        //talks to the Game database table
        //define cruds
        Task<IEnumerable<Game>> GetGamesAsync();
        Task<Game> GetGameByIdAsync(int id);
        Task AddGameAsync(Game toAdd);
        Task UpdateGameAsync(Game toUpdate);
        Task DeleteGameAsync(Game toDelete);
        Task<IEnumerable<Game>> SearchGamesByTitleAsync(string needle);
    }
}
