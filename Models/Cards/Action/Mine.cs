using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DominionClone.Models
{
    public class Mine : Card
    {
        // trash a treasure card from your hand
        // Gain a treasure card up to 3 more Cost than what was trashed
        public override void Play(Player player)
        {
            //need some player input to supply idx of card to trash & get cost
            //?int cardCost = player.Hand[idxOfCardToTrash].Cost;
            //?player.Trash(idxOfCardToTrash);

            //need to filter game's list of cards
            // (c --> c.Type == "Treasure") && (c --> c.Cost <= cardCost + 3)
            // player can only add card to deck from this filtered list

            //?player.Deck.Add(selectedTreasure);
        }
        public Mine(string type = "Action", string title = "Mine", int cost = 5) : base(type, title, cost) { }
    }
}