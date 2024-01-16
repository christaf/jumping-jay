using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    public Text highScoreText;
    public Button startButton;

    public void ButtonHandler()
    {
        startButton.onClick.AddListener(StartGame);
    }

    private const string highscoreKey = "BestScore";

    public void LoadHighScore()
    {
        int highScore = PlayerPrefs.GetInt(highscoreKey, 0);
        highScoreText.text = "Current highscore: " + highScore;
    }

    public void Start()
    {
        ButtonHandler();
        LoadHighScore();
    }
    [ContextMenu("Start game")]
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}