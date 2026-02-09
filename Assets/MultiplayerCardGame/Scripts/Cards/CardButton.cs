using UnityEngine;
using UnityEngine.UI;

public class CardButton : MonoBehaviour
{
    public int cardIndex;   // which card from hand this button represents
    Button button;

    void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        if (HandManager.Instance == null)
            return;

        if (cardIndex < 0 || cardIndex >= HandManager.Instance.hand.Count)
            return;

        Card card = HandManager.Instance.hand[cardIndex];
        HandManager.Instance.ToggleSelect(card);
    }
}
