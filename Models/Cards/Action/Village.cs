using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DominionClone.Models
{
    public class Village : Card
    {
        //+1 Card; +2 Actions
        public override void Play(Player player)
        {
            Console.WriteLine("\n\n\n\n test: this is Village Version");
            player.Draw();
            player.Actions += 2;
        }

        public Village(string type = "Action", string title = "Village", int cost = 3) : base(type, title, cost) { }

    }
}