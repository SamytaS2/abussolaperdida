using UnityEngine;
using UnityEngine.UI;

public class BarraDeVida : MonoBehaviour
{
   public Slider slider;

    public void AlterarVida(float vida){
        //o valor do slider será o da vida do personagem
        slider.value = vida;
    }

}