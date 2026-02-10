using System.Collections.Generic;
using UnityEngine;

public class RevealManager : MonoBehaviour
{
    public static RevealManager Instance;

    void Awake()
    {
        Instance = this;
    }

    public void StartReveal(List<Card> myCards, List<Card> opponentCards)
    {
        bool iGoFirst = ScoreManager.Instance.myScore >= 
                        ScoreManager.Instance.opponentScore;

        Debug.Log(iGoFirst ? "I reveal first" : "Opponent reveals first");

        int max = Mathf.Max(myCards.Count, opponentCards.Count);

        for (int i = 0; i < max; i++)
        {
            if (iGoFirst)
            {
                RevealMy(i, myCards);
                RevealOpponent(i, opponentCards);
            }
            else
            {
                RevealOpponent(i, opponentCards);
                RevealMy(i, myCards);
            }
        }
    }

    void RevealMy(int index, List<Card> cards)
    {
        if (index >= cards.Count) return;

        Card card = cards[index];
        Debug.Log("My card revealed: " + card.name);
        ScoreManager.Instance.AddMyScore(card.power);
    }

    void RevealOpponent(int index, List<Card> cards)
    {
        if (index >= cards.Count) return;

        Card card = cards[index];
        Debug.Log("Opponent card revealed: " + card.name);
        ScoreManager.Instance.AddOpponentScore(card.power);
    }
}
