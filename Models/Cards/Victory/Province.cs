using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DominionClone.Models
{
    public class Province : Card
    {
        public int VPValue { get; set; } = 6;
        public Province(string type = "Action", string title = "Province", int cost = 8) : base(type, title, cost) { }
    }
}