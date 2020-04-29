using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DominionClone.Models
{
    public class Duchy : Card
    {
        public Duchy(string type = "Victory", string title = "Duchy", int cost = 5, int vpValue = 3) : base(type, title, cost) { }

    }
}