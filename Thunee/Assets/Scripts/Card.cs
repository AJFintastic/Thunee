using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Possible suits in Thunee.
/// </summary>
public enum Suit 
{ 
    Clubs, 
    Diamonds, 
    Hearts, 
    Spades 
}

/// <summary>
/// Possible ranks in Thunee (9, 10, J, Q, K, A).
/// </summary>
public enum Rank 
{ 
    Nine, 
    Ten, 
    Jack, 
    Queen, 
    King, 
    Ace 
}

/// <summary>
/// Represents a single card in Thunee.
/// </summary>
[System.Serializable]
public class Card
{
    public Suit suit;         // The card's suit (Clubs, Diamonds, Hearts, Spades)
    public Rank rank;         // The card's rank (Nine, Ten, Jack, Queen, King, Ace)
    public Sprite cardSprite; // The visual sprite for this card

    /// <summary>
    /// Constructor to create a Card with suit, rank, and sprite.
    /// </summary>
    public Card(Suit s, Rank r, Sprite sprite)
    {
        suit = s;
        rank = r;
        cardSprite = sprite;
    }

    /// <summary>
    /// Returns the Thunee-specific point value for this card:
    /// J = 30, 9 = 20, A = 11, 10 = 10, K = 3, Q = 2.
    /// </summary>
    public int GetThuneePointValue()
    {
        switch (rank)
        {
            case Rank.Jack:
                return 30;
            case Rank.Nine:
                return 20;
            case Rank.Ace:
                return 11;
            case Rank.Ten:
                return 10;
            case Rank.King:
                return 3;
            case Rank.Queen:
                return 2;
            default:
                return 0; // Should not happen for the valid Thunee ranks
        }
    }
}

