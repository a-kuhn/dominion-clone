using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DominionClone.Models
{
    public class Festival : Card
    {
        //+2 Actions; +1 Buy; +2 Treasure
        public override void Play(Player player)
        {
            player.TreasureValueTotal += 2;
            player.Actions ++;
            player.Buys++;
        }

        public Festival(string type="Action", string title="Festival", int cost=5) : base(type, title, cost) { }
    }
}