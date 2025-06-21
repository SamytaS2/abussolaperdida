using UnityEngine;

public class PlataformaMovel : MonoBehaviour
{
    public Transform pontoA;
    public Transform pontoB;
    public float speed = 2f;

    private Vector3 destinoAtual;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        destinoAtual = pontoB.position;
    }

    // Update is called once per frame
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
}
