using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public static TurnManager Instance;

    public int currentTurn = 1;
    public float turnTimer = 30f;

    bool myTurnEnded = false;
    int endedPlayers = 0;

    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        if (myTurnEnded) return;

        turnTimer -= Time.deltaTime;

        if (turnTimer <= 0)
            EndTurn();
    }

    public void EndTurn()
    {
        if (myTurnEnded) return;

        myTurnEnded = true;

        JsonMessage msg = new JsonMessage
        {
            action = "endTurn",
            playerId = PlayerNetwork.LocalPlayer.netId.ToString()
        };

        PlayerNetwork.LocalPlayer.CmdSendJson(JsonUtility.ToJson(msg));

        Debug.Log("Sent End Turn");
    }

    public void OnPlayerEnded(string playerId)
    {
        endedPlayers++;

        Debug.Log("Player ended turn: " + playerId);

        if (endedPlayers >= 2)
        {
            endedPlayers = 0;
            StartNextTurn();
        }
    }

    public void StartNextTurn()
    {
        currentTurn++;
        turnTimer = 30f;
        myTurnEnded = false;

        Debug.Log("Turn " + currentTurn + " started");
    }
}
