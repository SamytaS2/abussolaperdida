using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public int totalScore;
    public TMP_Text scoreText;

    public static GameController instance;

    void Start()
    {
        instance = this;
    }

    public void UpdateScoreText()
    {
        scoreText.text = totalScore.ToString();
    }

}

