using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DominionClone.Models
{
    public class Chapel : Card
    {
        //cost = 2;
        // trash up to 4 cards from your hand
        public void Play()
        {
            int trashCount = 0;
            while (trashCount <= 4)
            {
                //player can select card from hand to trash (trashCount ++)
                //OR player can submit 
                //on submit, selected cards are trashed (remove from player's deck, add to game's trash)
            }
        }
    }
}