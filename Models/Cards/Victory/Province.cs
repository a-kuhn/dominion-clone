using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DominionClone.Models.Cards.Victory
{
    public class Province : Card
    {
        public int Value { get; set; } = 6;
    }
}