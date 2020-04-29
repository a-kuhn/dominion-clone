using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DominionClone.Models
{
    public class Province : Card
    {
        public Province(string type = "Victory", string title = "Province", int cost = 8, int vpValue = 6) : base(type, title, cost) { }
    }
}