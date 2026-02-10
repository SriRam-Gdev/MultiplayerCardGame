using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public int myScore = 0;
    public int opponentScore = 0;

    public Text scoreText;

    void Awake()
    {
        Instance = this;
        UpdateUI();
    }

    void UpdateUI()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + myScore + " - " + opponentScore;
    }

    public void AddMyScore(int value)
    {
        myScore += value;
        UpdateUI();
        Debug.Log("My score: " + myScore);
    }

    public void AddOpponentScore(int value)
    {
        opponentScore += value;
        UpdateUI();
        Debug.Log("Opponent score: " + opponentScore);
    }
}
