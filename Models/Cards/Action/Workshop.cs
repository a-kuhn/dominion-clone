using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DominionClone.Models
{
    public class Workshop : Card
    {
        //gain 1 card costing up to 4 Treasure

        public Workshop(string type = "Action", string title = "Workshop", int cost = 3) : base(type, title, cost) { }
    }
}