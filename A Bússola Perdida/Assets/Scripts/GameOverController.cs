using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public static string cenaAnterior;

    public void JogarNovamente()
    {
        if (string.IsNullOrEmpty(cenaAnterior))
        {
            Debug.LogWarning("Cena anterior não definida! Voltando para o menu principal.");
            SceneManager.LoadScene("MenuPrincipal"); // ou qualquer cena padrão que você tenha
        }
        else
        {
            SceneManager.LoadScene(cenaAnterior);
        }
    }
}
