using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DominionClone.Models
{
    public class Gold : Card
    {
        public int TreasureValue { get; set; } = 3;
        public Gold(string type = "Action", string title = "Gold", int cost = 6) : base(type, title, cost) { }
    }
}