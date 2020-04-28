using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DominionClone.Models
{
    public class ActionCard : Card
    {
        public object Actions { get; set; }
        //or maybe this is split into possible actions
        //public int IncTreasue {get;set;} //would represent any increase in spending power
        //public int IncAction {get;set;} //would represent any increase in # of actions
        //public int IncBuy {get;set;} //would represent any increase in # of buys
        //with this organization, how would we handle unique actions?

        //methods:
        //unique actions could be written as a method...maybe
    }
}