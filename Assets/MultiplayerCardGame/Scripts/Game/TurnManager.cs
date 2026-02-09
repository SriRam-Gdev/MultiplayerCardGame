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
    if (Instance == null)
    {
        Instance = this;
        Debug.Log("TurnManager initialized");
    }
    else
        Destroy(gameObject);
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

    if (PlayerNetwork.LocalPlayer == null)
    {
        Debug.Log("Waiting for network player...");
        return;
    }

    myTurnEnded = true;

    JsonMessage msg = new JsonMessage
    {
        action = "endTurn",
        playerId = PlayerNetwork.LocalPlayer.netId.ToString()
    };

    PlayerNetwork.LocalPlayer.CmdSendJson(JsonUtility.ToJson(msg));

    Debug.Log("Sent End Turn");
}



    public void StartNextTurn()
    {
        currentTurn++;
        turnTimer = 30f;
        myTurnEnded = false;

        Debug.Log("Turn " + currentTurn + " started");
    }
}


