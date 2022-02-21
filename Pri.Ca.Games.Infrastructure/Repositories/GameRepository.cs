using Microsoft.EntityFrameworkCore;
using Pri.Ca.Games.Core.Entities;
using Pri.Ca.Games.Core.Interfaces.Repositories;
using Pri.Ca.Games.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.Ca.Games.Infrastructure.Repositories
{
    public class GameRepository : IGameRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly DbSet<Game> _games;

        public GameRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            _games = _applicationDbContext.Games;
        }
        public async Task AddGameAsync(Game toAdd)
        {
            await _games.AddAsync(toAdd);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task DeleteGameAsync(Game toDelete)
        {
            _games.Remove(toDelete);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task<Game> GetGameByIdAsync(int id)
        {
            return await _games
                .Include(g => g.Genres)
                .FirstOrDefaultAsync(g => g.Id == id);
        }

        public async Task<IEnumerable<Game>> GetGamesAsync()
        {
            return await _games
                .Include(g => g.Genres)
                .ToListAsync();
        }

        public async Task<IEnumerable<Game>> SearchGamesByTitleAsync(string needle)
        {
            var games = await GetGamesAsync();
            return games.Where(g => g.Name.ToUpper().Contains(needle.ToUpper()));
        }

        public async Task UpdateGameAsync(Game toUpdate)
        {
            _games.Update(toUpdate);
            await _applicationDbContext.SaveChangesAsync();
        }
    }
}
