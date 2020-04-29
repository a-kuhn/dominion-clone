using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DominionClone.Models
{
    public class Smithy : Card
    {
        // +3 Cards
        public override void Play(Player player)
        {
            player.Draw();
            player.Draw();
            player.Draw();
        }

        public Smithy(string type = "Action", string title = "Smithy", int cost = 4) : base(type, title, cost) { }
    }
}