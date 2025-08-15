using UnityEngine; //Biblioteca principal do Unity
using TMPro; //Necessária para usar TextMeshPro (TMP_Text)
using UnityEngine.SceneManagement; //Necessária para trocar de cena

public class GameController : MonoBehaviour
{
    //Pontuação de Poções
    public int totalScorePocoes; //Guarda a quantidade total de poções coletadas
    public TMP_Text scoreTextPocoes; //Texto UI para exibir a quantidade de poções

    //Pontuação de Moedas
    public int totalScoreMoedas;     //Guarda a quantidade total de moedas coletadas
    public TMP_Text scoreTextMoedas; //Texto UI para exibir a quantidade de moedas

    //Instância estática para acesso fácil a este controlador de qualquer outro script
    public static GameController instance;

    //Referência ao painel de Game Over (UI)
    public GameObject gameOver;

    //Chamado quando o jogo começa
    void Start()
    {
        //Define a instância estática como este objeto
        instance = this; 
    }

    // Atualiza os textos na UI com os valores atuais de poções e moedas
    public void UpdateScoreText()
    {
        //Converte número para string e mostra
        scoreTextPocoes.text = totalScorePocoes.ToString(); 
        scoreTextMoedas.text = totalScoreMoedas.ToString(); 
    }

    //Exibe o painel de Game Over
    public void ShowGameOver()
    {
        //Ativa o objeto na cena
        gameOver.SetActive(true);
    }

    //Reinicia a fase, recebendo o nome da cena como parâmetro
    public void Reiniciar(string faseNome)
    {
        //Carrega a cena com o nome informado
        SceneManager.LoadScene(faseNome); 
    }
}
