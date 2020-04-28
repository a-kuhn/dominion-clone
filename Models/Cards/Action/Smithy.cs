using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DominionClone.Models.Cards
{
    public class Smithy
    {
        public int DrawCount { get; set; } = 3;
    }
}