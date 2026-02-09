using UnityEngine;

public class GameMessageRouter : MonoBehaviour
{
    public static GameMessageRouter Instance;

    void Awake()
    {
        Instance = this;
    }

    public void Handle(string json)
    {
        JsonMessage msg = JsonUtility.FromJson<JsonMessage>(json);

        if (msg.action == "endTurn")
            TurnManager.Instance.OnPlayerEnded(msg.playerId);
    }
}
