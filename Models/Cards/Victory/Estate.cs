using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DominionClone.Models
{
    public class Estate : Card
    {
        public int VPValue { get; set; } = 1;
        public Estate(string type = "Victory", string title = "Estate", int cost = 2) : base(type, title, cost) { }
    }
}