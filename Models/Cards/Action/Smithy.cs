using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DominionClone.Models
{
    public class Smithy : Card
    {
        // +3 Cards
        public int DrawCount { get; set; } = 3;

        public Smithy(string type = "Action", string title = "Smithy", int cost = 4, int vpValue = 0, int treasureValue = 0) : base(type, title, cost, vpValue, treasureValue) { }
    }
}