using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DominionClone.Models
{
    public class Vassal : Card
    {
        // +2 treasure; discard top card of your deck, if it's an action card, player may choose to play it
        public override void Play(Player player)
        {
            player.TreasureValueTotal += 2;
            Card cardDrawn = player.Deck[0];
            player.Deck.RemoveAt(0);
            if (cardDrawn.Type == "Action")
               {
                   //player can choose if they want to play cardDrawn
               }
            else {player.DiscardPile.Add(cardDrawn);}
        }

        public Vassal(string type = "Action", string title = "Vassal", int cost = 3) : base(type, title, cost) { }
    }
}