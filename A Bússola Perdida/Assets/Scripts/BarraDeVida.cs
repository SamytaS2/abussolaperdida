using UnityEngine;
using UnityEngine.UI;

public class BarraDeVida : MonoBehaviour
{
    public Slider slider;

    public void SetMaxVida(float maxVida)
    {
        slider.maxValue = maxVida;
        slider.value = maxVida;
    }

    public void GerenciarVida(float vida)
    {
        //o valor do slider será o da vida do personagem
        slider.value = vida;
    }

}

