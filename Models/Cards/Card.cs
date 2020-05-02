using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DominionClone.Models
{
    public class Card
    {
        // [Key]
        // public int CardId { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public int Cost { get; set; }
        public int VPValue { get; set; }
        public int TreasureValue { get; set; }

        public Card(string type, string title, int cost, int vPValue = 0, int treasureValue = 0)
        {
            Type = type;
            Title = title;
            Cost = cost;
            VPValue = vPValue;
            TreasureValue = treasureValue;
        }

        public virtual void Play(Player player)
        {
            player.TreasureValueTotal += TreasureValue;
        }
    }
}