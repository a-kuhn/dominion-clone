using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DominionClone.Models
{
    public class Gardens : Card
    {
        // 1 VP per 10 cards in deck (round down)
        // deck.VP += Math.floor(deck.Count/10) --> needs to be recalculated every time players buys new card
        public Gardens(string type = "Action", string title = "Gardens", int cost = 4, int vpValue = 0, int treasureValue = 0) : base(type, title, cost, vpValue, treasureValue) { }
    }
}