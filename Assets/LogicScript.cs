using UnityEngine;
using UnityEngine.UI;
public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;

    private void Start()
    {
        playerScore = 0;
    }

    [ContextMenu("Add Score")]
    public void AddScore(int scoreToAdd)
    {
        playerScore = playerScore + scoreToAdd;
        scoreText.text = "score: " + playerScore.ToString();
    }

}
