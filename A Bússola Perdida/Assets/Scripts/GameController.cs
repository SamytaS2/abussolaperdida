using UnityEngine; //Biblioteca principal do Unity
using TMPro; //Necessária para usar TextMeshPro (TMP_Text)
using UnityEngine.SceneManagement; //Necessária para trocar de cena
using UnityEngine.UI;
using System;
public class GameController : MonoBehaviour
{
    public BarraDeVida barra;
    private float vida = 100;

    //Pontuação de Poções
    public int totalScorePocoes; //Guarda a quantidade total de poções coletadas
    public TMP_Text scoreTextPocoes; //Texto UI para exibir a quantidade de poções

    //Pontuação de Moedas
    public int totalScoreRosas;     //Guarda a quantidade total de moedas coletadas
    public TMP_Text scoreTextRosas; //Texto UI para exibir a quantidade de moedas

    //Instância estática para acesso fácil a este controlador de qualquer outro script
    public static GameController instance;

    //Referência ao painel de Game Over (UI)
    public GameObject gameOver;
    public GameObject imagePocao;
    public GameObject imageRosa;
    public GameObject barraDeVida;

    void Awake()
    {
        instance = this;
    }

    //Chamado quando o jogo começa
    void Start()
    {
        // Inicializa a barra com vida cheia
        barra.SetMaxVida(100);
    }


    // Atualiza os textos na UI com os valores atuais de poções e moedas
    public void UpdateScoreText()
    {
        //Converte número para string e mostra
        scoreTextPocoes.text = totalScorePocoes.ToString();
        scoreTextRosas.text = totalScoreRosas.ToString();
    }

    //Exibe o painel de Game Over
    public void ShowGameOver()
    {
        //Ativa o objeto na cena
        gameOver.SetActive(true);
        imagePocao.SetActive(false);
        imageRosa.SetActive(false);
        barraDeVida.SetActive(false);
    }

    //Reinicia a fase, recebendo o nome da cena como parâmetro
    public void Reiniciar(string faseNome)
    {
        //Carrega a cena com o nome informado
        SceneManager.LoadScene(faseNome);
    }

    public void AlterarVida(float quantidade)
    {
        vida = Mathf.Clamp(vida + quantidade, 0f, 100f);
        barra.GerenciarVida(vida);

        if (vida > 0)
        {
            return;
        }
        ShowGameOver();
    }

    public void AddRosa(int quantidade)
    {
        totalScoreRosas += quantidade;
        UpdateScoreText();

        if (totalScoreRosas % 10 == 0 && vida < 100)
        {
            AlterarVida(10f); 
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            vida = Mathf.Clamp(vida - 10f, 0f, 100f);
            barra.GerenciarVida(vida);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            vida = Mathf.Clamp(vida + 10f, 0f, 100f);
            barra.GerenciarVida(vida);
        }
    }

}
