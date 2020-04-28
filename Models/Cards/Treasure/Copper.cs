using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DominionClone.Models.Cards.Treasure
{
    public class Copper : Card
    {
        public int Value { get; set; } = 1;
    }
}
