using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DominionClone.Models
{
    public class Silver : Card
    {
        public Silver(string type = "Treasure", string title = "Silver", int cost = 3, int treasureValue = 2) : base(type, title, cost) { }
    }
}