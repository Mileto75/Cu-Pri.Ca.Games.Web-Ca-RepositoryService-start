using Microsoft.EntityFrameworkCore;
using Pri.Ca.Games.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.Ca.Games.Infrastructure.Data.Seeding
{
    public static class Seeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var games = new Game[]{
                new Game {Id = 1,Name = "Fifa2008" },
                new Game {Id = 2, Name = "Skyrim" },
                new Game {Id = 3,Name = "Halo" }
            };
            var genres = new Genre[] {
                new Genre {Id = 1,Name="Action"},
                new Genre {Id = 2,Name="Shooter"},
                new Genre {Id = 3,Name="Fantasy"},
            };

            //koppeltabel
            var gameGenres = new[] { 
                new {GamesId=1,GenresId=1},
                new {GamesId=1,GenresId=2},
                new {GamesId=1,GenresId=3},
                new {GamesId=2,GenresId=1},
                new {GamesId=2,GenresId=2},
                new {GamesId=2,GenresId=3},
                new {GamesId=3,GenresId=1},
                new {GamesId=3,GenresId=2},
                new {GamesId=3,GenresId=3}
            };

            //hasdata methods
            modelBuilder.Entity<Game>().HasData(games);
            modelBuilder.Entity<Genre>().HasData(genres);
            modelBuilder.Entity($"{nameof(Game)}{nameof(Genre)}").HasData(gameGenres);
        }
    }
}
