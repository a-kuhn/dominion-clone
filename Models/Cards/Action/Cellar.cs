using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DominionClone.Models
{
    public class Cellar : Card
    {
        // +1 Action;
        // discard any # of cards, then draw that many
        public void Play(Player player)
        {
            int discardCount = 0;
            while (discardCount <= player.Hand.Count)
            {
                //prompt player to select cards from hand to discard (discardCount++) or submit
                //on submit, all selected cards are discarded and deck.Draw() discardCount times
            }
        }

        public Cellar(string type="Action", string title="Cellar", int cost=2) : base(type, title, cost){}
    }
}