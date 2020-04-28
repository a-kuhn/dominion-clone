using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DominionClone.Models
{
    public class Deck 
    {
        [Key]
        public int DeckId { get; set; }

        public int VPScore { get; set; } //keeps track of VP/score for each player

        public int GameId { get; set; } //not sure this is necessary
        public Game Game { get; set; } //not sure this is necessary

        public int PlayerId { get; set; }
        public Player Player { get; set; }

        public List<Card> Cards { get; set; }

        //do we want a constructor here with the starter deck? 7 copper, 3 estates

        
        //methods:
        //shuffle, deal
        public Card Deal()
        {
            Card dealtCard = Cards[0];
            Cards.RemoveAt(0);
            return dealtCard;
        }

        public void AddToDeck(Card cardToAdd)
        {
            Cards.Add(cardToAdd);
        }
    }
}