using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobilePlataform : MonoBehaviour
{
    public Transform[] puntosMovimiento; // Puntos a los que la plataforma se mueve
    public float velocidadMovimiento = 5f; // Velocidad de movimiento
    private int siguientePlataforma = 0; // Índice del siguiente punto
    private bool ordenPlataformas = true; // Indica la dirección de movimiento (ida o vuelta)

    void Update()
    {
        // Asegurar que hay al menos un punto de movimiento
        if (puntosMovimiento.Length == 0) return;

        // Cambiar la dirección al llegar al último o primer punto
        if (ordenPlataformas && siguientePlataforma + 1 >= puntosMovimiento.Length)
        {
            ordenPlataformas = false;
        }
        else if (!ordenPlataformas && siguientePlataforma <= 0)
        {
            ordenPlataformas = true;
        }

        // Mover la plataforma hacia el siguiente punto
        if (Vector3.Distance(transform.position, puntosMovimiento[siguientePlataforma].position) < 0.1f)
        {
            if (ordenPlataformas)
            {
                siguientePlataforma += 1;
            }
            else
            {
                siguientePlataforma -= 1;
            }
        }

        // Movimiento hacia el punto objetivo
        transform.position = Vector3.MoveTowards(transform.position, puntosMovimiento[siguientePlataforma].position,
            velocidadMovimiento * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // Si el jugador toca la plataforma, se convierte en hijo de la plataforma
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.SetParent(this.transform);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        // Si el jugador deja de tocar la plataforma, se desasocia de la plataforma
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.SetParent(null);
        }
    }
}
