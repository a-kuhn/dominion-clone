using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DominionClone.Models
{
    public class Estate : Card
    {
        public Estate(string type = "Victory", string title = "Estate", int cost = 2, int vPValue = 1, int treasureValue = 0) : base(type, title, cost, vPValue, treasureValue) { }
    }
}