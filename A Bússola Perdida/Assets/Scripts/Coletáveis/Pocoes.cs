using UnityEngine;

public class Pocoes : MonoBehaviour
{
    private SpriteRenderer sr;
    private CircleCollider2D circle;

    public int scorePocoes = 1;
    
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
            GameController.instance.totalScorePocoes += scorePocoes;
            GameController.instance.UpdateScoreText();
            Destroy(gameObject, 0.3f); // destrói após um pequeno delay
        }
    }
    
   
}
