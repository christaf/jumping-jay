using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    private Camera _mainCamera;
    public int playerScore;
    public Text scoreText;
    public Text highScoreText;
    public GameObject gameOverScreen;

    private const string highscoreKey = "BestScore";

    public bool SaveHighscore(int score)
        {
            int currentHighscore = LoadHighscore();

            if (score > currentHighscore)
            {
                PlayerPrefs.SetInt(highscoreKey, score);
                PlayerPrefs.Save();
                return true;
            }
            return false;
        }

        public int LoadHighscore()
        {
            return PlayerPrefs.GetInt(highscoreKey, 0);
        }


    private void GetCameraEdgesCoordinates()
    {
        if (_mainCamera == null)
        {
            Debug.LogError("Main camera not found!");
            return;
        }

        float cameraHeight = 2f * _mainCamera.orthographicSize;
        float cameraWidth = cameraHeight * _mainCamera.aspect;

        float cameraX = _mainCamera.transform.position.x;
        float cameraY = _mainCamera.transform.position.y;

        float cameraLeftEdge = cameraX - cameraWidth / 2;
        float cameraRightEdge = cameraX + cameraWidth / 2;
        float cameraTopEdge = cameraY + cameraHeight / 2;
        float cameraBottomEdge = cameraY - cameraHeight / 2;

//         Debug.Log("Left Edge: " + cameraLeftEdge);
//         Debug.Log("Right Edge: " + cameraRightEdge);
//         Debug.Log("Top Edge: " + cameraTopEdge);
//         Debug.Log("Bottom Edge: " + cameraBottomEdge);
    }
    private void Start()
    {
        _mainCamera = Camera.main;

        GetCameraEdgesCoordinates();
        ResetScore();
        gameOverScreen.SetActive(false);
        highScoreText.text = "Best score: " + LoadHighscore().ToString();
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
    }
    public void GameOver()
    {
        if(SaveHighscore(playerScore)){
            SceneManager.LoadScene("HighscoreScene");
        };

        gameOverScreen.SetActive(true);
        Debug.Log("Game Over");
    }
    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }

}