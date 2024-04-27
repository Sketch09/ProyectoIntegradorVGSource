using UnityEngine;
using TMPro; // Use TextMesh Pro namespace
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }

    public int timeLimit = 60; // Total time limit for the game
    private float timeRemaining; // Remaining time
    public TMP_Text timeText; // TextMesh Pro Text component for displaying time
    public TMP_Text scoreText; // TextMesh Pro Text component for displaying score
    private int score; // Current score


    private void Start()
    {
        timeRemaining = timeLimit; // Initialize timeRemaining at the start
    }

    private void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime; // Decrement remaining time
            timeText.text = "Time: " + Mathf.FloorToInt(timeRemaining).ToString(); // Update time display
        }
        else
        {
            EndGame(); // End the game if time runs out
        }
    }

    public void IncreaseScore(int amount)
    {
        score += amount; // Increment score by the given amount
        scoreText.text = "Score: " + score.ToString(); // Update score display
    }

    public void IncreaseTime(int amount)
    {
        timeRemaining += amount; // Increment score by the given amount
        timeText.text = "Time: " + timeRemaining.ToString(); // Update score display
    }


    void EndGame()
    {
        Debug.Log("Game Over! Your score: " + score);
        SceneManager.LoadScene("GameOver"); // Loads the game over scene
    }
}
