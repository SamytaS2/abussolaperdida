using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void LoadScene(string cena)
    {
        SceneManager.LoadScene(cena);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
