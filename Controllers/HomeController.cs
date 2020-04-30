using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DominionClone.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace DominionClone.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // Helper Method
        public Game GetGameFromSession()
        {
            Game currentGame = null;
            if (HttpContext.Session.GetObjectFromJson<Game>("currentGame") == null)
            {
                currentGame = new Game(NewGame:true);
            }
            else {
                currentGame = HttpContext.Session.GetObjectFromJson<Game>("currentGame");
            }
            return currentGame;
        }

        [HttpGet("/game")]
        public IActionResult Game()
        {
            Game currentGame = GetGameFromSession();

            // Save game to session
            HttpContext.Session.SetObjectAsJson("currentGame", currentGame);

            // if game IS over, redirect to game finished screen
            if (currentGame.GameFinished())
            {
                return RedirectToAction("GameComplete");
            }
            // if game is NOT over, keep rendering the same board with updated stats
            return View(currentGame);
        }

        [HttpPost("/startTurn")]
        public IActionResult StartTurn()
        {
            Game currentGame = GetGameFromSession();
            // Draw 5
            currentGame.Players[currentGame.PlayerTurn].DrawFive();

            // Save game state in session
            HttpContext.Session.SetObjectAsJson("currentGame",currentGame);
            
            return RedirectToAction("Game");
        }


        [HttpPost("/play")]
        public IActionResult Play(int HandIndex)
        {
            Game currentGame = HttpContext.Session.GetObjectFromJson<Game>("currentGame");
            if (currentGame == null)
            {
                currentGame = new Game(NewGame:true);
            }

            // Current turn player
            Player turnPlayer = currentGame.Players[currentGame.PlayerTurn];
            // player.Play(idx) removes the card from player.hand and returns it
            Card cardToPlay = turnPlayer.Play(HandIndex);
            // card's play method will mutate whatever player given
            cardToPlay.Play(turnPlayer);

            // Save game state in session
            HttpContext.Session.SetObjectAsJson("currentGame",currentGame);
            return RedirectToAction("Game");
        }


        // SAMPLE: Each action/purchase will be a button on the View that calls its respective method here.
        [HttpPost("/buyCard")]
        public IActionResult BuyCard(String cardTitleToBuy)
        {
            Game currentGame = HttpContext.Session.GetObjectFromJson<Game>("currentGame");

            // Find the first card with given title on the Game Field
            // Add it to Player's Discard
            // Remove it from field

            HttpContext.Session.SetObjectAsJson("currentGame", currentGame);
            return RedirectToAction("DisplayPlayer");
        }


        [HttpGet("/gameComplete")]
        public IActionResult GameComplete()
        {
            Game currentGame = HttpContext.Session.GetObjectFromJson<Game>("currentGame");
            if (currentGame == null)
            {
                return RedirectToAction("Index");
            }
            return View(currentGame);
        }


        // Page to test SignalR... delete if obsolete
        [HttpGet("/chatTest")]
        public IActionResult ChatTest()
        {
            return View();
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

    public static class SessionExtensions
    {
        // MAKE SURE EACH HAND-MADE CLASS HAS A PARAMETER-LESS CONSTRUCTOR!!!
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            string value = session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
}
