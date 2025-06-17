using UnityEngine;

public class Coletáveis : MonoBehaviour
{
    private SpriteRenderer sr;
    private CircleCollider2D circle;

    public int score;
    
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        circle = GetComponent<CircleCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.tag == "Player")
        {
            sr.enabled = false;
            circle.enabled = false;
            GameController.instance.totalScore += score;
            GameController.instance.UpdateScoreText();
            Destroy(gameObject, 0.3f); // destrói após um pequeno delay
        }
    }
    
   
}
