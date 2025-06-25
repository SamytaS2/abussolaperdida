using System.Collections;
using UnityEngine;

public class PlataformaMovel : MonoBehaviour
{
    public Transform pontoA;
    public Transform pontoB;
    public float velocidade = 2f;

    private Vector3 destinoAtual;

    void Start()
    {
        destinoAtual = pontoB.position;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, destinoAtual, velocidade * Time.deltaTime);

        if (Vector3.Distance(transform.position, destinoAtual) < 0.1f)
        {
            destinoAtual = destinoAtual == pontoA.position ? pontoB.position : pontoA.position;
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
            // Em vez de usar SetParent(null) direto, usamos uma coroutine para evitar erro
            StartCoroutine(SoltarPlayerNoProximoFrame(collision.transform));
        }
    }

    IEnumerator SoltarPlayerNoProximoFrame(Transform player)
    {
        yield return null; // Espera 1 frame
        if (player != null)
        {
            player.SetParent(null);
        }
    }
}
