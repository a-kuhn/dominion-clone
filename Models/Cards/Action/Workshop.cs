using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DominionClone.Models
{
    public class Workshop : Card
    {
        //cost = 3
        //gain 1 card costing up to 4 Treasure
        //when played, should require user input to continue game
        //user must select a card from the Game with cost <= 4 treasure
    }
}