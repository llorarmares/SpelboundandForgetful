using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caldero : MonoBehaviour
{
    private Animator animator;
    private bool isPushing = false; // Booleano para saber si el jugador está en contacto

    private void Start()
    {
        // Inicializa el Animator correctamente
        animator = GetComponent<Animator>();
    }

    // Detecta cuando un objeto entra al área del Trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPushing = true; // El jugador está en contacto
            animator.SetBool("isPushing", isPushing); // Activa la animación de empujar
        }
    }

    // Detecta cuando un objeto permanece en el área del Trigger
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Si el jugador sigue en contacto, mantenemos la animación activa
            if (!isPushing)
            {
                isPushing = true;
                animator.SetBool("isPushing", isPushing);
            }
        }
    }

    // Detecta cuando un objeto sale del área del Trigger
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPushing = false; // El jugador ya no está en contacto
            animator.SetBool("isPushing", isPushing); // Desactiva la animación de empujar
            animator.SetTrigger("walking"); // Activa la animación de caminar
        }
    }
}
