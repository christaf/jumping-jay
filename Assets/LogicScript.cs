using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;
    private void Start()
    {
        ResetScore();
        gameOverScreen.SetActive(false);
    }
    
    [ContextMenu("Add Score")]
    public void AddScore(int scoreToAdd)
    {
        playerScore = playerScore + scoreToAdd;
        scoreText.text = "Score: " + playerScore.ToString();
    }

    [ContextMenu("Reset Score")]
    public void ResetScore()
    {
        playerScore = 0;
        scoreText.text = "Score: " + playerScore.ToString();
    }

    [ContextMenu("Restart Game")]
    public void RestartGame()
    {
        ResetScore();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.Log("Restart Game");
        // Application.LoadLevel(Application.loadedLevel);
    }
    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        Debug.Log("Game Over");
    }

}