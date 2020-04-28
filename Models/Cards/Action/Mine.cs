using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DominionClone.Models
{
    public class Mine : Card
    {
        // trash a treasure card up from your hand
        // Gain a treasure card up to 3 more Cost than what was trashed
        public int TrashTreasure { get; set; } = 1;
    }
}