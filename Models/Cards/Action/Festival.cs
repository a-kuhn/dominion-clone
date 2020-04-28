using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DominionClone.Models.Cards
{
    public class Festival : Card
    {
        public int ActionCount { get; set; } = 2;
        public int BuyCount { get; set; } = 1;
        public int TreasureCount { get; set; } = 2;
    }
}