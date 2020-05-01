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
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ INDEX ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public IActionResult Index()
        {
            return View();
        }

        // For START GAME button on Index
        [HttpPost("/newGame")]
        public IActionResult NewGame()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Game");
        }

        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ GAME ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
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

        // Helper Method
        public Game GetGameFromSession()
        {
            Game currentGame = null;
            if (HttpContext.Session.GetObjectFromJson<Game>("currentGame") == null)
            {
                currentGame = new Game(NewGame:true);
                // The first player starts with 5 cards drawn
                currentGame.Players[currentGame.PlayerTurn].DrawFive();
            }
            else {
                currentGame = HttpContext.Session.GetObjectFromJson<Game>("currentGame");
            }
            return currentGame;
        }

        // For PLAY buttons on Player Hand
        [HttpPost("/play")]
        public IActionResult Play(int HandIndex)
        {
            Game currentGame = GetGameFromSession();

            // Current turn player
            Player turnPlayer = currentGame.Players[currentGame.PlayerTurn];
            // player.Play(idx) removes the card from player.hand and returns it
            Card cardToPlay = turnPlayer.Play(HandIndex);

            if(cardToPlay.Type == "Action")
            {
                if (cardToPlay.Title == "Village")
                {
                    turnPlayer.Draw();
                    turnPlayer.Actions += 2;
                }
                else if (cardToPlay.Title == "Smithy")
                {
                    turnPlayer.Draw();
                    turnPlayer.Draw();
                    turnPlayer.Draw();
                }
                else if (cardToPlay.Title == "Festival")
                {
                    turnPlayer.TreasureValueTotal += 2;
                    turnPlayer.Actions ++;
                    turnPlayer.Buys++;
                }
                else if (cardToPlay.Title == "Market")
                {
                    turnPlayer.Draw();
                    turnPlayer.TreasureValueTotal ++;
                    turnPlayer.Actions ++;
                    turnPlayer.Buys++;
                }

                turnPlayer.Actions--;
            }
            // if it's a treasure card
            else
            {
                cardToPlay.Play(turnPlayer);
            }

            // Save game state in session
            HttpContext.Session.SetObjectAsJson("currentGame",currentGame);
            return RedirectToAction("Game");
        }

        // For PLAY ALL TREASURES button on Player Hand
        [HttpPost("/playAllTreasures")]
        public IActionResult PlayAllTreasures()
        {
            Game currentGame = GetGameFromSession();
            Player turnPlayer = currentGame.Players[currentGame.PlayerTurn];

            for (int i = 0; i < turnPlayer.Hand.Count; i++)
            {
                if (turnPlayer.Hand[i].Type == "Treasure")
                {
                    Card cardToPlay = turnPlayer.Play(i);
                    cardToPlay.Play(turnPlayer);
                    i--;
                }
            }

            // Save game state in session
            HttpContext.Session.SetObjectAsJson("currentGame",currentGame);
            return RedirectToAction("Game");
        }

        // For BUY buttons on Field Cards
        [HttpPost("/buy")]
        public IActionResult Buy(String cardTitle, String cardType)
        {
            Console.WriteLine("\n\n I want to buy a: " + cardTitle + "\n\n");

            Game currentGame = GetGameFromSession();
            Player turnPlayer = currentGame.Players[currentGame.PlayerTurn];

            if (cardType == "Treasure" || cardType == "Victory")
            {
                // Find the first card with given title on the Game Field
                Card cardToBuy = currentGame.BasicCards.FirstOrDefault(c=>c.Title == cardTitle);
                if (cardToBuy != null)
                {
                    // Move it from Field to Player's Discard
                    currentGame.BasicCards.Remove(cardToBuy);
                    turnPlayer.Buy(cardToBuy);
                }
                else {
                    // panic (button should be hidden in the View when not applicable anyways!)
                }
            }
            else
            {
                // Find the first card with given title on the Game Field
                Card cardToBuy = currentGame.KingdomCards.FirstOrDefault(c=>c.Title == cardTitle);
                if (cardToBuy != null)
                {
                    // Move it from Field to Player's Discard
                    currentGame.KingdomCards.Remove(cardToBuy);
                    turnPlayer.Buy(cardToBuy);
                }
                else {
                    // panic (button should be hidden in the View when not applicable anyways!)
                }
            }

            

            HttpContext.Session.SetObjectAsJson("currentGame", currentGame);
            return RedirectToAction("Game");
        }

        [HttpPost("/endTurn")]
        public IActionResult EndTurn()
        {
            Game currentGame = GetGameFromSession();
            Player endingPlayer = currentGame.Players[currentGame.PlayerTurn];

            // Flush ending player's InPlay stack to discard
            endingPlayer.Flush();

            // Flush ending player's hand to discard
            while (endingPlayer.Hand.Count != 0)
            {
                endingPlayer.Discard(0);
            }

            // Switch to next player (either increment or reset to first player)
            if (currentGame.PlayerTurn == currentGame.Players.Count - 1) {
                currentGame.PlayerTurn = 0;
                currentGame.TurnsPassed++;
            }
            else {currentGame.PlayerTurn++;}

            // Next player's stats for the turn resets
            currentGame.Players[currentGame.PlayerTurn].Actions = 1;
            currentGame.Players[currentGame.PlayerTurn].Buys = 1;
            currentGame.Players[currentGame.PlayerTurn].TreasureValueTotal = 0;
            // Next player draws 5
            currentGame.Players[currentGame.PlayerTurn].DrawFive();

            HttpContext.Session.SetObjectAsJson("currentGame", currentGame);
            return RedirectToAction("Game");
        }


        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ GAME OVER ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
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

        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ OTHER STRAGGLERS ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
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
