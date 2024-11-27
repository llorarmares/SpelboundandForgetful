using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Memorie : MonoBehaviour
{
    [SerializeField] private int cantidadPuntos = 1; // Puntos otorgados al jugador

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ControladorPuntos.Instance.SumarPuntos(cantidadPuntos); // Suma puntos al jugador
            Destroy(gameObject); // Destruye el objeto después de otorgar puntos
        }
    }
}

