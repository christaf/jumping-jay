using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    private Camera _mainCamera;
    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;

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

        Debug.Log("Left Edge: " + cameraLeftEdge);
        Debug.Log("Right Edge: " + cameraRightEdge);
        Debug.Log("Top Edge: " + cameraTopEdge);
        Debug.Log("Bottom Edge: " + cameraBottomEdge);
    }
    private void Start()
    {
        _mainCamera = Camera.main;

        // Call this method to get and print the coordinates of camera edges
        GetCameraEdgesCoordinates();
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