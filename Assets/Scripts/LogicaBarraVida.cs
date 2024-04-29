using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogicaBarraVida : MonoBehaviour
{
    
    public float vida = 100;
    public Image imagenBarraVida;

   

    void Update()
    {
       vida = Mathf.Clamp(vida, 0, 100);
       imagenBarraVida.fillAmount = vida / 100;
    }

    
}