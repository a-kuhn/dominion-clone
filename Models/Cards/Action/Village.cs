using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DominionClone.Models
{
    public class Village : Card
    {
        public int DrawCount { get; set; } = 1;
        public int ActionCount { get; set; } = 2;

    }
}