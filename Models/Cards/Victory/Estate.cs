using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DominionClone.Models
{
    public class Estate : Card
    {
        public Estate(string type = "Victory", string title = "Estate", int cost = 2, int vpValue = 1) : base(type, title, cost) { }
    }
}