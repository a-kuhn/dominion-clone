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
            Game currentGame = null;
            if (HttpContext.Session.GetObjectFromJson<Game>("currentGame") == null)
            {
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine("There was no game in session");
                Console.WriteLine("There was no game in session");
                Console.WriteLine("There was no game in session");
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                currentGame = new Game();
            }
            else {
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine("Found a game in session");
                Console.WriteLine("Found a game in session");
                Console.WriteLine("Found a game in session");
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                currentGame = HttpContext.Session.GetObjectFromJson<Game>("currentGame");

                // for some reason, the game pulled out of session will have double # cards???
            }
            
            // Save game state in session
            HttpContext.Session.SetObjectAsJson("currentGame",currentGame);


            /*
                    TESTING SESSION
            */
            String test = "begin Game() method";
            if (HttpContext.Session.GetString("sessionTest") == null)
            {
                test = "session was empty";
            }
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("Game method");
            Console.WriteLine(test);
            Console.WriteLine(test);
            Console.WriteLine(test);
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

            HttpContext.Session.SetString("sessionTest",test);


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


        [HttpGet("/startTurn")]
        public IActionResult StartTurn()
        {
            Game currentGame = null;
            if (HttpContext.Session.GetObjectFromJson<Game>("currentGame") == null)
            {
                currentGame = new Game();
            }
            else {
                currentGame = HttpContext.Session.GetObjectFromJson<Game>("currentGame");
            }

            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("StartTurn: drawing 5");
            Console.WriteLine("Before:");
            Console.WriteLine("Hand has this many: "+ currentGame.Players[currentGame.PlayerTurn].Hand.Count);
            Console.WriteLine("Deck has this many: "+ currentGame.Players[currentGame.PlayerTurn].Deck.Count);
            
            // Draw 5
            currentGame.Players[currentGame.PlayerTurn].DrawFive();

            Console.WriteLine("After:");
            Console.WriteLine("Hand has this many: "+ currentGame.Players[currentGame.PlayerTurn].Hand.Count);
            Console.WriteLine("Deck has this many: "+ currentGame.Players[currentGame.PlayerTurn].Deck.Count);
            
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            // Save game state in session
            HttpContext.Session.SetObjectAsJson("currentGame",currentGame);


            /*
                    TESTING SESSION
            */
            String test = "begin startTurn() method";
            if (HttpContext.Session.GetString("sessionTest") == null)
            {
                test = "session was empty";
            }
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("startTurn method");
            Console.WriteLine(test);
            Console.WriteLine(test);
            Console.WriteLine(test);
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

            test = "after print";
            HttpContext.Session.SetString("sessionTest",test);



            return RedirectToAction("Game");
        }


        [HttpPost("/play")]
        public IActionResult Play(int HandIndex)
        {
            Game currentGame = HttpContext.Session.GetObjectFromJson<Game>("currentGame");
            if (currentGame == null)
            {
                currentGame = new Game();
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

            HttpContext.Session.SetObjectAsJson("currentGame",currentGame);
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
