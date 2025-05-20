using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Client.Models
{
    public static class GameClient
    {
        private static readonly List<Game> games = new()
        {
            new Game()
            {
                Id=1,
                Name="IGI",
                Genre="War",
                Price=20.01M,
                ReleaseDate=new DateTime(1992,2,1)
            },
            new Game()
            {
                Id=2,
                Name="Spider Man",
                Genre="Fighting",
                Price=25.01M,
                ReleaseDate=new DateTime(1995,3,2)
            }
        };
        public static Game[] GetGames()
        {
            return games.ToArray();
        }

        public static void AddGame(Game game)
        {
            game.Id = games.Max(game => game.Id) + 1;
            games.Add(game);
        }

        public static Game GetGame(int id)
        {
            return games.Find(game => game.Id == id) ?? throw new Exception("Could not find game!");
        }

        public static void UpdateGame(Game updatedGame)
        {
            Game existingGame = GetGame(updatedGame.Id);
            existingGame.Name = updatedGame.Name;
            existingGame.Genre = updatedGame.Genre;
            existingGame.Price = updatedGame.Price;
            existingGame.ReleaseDate = updatedGame.ReleaseDate;
        }

        public static void DeleteGame(int id)
        {
            Game game = GetGame(id);
            games.Remove(game);
        }
    }

}