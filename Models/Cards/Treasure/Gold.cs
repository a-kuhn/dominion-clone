using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DominionClone.Models
{
    public class Gold : Card
    {
        public Gold(string type = "Treasure", string title = "Gold", int cost = 3, int vpValue = 0, int treasureValue = 3) : base(type, title, cost, vpValue, treasureValue) { }
    }
}