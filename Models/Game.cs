using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace DominionClone.Models
{
    public class Game
    {
        // All Victory and Treasure Cards on the Field live in this list
        public List<Card> BasicCards { get; set; } 
        
        // All Action Cards on the Field live in this list. Starts with 10 sets each of 10 types.
        // public List<Card> KingdomCards { get; set; }
        
        // All Cards in the Trash Pile
        public List<Card> Trash { get; set; }

        // Int to tell who's turn it is, 0 or 1. (i.e. if PlayerTurn is 0, it's Players[0]'s turn)
        public int PlayerTurn { get; set; }
        
        // List of all Players
        public List<Player> Players { get; set; }

        // Turns Passed since Game Started
        public int TurnsPassed { get; set; }
        // -> Down the road, we could turn this into a more comprehensive log of turns and actions!
        


        
        // Constructor: 
        public Game()
        {
            // Build the starting field cards and trash.
            BasicCards = BuildBasicCards();
            // KingdomCards = BuildKingdomCards();
            Trash = new List<Card>();
            
            // Game starts with first player's turn and on Turn #1
            PlayerTurn = 0;
            TurnsPassed = 1;

            // Builds a list with all Players (Currently 2)
            Player p1 = new Player("King");
            Player p2 = new Player("Queen");
            Players = new List<Player>() { p1, p2 };

            // Deal 7 copper and 3 Estate to each Player from the Field
            foreach (Player player in Players)
            {
                DealStartingCards(player);
            }
        }

        // Helper Method for the Constructor to initialize the beginning set of cards
            // Treasures: 60 Copper, 40 Silver, 30 Gold | Victory: 8 Each of Estate, Duchy, Province
        public List<Card> BuildBasicCards()
        {
            List<Card> baseSet = new List<Card>();
            
            for (int i = 0; i < 60; i++)
            {
                Copper Copper = new Copper();
                baseSet.Add(Copper);
            }
            // The rest is the same for different cards and # copies, so converted the rest to shorthand!!
            for (int i = 0; i < 40; i++){baseSet.Add(new Silver());}
            for (int i = 0; i < 30; i++){baseSet.Add(new Gold());}
            for (int i = 0; i < 8; i++){baseSet.Add(new Estate());}
            for (int i = 0; i < 8; i++){baseSet.Add(new Duchy());}
            for (int i = 0; i < 8; i++){baseSet.Add(new Province());}
            return baseSet;
        }

        // Helper Method for the Constructor to deal each player's starting Deck
        // 7 Copper and 3 Estate here, but assuming it varies by expansion, it's nice to come back and only have to adjust this method
        public void DealStartingCards(Player player)
        {
            // Deal the first 7 Coppers found in BasicCards to player
            for (int i = 0; i < 7; i++)
            {
                Card cardToDeal = BasicCards.FirstOrDefault(c=>c.Title == "Copper");
                if (cardToDeal != null)
                {
                    player.Deck.Add(cardToDeal);
                }
                else 
                {
                    // panic
                }
            }
            // Deal the first 3 Estates found in BasicCards to player
            for (int i = 0; i < 3; i++)
            {
                Card cardToDeal = BasicCards.FirstOrDefault(c=>c.Title == "Estate");
                if (cardToDeal != null)
                {
                    player.Deck.Add(cardToDeal);
                }
                else 
                {
                    // panic
                }
            }

            return;
        }
            
        // Helper Method for the Controller to check if Game is finished
        public bool GameFinished()
        {
            /*
                CONDITION #1: All Provinces are removed from field
            */
            // Faster method: If there are no more Providences, LINQ returns null, so we use that as the condition
            Card firstProvince = BasicCards.FirstOrDefault(c=>c.Title == "Province");
            if (firstProvince == null) 
            {
                return true;
            }

            /* 
                Condition #2: 3 Kinds of any card are removed from field
            */
            // Make counter dictionary
            Dictionary<string, int> counters = new Dictionary<string, int>();
            counters.Add("Duchy",0);
            counters.Add("Estate",0);
            counters.Add("Copper",0);
            counters.Add("Silver",0);
            counters.Add("Gold",0);

            // Build counter dictionary
            foreach (Card card in BasicCards)
            {
                if (card.Title == "Duchy"){ counters["Duchy"]++;}
                if (card.Title == "Estate"){ counters["Estate"]++;}
                if (card.Title == "Copper"){ counters["Copper"]++;}
                if (card.Title == "Silver"){ counters["Silver"]++;}
                if (card.Title == "Gold"){ counters["Gold"]++;}
            }

            // Count the zeros
            int depleted_card_types = 0;
            foreach (KeyValuePair<string, int> item in counters)
            {
                if (item.Value == 0)
                {
                    depleted_card_types++;
                }
                if (depleted_card_types >= 3)
                {
                    return true;
                }
            }

            return false;
        }
    }
}