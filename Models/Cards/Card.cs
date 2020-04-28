using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DominionClone.Models
{
    public class Card
    {
        [Key]
        public int CardId { get; set; }
        public string Type { get; set; } //do we still want this prop?
        public string Title { get; set; }
        public int Cost { get; set; }

    }
}