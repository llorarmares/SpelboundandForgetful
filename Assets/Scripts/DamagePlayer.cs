using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)  
    {
        // Verifica si el objeto que entra en el collider tiene la etiqueta "Player"
        if (other.tag == "Player")  
        {
            // Aplica daño al jugador usando el controlador de salud
            PlayerHealthController.instance.DealDamage();  
        }
    }
}


