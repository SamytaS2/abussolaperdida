using System.Collections;
using UnityEngine;

public class PlataformaMovel : MonoBehaviour
{
    //Pontos entre os quais a plataforma se moverá
    public Transform pontoA;
    public Transform pontoB;

    //Velocidade da plataforma
    public float velocidade = 2f;

    //Armazena o destino atual da plataforma
    private Vector3 destinoAtual;

    void Start()
    {
        //Começa movendo em direção ao ponto B
        destinoAtual = pontoB.position;
    }

    void Update()
    {
        //Move a plataforma em direção ao destinoAtual
        transform.position = Vector3.MoveTowards(transform.position, destinoAtual, velocidade * Time.deltaTime);

        //Quando a plataforma chega perto do destino, alterna o destino
        if (Vector3.Distance(transform.position, destinoAtual) < 0.1f)
        {
            destinoAtual = destinoAtual == pontoA.position ? pontoB.position : pontoA.position;
        }
    }

    //Quando o jogador pisa na plataforma
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Torna o jogador filho da plataforma para que ele se mova junto
            collision.transform.SetParent(transform);
        }
    }

    //Quando o jogador sai da plataforma
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Usamos uma coroutine para esperar 1 frame antes de soltar o jogador
            //Evita problemas de física no mesmo frame
            StartCoroutine(SoltarPlayerNoProximoFrame(collision.transform));
        }
    }

    //Coroutine que solta o jogador no próximo frame
    IEnumerator SoltarPlayerNoProximoFrame(Transform player)
    {
        yield return null; // Espera 1 frame
        if (player != null)
        {
            player.SetParent(null); // Remove a plataforma como pai
        }
    }
}
