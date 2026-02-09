using UnityEngine;

public class CardLoader : MonoBehaviour
{
    public static CardLoader Instance;
    public CardData[] allCards;

    void Awake()
    {
        Instance = this;

        TextAsset json = Resources.Load<TextAsset>("cards");

        if (json == null)
        {
            Debug.LogError("cards.json NOT FOUND in Resources folder!");
            return;
        }

        allCards = JsonUtility.FromJson<CardList>(json.text).cards;

        Debug.Log("Loaded cards: " + allCards.Length);
    }
}
