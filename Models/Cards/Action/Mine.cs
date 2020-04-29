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
        public int TrashTreasure { get; set; } = 1;

        public Mine(string type = "Action", string title = "Mine", int cost = 5, int vpValue = 0, int treasureValue = 0) : base(type, title, cost, vpValue, treasureValue) { }
    }
}