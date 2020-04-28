using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DominionClone.Models
{
    public class Gardens : Card
    {
        // cost = 4;
        // 1 VP per 10 cards in deck (round down)
        // deck.VP += Math.floor(deck.Count/10) --> needs to be recalculated every time players buys new card
    }
}