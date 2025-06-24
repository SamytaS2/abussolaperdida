using System.Collections;
using UnityEngine;

public class PlataformaMovel : MonoBehaviour
{
    public Transform pontoA;
    public Transform pontoB;
    public float speed = 2f;

    private Vector3 destinoAtual;

    void Start()
    {
        destinoAtual = pontoB.position;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, destinoAtual, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, destinoAtual) < 0.1f)
        {
            if (Vector3.Distance(destinoAtual, pontoA.position) < 0.1f)
                destinoAtual = pontoB.position;
            else
                destinoAtual = pontoA.position;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(RemoverPaiDepoisDeUmFrame(collision.transform));
        }
    }

    private IEnumerator RemoverPaiDepoisDeUmFrame(Transform filho)
    {
        yield return null;
        filho.SetParent(null);
    }
}
