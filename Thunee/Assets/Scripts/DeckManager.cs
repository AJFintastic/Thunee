using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Manages the creation, storage, and shuffling of the Thunee deck.
/// </summary>
public class DeckManager : MonoBehaviour
{
    /// <summary>
    /// Singleton pattern (optional). Allows easy static access via DeckManager.Instance.
    /// </summary>
    public static DeckManager Instance;

    // ----------------------------------------------------------------------------------
    // Inspector-Assigned Sprites
    // ----------------------------------------------------------------------------------
    // Each array should have 6 elements in the order: 
    //   0 = Nine, 1 = Ten, 2 = Jack, 3 = Queen, 4 = King, 5 = Ace
    // Make sure to drag the correct sprite references into these arrays in the Inspector.

    [Header("Clubs Sprites (9, 10, J, Q, K, A)")]
    public Sprite[] clubsSprites = new Sprite[6];

    [Header("Diamonds Sprites (9, 10, J, Q, K, A)")]
    public Sprite[] diamondsSprites = new Sprite[6];

    [Header("Hearts Sprites (9, 10, J, Q, K, A)")]
    public Sprite[] heartsSprites = new Sprite[6];

    [Header("Spades Sprites (9, 10, J, Q, K, A)")]
    public Sprite[] spadesSprites = new Sprite[6];

    // ----------------------------------------------------------------------------------
    // Internal Deck Storage
    // ----------------------------------------------------------------------------------
    private List<Card> deck = new List<Card>();

    // ----------------------------------------------------------------------------------
    // Unity Lifecycle
    // ----------------------------------------------------------------------------------
    private void Awake()
    {
        // Implement a simple Singleton pattern (optional).
        if (Instance == null)
        {
            Instance = this;
            // Don't destroy between scenes if you want it persistent:
            // DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Optionally create & shuffle a deck on startup, or do it via GameManager.
    /// </summary>
    private void Start()
    {
        // Example usage: Build & Shuffle deck at start.
        // BuildDeck();
        // ShuffleDeck();
    }

    // ----------------------------------------------------------------------------------
    // Deck Management Methods
    // ----------------------------------------------------------------------------------

    /// <summary>
    /// Builds a fresh 24-card Thunee deck (9, 10, J, Q, K, A in each suit).
    /// Clears any existing cards from 'deck'.
    /// </summary>
    public void BuildDeck()
    {
        deck.Clear();

        // Build all 6 ranks for each suit
        BuildSuit(Suit.Clubs, clubsSprites);
        BuildSuit(Suit.Diamonds, diamondsSprites);
        BuildSuit(Suit.Hearts, heartsSprites);
        BuildSuit(Suit.Spades, spadesSprites);
    }

    /// <summary>
    /// Helper method to add 6 cards for one suit (Nine, Ten, Jack, Queen, King, Ace)
    /// using the provided sprite array.
    /// </summary>
    private void BuildSuit(Suit suit, Sprite[] suitSprites)
    {
        // Make sure suitSprites has exactly 6 references in the correct order.
        // If not, you'll need to verify in the Inspector.
        
        // Ranks in Thunee: Nine, Ten, Jack, Queen, King, Ace
        // The indices in the array correspond to 0->Nine, 1->Ten, 2->Jack, etc.
        
        deck.Add(new Card(suit, Rank.Nine,  suitSprites[0]));
        deck.Add(new Card(suit, Rank.Ten,   suitSprites[1]));
        deck.Add(new Card(suit, Rank.Jack,  suitSprites[2]));
        deck.Add(new Card(suit, Rank.Queen, suitSprites[3]));
        deck.Add(new Card(suit, Rank.King,  suitSprites[4]));
        deck.Add(new Card(suit, Rank.Ace,   suitSprites[5]));
    }

    /// <summary>
    /// Shuffles the deck using a modern Fisher-Yates shuffle algorithm.
    /// </summary>
    public void ShuffleDeck()
    {
        for (int i = deck.Count - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);
            Card temp = deck[i];
            deck[i] = deck[randomIndex];
            deck[randomIndex] = temp;
        }
    }

    /// <summary>
    /// Draws the "top" card (index 0) from the deck and removes it from the List.
    /// Returns null if the deck is empty.
    /// </summary>
    public Card DrawCard()
    {
        if (deck.Count == 0)
        {
            Debug.LogWarning("Deck is empty! Returning null card.");
            return null;
        }

        Card topCard = deck[0];
        deck.RemoveAt(0);
        return topCard;
    }

    /// <summary>
    /// Returns the deck as a List (if you ever need direct access).
    /// </summary>
    public List<Card> GetDeck()
    {
        return deck;
    }

    /// <summary>
    /// Returns the current number of cards remaining in the deck.
    /// </summary>
    public int CardsRemaining()
    {
        return deck.Count;
    }
}
