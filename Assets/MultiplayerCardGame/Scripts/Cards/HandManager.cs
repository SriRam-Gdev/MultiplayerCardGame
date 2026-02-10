using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HandManager : MonoBehaviour
{
    public static HandManager Instance;

    public Text foldedText;


    public List<Card> hand = new List<Card>();
    public List<Card> selectedCards = new List<Card>();
    public List<Card> foldedCards = new List<Card>();

    int currentCost = 0;

    void Awake()
    {
        Instance = this;
        DealStartingHand();
    }

    void DealStartingHand()
    {
        hand.Clear();

        hand.Add(new Card(1, "Shield", 2, 3));
        hand.Add(new Card(2, "Thief", 1, 1));
        hand.Add(new Card(3, "Mage", 3, 4));

        Debug.Log("Starting hand dealt");
    }

    public void ToggleSelect(Card card)
    {
        if (selectedCards.Contains(card))
        {
            selectedCards.Remove(card);
            currentCost -= card.cost;
        }
        else
        {
            if (currentCost + card.cost > TurnManager.Instance.currentTurn)
                return;

            selectedCards.Add(card);
            currentCost += card.cost;
        }

        Debug.Log("Selected cards: " + selectedCards.Count);
    }

    
    public void FoldSelectedCards()
    {
        foldedCards.Clear();

        foreach (Card c in selectedCards)
            foldedCards.Add(c);

        selectedCards.Clear();
        currentCost = 0;

        if (foldedText != null)
        foldedText.text = "Folded: " + foldedCards.Count;


        Debug.Log("Folded cards: " + foldedCards.Count);
    }
}
