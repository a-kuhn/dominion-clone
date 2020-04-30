using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DominionClone.Models
{
    public class Copper : Card
    {
        public Copper(string type = "Treasure", string title = "Copper", int cost = 0, int vPValue = 0, int treasureValue = 1) : base(type, title, cost, vPValue, treasureValue) { }
    }
}
