using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DominionClone.Models
{
    public class Player
    {
        //!!Commented out anything that is not needed until DB is added
        // [Key]
        // public int UserId { get; set; }

        // [Required(ErrorMessage = " is required")]
        // [MinLength(2, ErrorMessage = " must be at least 2 characters long.")]
        // public string Name { get; set; }


        // [Required(ErrorMessage = " is required")]
        // [EmailAddress]
        // public string Email { get; set; }

        // [Required(ErrorMessage = " is required")]
        // [MinLength(8, ErrorMessage = " must be at least 8 characters long.")]
        // // [PasswordRegEx]
        // public string Password { get; set; }

        // [NotMapped]
        // [Required(ErrorMessage = " is required")]
        // [Compare(nameof(Password), ErrorMessage = " does not match password.")]
        // public string PWConfirm { get; set; }

        // [Required]
        // public DateTime CreatedAt { get; set; } = DateTime.Now;

        // [Required]
        // public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public List<Card> Hand { get; set; }
        public List<Card> Deck { get; set; }
        public List<Card> DiscardPile { get; set; }

        public void Draw()
        {
            //removes card at idx 0 in Deck and appends to Hand
            Card addToHand = Deck[0];
            Deck.RemoveAt(0);
            Hand.Add(addToHand);
        }

        public void Buy(Card cardFromGame)
        {
            //appends new card to discard pile
            DiscardPile.Add(cardFromGame);
        }

        public Card Play(int idxOfCardFromHand)
        {
            //remove & return chosen card from hand
            Card cardToPlay = Hand[idxOfCardFromHand];
            Hand.RemoveAt(idxOfCardFromHand);
            return cardToPlay;
        }

        public Card Trash(int idxOfCardToTrash)
        {
            //remove & return chosen card from hand
            Card cardToTrash = Hand[idxOfCardToTrash];
            Hand.RemoveAt(idxOfCardToTrash);
            return cardToTrash;
        }

        public void Shuffle()
        {
            //move all cards from discard to deck
            //randomly move cards around
            Deck = DiscardPile;
            DiscardPile = new List<Card>();
            Random rand = new Random();
            Card temp;
            for (int i = 0; i < rand.Next(70, 300); i++)
            {
                int shuffleSpot = rand.Next(0, 13);
                temp = Deck[shuffleSpot];
                Deck.RemoveAt(shuffleSpot);
                Deck.Add(temp);
            }
        }

        public void Discard(int idxOfCardToDiscard)
        {
            //remove selected card from hand & append to discard
            Card cardToDiscard = Hand[idxOfCardToDiscard];
            Hand.RemoveAt(idxOfCardToDiscard);
            DiscardPile.Add(cardToDiscard);
        }
    }
}