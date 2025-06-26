using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PontoPasseLevel : MonoBehaviour
{
    public string lvlName;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(lvlName);
        }
    }
}
