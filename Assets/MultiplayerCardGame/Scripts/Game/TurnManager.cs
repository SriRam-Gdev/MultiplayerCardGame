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
            return;

        myTurnEnded = true;

        // Lock selected cards into folded pile
        if (HandManager.Instance != null)
            HandManager.Instance.FoldSelectedCards();

        JsonMessage msg = new JsonMessage
        {
            action = "endTurn",
            playerId = PlayerNetwork.LocalPlayer.netId.ToString(),
            foldedCount = HandManager.Instance != null ? 
                          HandManager.Instance.foldedCards.Count : 0
        };

        PlayerNetwork.LocalPlayer.CmdSendJson(JsonUtility.ToJson(msg));

        Debug.Log("End Turn sent");
    }

    public void OnPlayerEnded(string playerId)
    {
        endedPlayers++;

        Debug.Log("Player ended: " + playerId);

        if (endedPlayers >= 2)
        {
            endedPlayers = 0;

            // Start reveal phase (local for now)
            if (RevealManager.Instance != null && HandManager.Instance != null)
            {
                RevealManager.Instance.StartReveal(
                    HandManager.Instance.foldedCards,
                    HandManager.Instance.foldedCards   // temp until opponent list added
                );
            }

            StartNextTurn();
        }
    }

    void StartNextTurn()
    {
        currentTurn++;

        if (currentTurn > 6)
        {
            Debug.Log("GAME OVER");
            return;
        }

        turnTimer = 30f;
        myTurnEnded = false;

        Debug.Log("Turn " + currentTurn + " started");
    }
}
