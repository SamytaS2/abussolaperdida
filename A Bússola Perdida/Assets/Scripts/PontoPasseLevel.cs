using UnityEngine; // Biblioteca principal do Unity (acesso a componentes, objetos, etc.)
using UnityEngine.SceneManagement; // Necessária para trocar de cenas no jogo

public class PontoPasseLevel : MonoBehaviour
{
    public string lvlName;

    // Definida como TRUE na última fase
    public bool ultimaFase = false;

    // Referência ao painel/canvas com a mensagem de vitória
    public GameObject PanelVictory; 


    // Chamado automaticamente quando outro Collider2D entra na área marcada como "Is Trigger"
    void OnTriggerEnter2D(Collider2D collider)
    {
        // Verifica se o objeto que entrou no trigger tem a tag "Player"
        if (collider.CompareTag("Player"))
        {
            // Se esta for a última fase
            if (ultimaFase)
            {
                // Ativa o painel de vitória, se ele estiver configurado no Inspector
                if (PanelVictory != null)
                    PanelVictory.SetActive(true);
                
                // Pausa o jogo para o jogador poder ver a mensagem sem que a ação continue
                Time.timeScale = 0f;
            }
            else
            {
                // Caso não seja a última fase, carrega a próxima cena
                SceneManager.LoadScene(lvlName);
            }
        }
    }
}
