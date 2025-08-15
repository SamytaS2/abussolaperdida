using System.Collections;
using UnityEngine;

public class PlataformaCaindo : MonoBehaviour
{
    //Tempo em segundos antes da plataforma começar a cair
    public float fallingTime = 0.5f;

    //Referências para componentes da plataforma
    private TargetJoint2D target; //Mantém a plataforma fixa até ser desativado
    private BoxCollider2D boxColl; //Collider da plataforma

    void Start()
    {
        //Pega as referências dos componentes
        target = GetComponent<TargetJoint2D>();
        boxColl = GetComponent<BoxCollider2D>();
    }

    //Detecta quando o jogador pisa na plataforma
    void OnCollisionEnter2D(Collision2D collision)
    {
        //Se o objeto que encostou for o jogador...
        if (collision.gameObject.CompareTag("Player"))
        {
            //Agenda o método "Falling" para ser chamado após "fallingTime" segundos
            Invoke("Falling", fallingTime);
        }
    }

    //Desativa a fixação da plataforma e permite que ela caia
    void Falling()
    {
        //Desativa o TargetJoint2D para liberar o movimento
        if (target != null) 
            target.enabled = false;

        //Torna o collider um "trigger" para que o jogador não colida mais
        if (boxColl != null) 
            boxColl.isTrigger = true;
    }
}