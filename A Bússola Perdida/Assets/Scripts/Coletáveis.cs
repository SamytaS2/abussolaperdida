using UnityEngine;

public class Coletáveis : MonoBehaviour
{
    private SpriteRenderer sr;
    private CircleCollider2D circle;

    public GameObject collected;
    public int score;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        circle = GetComponent<CircleCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider.gameObject.tag == "Player")
        {
            sr.enabled = false;
        }
    }
    void Update()
    {
        
    }
}
