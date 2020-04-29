using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DominionClone.Models
{
    public class Copper : Card
    {
        public int TreasureValue { get; set; } = 1;
        public Copper(string type = "Treasure", string title = "Copper", int cost = 0) : base(type, title, cost) { }
    }
}
