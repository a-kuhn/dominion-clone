using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DominionClone.Models
{
    public class Market : Card
    {
        // when we instantiate it and the player draws this card then you can like Market.DrawCount and add it’s value to a method that increases the players hand and gives the player a card from their deck
        public int DrawCount { get; set; } = 1;
        public int ActionCount { get; set; } = 1;
        public int BuyCount { get; set; } = 1;
        public int TreasureCount { get; set; } = 1;
    }
}