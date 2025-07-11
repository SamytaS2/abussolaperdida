using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    //Poções
    public int totalScorePocoes;
    public TMP_Text scoreTextPocoes;

    //Moedas
    public int totalScoreMoedas;
    public TMP_Text scoreTextMoedas;

    public static GameController instance;

    void Start()
    {
        instance = this;
    }

    public void UpdateScoreText()
    {
        scoreTextPocoes.text = totalScorePocoes.ToString();
        scoreTextMoedas.text = totalScoreMoedas.ToString();
    }

}

