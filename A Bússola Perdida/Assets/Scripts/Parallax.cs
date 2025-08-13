using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float lenght;       // Armazena a largura do sprite atual (em unidades do mundo)
    private float StartPos;     // Posição inicial no eixo X do objeto (para saber onde começar o deslocamento)

    private Transform cam;      // Referência para o transform da câmera
    private float ParallaxEffect; // Fator do efeito parallax (0 = acompanha a câmera totalmente, 1 = fica parado)

    // Start é chamado antes do primeiro Update
    void Start()
    {
        // Guarda a posição inicial do objeto no eixo X
        StartPos = transform.position.x;

        // Pega a largura do sprite, para saber quando repetir ou ajustar
        lenght = GetComponent<SpriteRenderer>().bounds.size.x;

        // Pega a referência da câmera principal
        cam = Camera.main.transform;
    }

    // Update é chamado a cada frame
    void Update()
    {
        // Calcula a nova posição com base no efeito parallax
        float Repos = cam.transform.position.x * (1 - ParallaxEffect);

        // Calcula o deslocamento relativo ao movimento da câmera
        float Distance = -cam.transform.position.x * ParallaxEffect;
    }
}
