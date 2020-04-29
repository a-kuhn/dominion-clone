using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DominionClone.Models
{
    public class Gardens : Card
    {
        // 1 VP per 10 cards in deck (round down)
        // player.VPTotal += Math.floor(deck.Count/10) --> needs to be recalculated every time player buys new card
        //? I don't think this needs an overriden play method. i think this means we need to add some code to Player.Buy() that will check Player.Deck for Gardens cards and recalculate VPTotal after every Buy
        public Gardens(string type = "Action", string title = "Gardens", int cost = 4) : base(type, title, cost) { }
    }
}