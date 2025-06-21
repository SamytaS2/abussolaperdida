using UnityEngine;

public class Moedas : MonoBehaviour
{
    private SpriteRenderer sr;
    private CircleCollider2D circle;

    public int scoreMoedas = 1;
    
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        circle = GetComponent<CircleCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.CompareTag("Player"))
        {
            sr.enabled = false;
            circle.enabled = false;
            GameController.instance.totalScoreMoedas += scoreMoedas;
            GameController.instance.UpdateScoreText();
            Destroy(gameObject, 0.3f); // destrói após um pequeno delay
        }
    }
}
