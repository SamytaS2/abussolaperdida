using UnityEngine;

public class Coletaveis : MonoBehaviour
{
    private SpriteRenderer sr;
    private CircleCollider2D circle;

    public int score = 1;
    
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
            GameController.instance.totalScore += score;
            GameController.instance.UpdateScoreText();
            Destroy(gameObject, 0.3f); // destrói após um pequeno delay
        }
    }
    
   
}
