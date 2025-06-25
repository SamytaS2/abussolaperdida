using System.Collections;
using UnityEngine;

public class PlataformaCaindo : MonoBehaviour
{
    public float fallingTime = 0.5f;

    private TargetJoint2D target;
    private BoxCollider2D boxColl;

    void Start()
    {
        target = GetComponent<TargetJoint2D>();
        boxColl = GetComponent<BoxCollider2D>();
    }

    // Quando o player encostar, inicia o processo de queda
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Invoke("Falling", fallingTime);
        }
    }

    // Método chamado via Invoke após o tempo
    void Falling()
    {
        if (target != null) target.enabled = false;
        if (boxColl != null) boxColl.isTrigger = true;
    }
}
