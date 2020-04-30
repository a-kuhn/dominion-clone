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

        [HttpGet("/game")]
        public IActionResult Game()
        {
            Game currentGame = HttpContext.Session.GetObjectFromJson<Game>("currentGame");
            if (currentGame == null)
            {
                currentGame = new Game();
            }

            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("Current Game Info");
            Console.WriteLine("# Cards:" + currentGame.BasicCards.Count);
            Console.WriteLine("Player 1's Hand:" + currentGame.Players[0].Hand.Count);
            Console.WriteLine("Player 1's Deck:" + currentGame.Players[0].Deck.Count);
            Console.WriteLine("Player 1's DiscardPile:" + currentGame.Players[0].DiscardPile.Count);
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

            HttpContext.Session.SetObjectAsJson("currentGame", currentGame);


            // if currentGame IS over, redirect to game finished screen
            if (currentGame.GameFinished())
            {
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine("Game is finished");
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                return RedirectToAction("GameComplete");
            }
            // if currentGame is NOT over, keep rendering the same board with updated stats
            return View(currentGame);
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
