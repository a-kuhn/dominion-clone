using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DominionClone.Models
{
    public class Game
    {
        [Key]
        public int GameId { get; set; }
        public object BasicCards { get; set; }
        public object KingdomCards { get; set; }
        public int PlayerTurn { get; set; }
        public bool GameWon { get; set; } //not sure this is necessary 

        public List<Player> Players { get; set; }
        public List<Card> Trash { get; set; }

        //do we want to store the log of turns here? what might that look like?

        //do we want a method here to check win conditions?

        //do we want to have a constructor here with the all the starter cards?
    }
}