using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DominionClone.Models
{
    public class Market : Card
    {
        //+1 Card; +1 Action; +1 Buy; +1 Treasure

        public override void Play(Player player)
        {
            player.Draw();
            player.TreasureValueTotal ++;
            player.Actions ++;
            player.Buys++;
        }

        public Market(string type = "Action", string title = "Market", int cost = 5) : base(type, title, cost) { }
    }
}