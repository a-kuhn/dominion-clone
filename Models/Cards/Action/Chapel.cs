using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DominionClone.Models
{
    public class Chapel : Card
    {
        // trash up to 4 cards from your hand
        public override void Play(Player player)
        {
            //keep track of # of cards to trash
            int trashCount = 0;

            //keep track of which cards in player's hand
            List<int> trashIdx = new List<int>();

            //allow player to select up to 4 cards to trash
            while (trashCount <= 4)
            {
                //player can select card from hand to trash (trashCount ++)
                //OR player can submit 
                //on submit, selected cards are trashed (remove from player's deck, add to game's trash)
            }

            //trash selected cards
            foreach (int idx in trashIdx)
            {
                player.Trash(idx);
            }
        }

        public Chapel(string type = "Action", string title = "Chapel", int cost = 2) : base(type, title, cost) { }
    }
}