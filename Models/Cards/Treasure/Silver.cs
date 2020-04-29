using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DominionClone.Models
{
    public class Silver : Card
    {
        public int TreasureValue { get; set; } = 2;
        public Silver(string type = "Treasure", string title = "Silver", int cost = 3) : base(type, title, cost) { }
    }
}