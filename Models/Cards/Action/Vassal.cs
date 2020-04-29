using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DominionClone.Models
{
    public class Vassal : Card
    {
        // +2 treasure; discard top card of your deck, if it's an action card, player may choose to play it

        // cardDrawn = player.Draw();
        // if (cardDrawn.type == Action)
        //    {player can choose to play or discard cardDrawn}
        // else {player.Discard(cardDrawn)}

        public Vassal(string type = "Action", string title = "Vassal", int cost = 3, int vpValue = 0, int treasureValue = 0) : base(type, title, cost, vpValue, treasureValue) { }
    }
}