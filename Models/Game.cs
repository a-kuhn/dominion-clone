using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DominionClone.Models
{
    public class Game
    {
        public List<Card> BasicCards { get; set; }
        // public List<Card> KingdomCards { get; set; } //10 sets of 10 Action cards
        public int PlayerTurn { get; set; }
        public List<Player> Players { get; set; }
        public List<Card> Trash { get; set; }

        //do we want to store the log of turns here? what might that look like?

        //do we want a method here to check win conditions?

        //constructor: 
        //2 players (names=King & Queen), PlayerTurn=0 (player1), empty Trash, BasicCards
        Player p1 = new Player("King");
        Player p2 = new Player("Queen");

        //60 Copper, 40 Silver, 30 Gold -->really should be what's left over after making player's starting decks
        //8 each of Estate, Duchy, Province
        List<Card> baseSet;
        public List<Card> BuildBasicCards()
        {
            for (int i = 0; i < 60; i++)
            {
                Copper Copper = new Copper();
                baseSet.Add(Copper);
            }

            for (int i = 0; i < 40; i++)
            {
                Silver Silver = new Silver();
                baseSet.Add(Silver);
            }

            for (int i = 0; i < 30; i++)
            {
                Gold Gold = new Gold();
                baseSet.Add(Gold);
            }

            for (int i = 0; i < 8; i++)
            {
                Estate Estate = new Estate();
                baseSet.Add(Estate);
            }

            for (int i = 0; i < 8; i++)
            {
                Duchy Duchy = new Duchy();
                baseSet.Add(Duchy);
            }

            for (int i = 0; i < 8; i++)
            {
                Province Province = new Province();
                baseSet.Add(Province);
            }
            return baseSet;
        }

        public Game()
        {
            BasicCards = BuildBasicCards();
            PlayerTurn = 0;
            Players = new List<Player>() { p1, p2 };
            Trash = new List<Card>();
        }
    }
}