using UnityEngine;

public class GameMessageRouter : MonoBehaviour
{
    public static GameMessageRouter Instance;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void Handle(string json)
    {
        if (string.IsNullOrEmpty(json))
            return;

        JsonMessage msg = JsonUtility.FromJson<JsonMessage>(json);

        if (msg == null)
        {
            Debug.LogError("Invalid JSON message received!");
            return;
        }

        switch (msg.action)
        {
            case "endTurn":
                HandleEndTurn(msg.playerId);
                break;
        }
    }

    void HandleEndTurn(string playerId)
    {
        if (TurnManager.Instance == null)
        {
            Debug.LogError("TurnManager not found in scene!");
            return;
        }

        //TurnManager.Instance.OnPlayerEnded(playerId);
    }
}
