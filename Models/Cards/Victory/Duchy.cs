using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DominionClone.Models
{
    public class Duchy : Card
    {
        public int VPValue { get; set; } = 3;
        public Duchy(string type = "Action", string title = "Duchy", int cost = 5) : base(type, title, cost) { }
    }
}