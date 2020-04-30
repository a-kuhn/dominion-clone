using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DominionClone.Models
{
    public class Player
    {

        // Player's Name
        public string Name { get; set; }

        /* 
            Player with most VP in their Deck at end of game is the winner
            this prop is modified when .Buy() is called and the new card.Type == "Victory"
        */
        public int TotalVP { get; set; }

        /* 
            Player's Cards will be in 1 of 4 stacks: Hand, Deck, InPlay, or DiscardPile.
        */
        public List<Card> Hand { get; set; }
        public List<Card> Deck { get; set; }
        public List<Card> DiscardPile { get; set; }
        public List<Card> InPlay { get; set; }

        /*
            Each turn, the Player has # Actions they can take, # Times they can Buy, and the total Treasure Value they could spend
        */
        public int Actions { get; set; }
        public int Buys { get; set; }
        public int TreasureValueTotal { get; set; }

        // Constructor
        public Player(string name)
        {
            Name = name;
            TotalVP = 0; //or should this be set to 3 because starting deck includes 3 estates?
            Hand = new List<Card>();
            Deck = new List<Card>();
            DiscardPile = new List<Card>();
            InPlay = new List<Card>();
            Actions = 1;
            Buys = 1;
            TreasureValueTotal = 0;
        }

        // Draw 1 Card from Deck to Hand
        public void Draw()
        {
            // If deck has no cards to draw, shuffle Discard into Deck
            if (Deck.Count == 0)
            {
                Shuffle();
            }
            // Removes card at idx 0 in Deck and appends to Hand
            Card addToHand = Deck[0];
            Deck.RemoveAt(0);
            Hand.Add(addToHand);
        }

        // Draws 5 times, to be used at the beginning of each turn
        public void DrawFive()
        {
            Draw();
            Draw();
            Draw();
            Draw();
            Draw();
        }

        // Given a Card (from field), Add to Discard
        public void Buy(Card cardFromGame)
        {
            //appends new card to discard pile
            DiscardPile.Add(cardFromGame);
            TreasureValueTotal -= cardFromGame.Cost;
            Buys--;
            if(cardFromGame.Type == "Victory")
            {
                TotalVP += cardFromGame.VPValue;
            }
        }

        // Move a card from Hand to Discard Pile
        public Card Play(int idxOfCardFromHand)
        {
            //remove & return chosen card from hand
            Card cardToPlay = Hand[idxOfCardFromHand];
            Hand.RemoveAt(idxOfCardFromHand);
            // DiscardPile.Add(cardToPlay);
            InPlay.Add(cardToPlay);
            return cardToPlay;
        }

        // Move all cards in InPlay to DiscardPile (To be called end of each turn)
        public void Flush()
        {
            while (InPlay.Count > 0)
            {
                Card cardToFlush = InPlay[0];
                InPlay.RemoveAt(0);
                DiscardPile.Add(cardToFlush);
            }
            return;
        }

        // Move a card from Hand to Trash
        public Card Trash(int idxOfCardToTrash)
        {
            //remove & return chosen card from hand
            Card cardToTrash = Hand[idxOfCardToTrash];
            Hand.RemoveAt(idxOfCardToTrash);
            return cardToTrash;
        }

        // Combine the Discard and Deck, Shuffle the order
        public void Shuffle()
        {
            //move all cards from discard to deck
            //randomly move cards around
            Deck.AddRange(DiscardPile);
            DiscardPile = new List<Card>();
            Random rand = new Random();
            Card temp;
            for (int i = 0; i < rand.Next(70, 300); i++)
            {
                int shuffleSpot = rand.Next(0, Deck.Count);
                temp = Deck[shuffleSpot];
                Deck.RemoveAt(shuffleSpot);
                Deck.Add(temp);
            }
        }

        // Move a card from Hand to Discard
        public void Discard(int idxOfCardToDiscard)
        {
            //remove selected card from hand & append to discard
            Card cardToDiscard = Hand[idxOfCardToDiscard];
            Hand.RemoveAt(idxOfCardToDiscard);
            DiscardPile.Add(cardToDiscard);
        }

        // Helper for GameComplete view: Calculate total VP of this player
        //!replaced with TotalVP prop & check for card type in .Buy()
        // public int GetVictoryPointTotal()
        // {
        //     int total_vp = 0;
        //     foreach (Card card in Hand)
        //     {
        //         if (card.Type == "Victory")
        //         {
        //             total_vp += card.VPValue;
        //         }
        //     }
        //     foreach (Card card in Deck)
        //     {
        //         if (card.Type == "Victory")
        //         {
        //             total_vp += card.VPValue;
        //         }
        //     }
        //     foreach (Card card in DiscardPile)
        //     {
        //         if (card.Type == "Victory")
        //         {
        //             total_vp += card.VPValue;
        //         }
        //     }
        //     return total_vp;
        // }



    }
}